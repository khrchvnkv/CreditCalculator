using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    public class AnnuityCreditCalculator : Calculator
    {
        private const float MonthsInOneYear = 12;
        
        public override List<MonthlyPayment> GetAllPayments(CreditInfo creditInfo)
        {
            var paymentsList = new List<MonthlyPayment>();
            
            var paymentsCount = GetPaymentsCount(creditInfo.DateOfIssue, creditInfo.DateOfClosing);
            var dailyPercent = GetDailyPercent(creditInfo.InterestRate);
            var creditBody = creditInfo.TotalSum;

            var rate = creditInfo.InterestRate / MonthsInOneYear / 100.0f;
            var coefficient = (decimal)(rate + rate / (Math.Pow(1 + rate, paymentsCount) - 1));
            var monthlyPayment = creditInfo.TotalSum * coefficient;
            
            for (int i = 0; i < paymentsCount; i++)
            {
                var lastDate = creditInfo.DateOfIssue.AddMonths(i);
                var nextDate = creditInfo.DateOfIssue.AddMonths(i + 1);
                
                if (nextDate > creditInfo.DateOfClosing)
                {
                    nextDate = creditInfo.DateOfClosing;
                }
                
                var daysInMonth = (nextDate - lastDate).Days;
                var monthlyInterestRate = (decimal)(daysInMonth * dailyPercent);
                
                var interestShare = creditBody * monthlyInterestRate;

                var payment = new MonthlyPayment();
                payment.PaymentNumber = i + 1;
                payment.DateOfPayment = nextDate;
                payment.InterestPayment = interestShare;
                payment.BodyPayment = Decimal.Min(monthlyPayment - payment.InterestPayment, creditBody);
                payment.TotalPayment = payment.BodyPayment + payment.InterestPayment;
                creditBody -= payment.BodyPayment;
                payment.RemainingAmount = creditBody;

                paymentsList.Add(payment);
            }
            
            return paymentsList;
        }
    }
}