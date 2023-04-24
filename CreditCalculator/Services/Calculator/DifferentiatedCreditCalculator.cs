using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    public class DifferentiatedCreditCalculator : Calculator
    {
        public override List<MonthlyPayment> GetAllPayments(CreditInfo creditInfo)
        {
            var paymentsList = new List<MonthlyPayment>();
            
            var paymentsCount = GetPaymentsCount(creditInfo.DateOfIssue, creditInfo.DateOfClosing);
            var dailyInterest = GetDailyPercent(creditInfo.InterestRate);
            var principalPayment = creditInfo.TotalSum / paymentsCount;
            var creditBody = creditInfo.TotalSum;

            for (int i = 0; i < paymentsCount; i++)
            {
                var lastDate = creditInfo.DateOfIssue.AddMonths(i);
                var nextDate = creditInfo.DateOfIssue.AddMonths(i + 1);
                
                if (nextDate > creditInfo.DateOfClosing)
                {
                    nextDate = creditInfo.DateOfClosing;
                }
                
                var daysInMonth = (nextDate - lastDate).Days;
                var monthlyInterestRate = (decimal)(daysInMonth * dailyInterest);
                var payment = new MonthlyPayment();
                payment.PaymentNumber = i + 1;
                payment.Date = nextDate;
                payment.PrincipalPayment = Decimal.Min(principalPayment, creditBody);
                payment.InterestPayment = creditBody * monthlyInterestRate;
                payment.TotalPayment = payment.PrincipalPayment + payment.InterestPayment;
                creditBody -= payment.PrincipalPayment;
                payment.RemainingAmount = creditBody;

                paymentsList.Add(payment);
            }
            
            return paymentsList;
        }
    }
}