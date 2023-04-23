using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    public abstract class Calculator : ICreditCalculator
    {
        public abstract List<MonthlyPayment> GetAllPayments(CreditInfo creditInfo);
        protected float GetDailyPercent(float percent) => percent / 365 / 100.0f;
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