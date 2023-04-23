using System.ComponentModel;
using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    public class CalculatorService
    {
        private readonly ICreditCalculator _differentiatedCreditCalculator;
        private readonly ICreditCalculator _annuityCreditCalculator;

        public CalculatorService()
        {
            _differentiatedCreditCalculator = new DifferentiatedCreditCalculator();
            _annuityCreditCalculator = new AnnuityCreditCalculator();
        }
        public bool IsValidCreditInfo(CreditInfo creditInfo)
        {
            if (IsNullData()) return false;
            if (!IsValidDate() || !IsValidCreditSum() || 
                !IsValidInterestRate() || !IsValidPaymentDay()) return false;
            return true;

            bool IsNullData() => creditInfo == null;
            bool IsValidDate() => creditInfo.DateOfClosing >= creditInfo.DateOfIssue;
            bool IsValidCreditSum() => creditInfo.TotalSum >= 0.0m;
            bool IsValidInterestRate() => creditInfo.InterestRate >= 0.0f;
            bool IsValidPaymentDay() => creditInfo.PaymentDay is >= 1 and <= 31;
        }
        public List<MonthlyPayment> GetMonthlyPaymentsFromCreditInfo(CreditInfo creditInfo)
        {
            switch (creditInfo.CreditType)
            {
                case CreditInfo.CalculationType.Annuity:
                    return _annuityCreditCalculator.GetAllPayments(creditInfo);
                case CreditInfo.CalculationType.Differentiated:
                    return _differentiatedCreditCalculator.GetAllPayments(creditInfo);
            }
            throw new InvalidEnumArgumentException();
        }
    }
}