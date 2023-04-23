using CreditCalculator.Models;

namespace CreditCalculator.Services.Calculator
{
    internal interface ICreditCalculator
    {
        List<MonthlyPayment> GetAllPayments(CreditInfo creditInfo);
    }
}