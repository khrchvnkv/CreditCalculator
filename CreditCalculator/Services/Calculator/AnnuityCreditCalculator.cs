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
            var coefficient = (decimal)(rate * Math.Pow(1 + rate, paymentsCount) /
                                        (Math.Pow(1 + rate, paymentsCount) - 1));
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
                payment.Date = nextDate;
                payment.InterestPayment = interestShare;
                payment.PrincipalPayment = Decimal.Min(monthlyPayment - payment.InterestPayment, creditBody);
                payment.TotalPayment = payment.PrincipalPayment + payment.InterestPayment;
                creditBody -= payment.PrincipalPayment;
                payment.RemainingAmount = creditBody;

                if (payment.TotalPayment > 0.0m)
                {
                    paymentsList.Add(payment);
                }
            }
            
            return paymentsList;
        }
    }
}