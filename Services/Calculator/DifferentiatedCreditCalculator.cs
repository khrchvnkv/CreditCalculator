using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    internal class DifferentiatedCreditCalculator : ICreditCalculator
    {
        public List<MonthlyPayment> GetMonthlyPayments(CreditInfo creditInfo)
        {
            Console.WriteLine($"Start Calculating 1");
            var paymentsList = new List<MonthlyPayment>();
            var date = creditInfo.DateOfIssue;
            var nextPaymentDate = date.AddMonths(1);
            var dailyPercent = GetDailyPercent(creditInfo.Percent);
            Console.WriteLine($"Start Calculating 2");
            var mainPayment = creditInfo.TotalSum / 
                              GetPaymentsCount(creditInfo.DateOfIssue, creditInfo.DateOfClosing);
            var remainingAmount = creditInfo.TotalSum;
            Console.WriteLine($"Start Calculating 3");
            Console.WriteLine($"Main payment = {mainPayment}");
            while (true)
            {
                var daysInMonth = (nextPaymentDate - date).TotalDays;
                var percentForMonth = daysInMonth * dailyPercent;
                var payment = new MonthlyPayment();
                payment.DateOfPayment = nextPaymentDate;
                payment.BodyPayment = mainPayment;
                payment.PercentsPayment = remainingAmount * (decimal)percentForMonth;
                remainingAmount -= mainPayment;
                payment.RemainingAmount = remainingAmount;
                paymentsList.Add(payment);
                
                date = nextPaymentDate;

                if (nextPaymentDate == creditInfo.DateOfClosing)
                {
                    break;
                }
                
                if (nextPaymentDate.AddMonths(1) >= creditInfo.DateOfClosing)
                {
                    nextPaymentDate = creditInfo.DateOfClosing;
                }
                else
                {
                    nextPaymentDate = nextPaymentDate.AddMonths(1);
                }
            }
            
            return paymentsList;
        }
        private int GetPaymentsCount(DateTime issue, DateTime closing)
        {
            int count = 0;
            do
            {
                count++;
                issue = issue.AddMonths(1);
            } 
            while (issue <= closing);
            
            return count;
        }
        private double GetDailyPercent(double percent) => 
            percent / 365.0d / 100.0d;
    }
}