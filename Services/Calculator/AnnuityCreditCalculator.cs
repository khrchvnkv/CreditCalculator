using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    internal class AnnuityCreditCalculator : ICreditCalculator
    {
        public List<MonthlyPayment> GetMonthlyPayments(CreditInfo creditInfo)
        {
            return new List<MonthlyPayment>();
        }
    }
}