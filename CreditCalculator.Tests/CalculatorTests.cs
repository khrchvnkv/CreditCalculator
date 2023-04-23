using CreditCalculator.Services.Calculator;

namespace CreditCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void WhenCalculatingPaymentsCountFor5Years_ThenAssert60()
        {
            var dateOfIssue = new DateTime(2010, 1, 1);
            var dateOfClosing = new DateTime(2015, 1, 1);
            var creditCalculator = new AnnuityCreditCalculator();
            var paymentsCount = creditCalculator.GetPaymentsCount(dateOfIssue, dateOfClosing);
            Assert.Equal(60, paymentsCount);
        }
        [Fact]
        public void WhenCalculatingPaymentsCountFor0Days_ThenAssert1()
        {
            var dateOfIssue = new DateTime(2010, 1, 1);
            var dateOfClosing = new DateTime(2010, 1, 1);
            var creditCalculator = new AnnuityCreditCalculator();
            var paymentsCount = creditCalculator.GetPaymentsCount(dateOfIssue, dateOfClosing);
            Assert.Equal(1, paymentsCount);
        }
    }
}