using CreditCalculator.Models;
using CreditCalculator.Services.Calculator;

namespace CreditCalculator.Tests
{
    public class CalculatorServiceTests
    {
        [Fact]
        public void WhenValidatingCorrectCreditInfo_ThenAssertTrue()
        {
            var calculatorService = new CalculatorService();
            var creditInfo = GetCorrectCreditInfo();
            var validationStatus = calculatorService.IsValidCreditInfo(creditInfo);
            Assert.True(validationStatus);
        }
        [Fact]
        public void WhenValidatingIncorrectDatesCreditInfo_ThenAssertFalse()
        {
            var calculatorService = new CalculatorService();
            var today = DateTime.Today;
            var creditInfo = GetCorrectCreditInfo();
            creditInfo.DateOfIssue = today.AddMonths(1);
            creditInfo.DateOfClosing = today;
            var validationStatus = calculatorService.IsValidCreditInfo(creditInfo);
            Assert.False(validationStatus);
        }
        [Fact]
        public void WhenValidatingIncorrectInterestRateCreditInfo_ThenAssertFalse()
        {
            var calculatorService = new CalculatorService();
            var creditInfo = GetCorrectCreditInfo();
            creditInfo.InterestRate = -10.0f;
            var validationStatus = calculatorService.IsValidCreditInfo(creditInfo);
            Assert.False(validationStatus);
        }
        [Fact]
        public void WhenValidatingIncorrectTotalSumCreditInfo_ThenAssertFalse()
        {
            var calculatorService = new CalculatorService();
            var creditInfo = GetCorrectCreditInfo();
            creditInfo.TotalSum = -1_000_000;
            var validationStatus = calculatorService.IsValidCreditInfo(creditInfo);
            Assert.False(validationStatus);
        }
        private CreditInfo GetCorrectCreditInfo()
        {
            return new CreditInfo()
            {
                CreditType = CreditInfo.CalculationType.Annuity,
                DateOfIssue = DateTime.Today,
                DateOfClosing = DateTime.Today.AddMonths(6),
                InterestRate = 10.0f,
                TotalSum = 1_000_000
            };
        }
    }
}