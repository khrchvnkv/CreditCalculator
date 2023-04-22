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
        public bool IsValidCreditInfo(in CreditInfo creditInfo)
        {
            return true;
        }
        public List<MonthlyPayment> GetMonthlyPaymentsFromCreditInfo(CreditInfo creditInfo)
        {
            switch (creditInfo.CreditType)
            {
                case CreditInfo.CalculationType.Annuity:
                    return _annuityCreditCalculator.GetMonthlyPayments(creditInfo);
                case CreditInfo.CalculationType.Differentiated:
                    return _differentiatedCreditCalculator.GetMonthlyPayments(creditInfo);
            }
            throw new InvalidEnumArgumentException();
        }
    }
}