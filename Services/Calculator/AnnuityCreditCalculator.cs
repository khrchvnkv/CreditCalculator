using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    internal class AnnuityCreditCalculator : Calculator
    {
        public override List<MonthlyPayment> GetMonthlyPayments(CreditInfo creditInfo)
        {
            return new List<MonthlyPayment>();
        }
    }
}