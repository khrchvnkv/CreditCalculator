using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    internal class DifferentiatedCreditCalculator : Calculator
    {
        public override List<MonthlyPayment> GetMonthlyPayments(CreditInfo creditInfo)
        {
            var paymentsList = new List<MonthlyPayment>();
            
            var paymentsCount = GetPaymentsCount(creditInfo.DateOfIssue, creditInfo.DateOfClosing);
            var dailyPercent = GetDailyPercent(creditInfo.Percent);
            var mainPayment = creditInfo.TotalSum / paymentsCount;
            var creditBody = creditInfo.TotalSum;

            for (int i = 0; i < paymentsCount; i++)
            {
                var lastDate = creditInfo.DateOfIssue.AddMonths(i);
                var nextDate = lastDate.AddMonths(1);
                
                if (nextDate > creditInfo.DateOfClosing)
                {
                    nextDate = creditInfo.DateOfClosing;
                }
                
                var daysInMonth = (nextDate - lastDate).Days;
                var percentForMonth = daysInMonth * dailyPercent;
                var payment = new MonthlyPayment();
                payment.PaymentNumber = i + 1;
                payment.DateOfPayment = nextDate;
                payment.BodyPayment = Decimal.Min(mainPayment, creditBody);
                payment.PercentsPayment = creditBody * percentForMonth;
                creditBody -= payment.BodyPayment;
                payment.RemainingAmount = creditBody;

                paymentsList.Add(payment);
            }
            
            return paymentsList;
        }
    }
}