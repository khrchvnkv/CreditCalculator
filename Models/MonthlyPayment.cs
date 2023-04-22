namespace CreditCalculator.Models
{
    public class MonthlyPayment
    {
        public int PaymentNumber { get; set; }
        public DateTime DateOfPayment { get; set; }
        public decimal BodyPayment { get; set; }
        public decimal PercentsPayment { get; set; }
        public decimal RemainingAmount { get; set; }
    }
}