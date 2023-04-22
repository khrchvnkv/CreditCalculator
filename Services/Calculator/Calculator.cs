using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    public abstract class Calculator : ICreditCalculator
    {
        public abstract List<MonthlyPayment> GetMonthlyPayments(CreditInfo creditInfo);
        protected decimal GetDailyPercent(decimal percent) => percent / 365.0m / 100m;
        protected int GetPaymentsCount(DateTime issue, DateTime closing)
        {
            int count = 1;
            while (issue.AddMonths(count) < closing)
            {
                count++;
            }
            
            Console.WriteLine($"Total Payments count = {count}");
            return count;
        }
    }
}