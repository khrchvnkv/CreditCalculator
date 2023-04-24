namespace CreditCalculator.Models
{
    public class MonthlyPayment
    {
        public int PaymentNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal PrincipalPayment { get; set; }
        public decimal InterestPayment { get; set; }
        public decimal TotalPayment { get; set; }
        public decimal RemainingAmount { get; set; }
    }
}