namespace CreditCalculator.Models
{
    public class CreditInfo
    {
        public enum CalculationType
        {
            Annuity = 1,
            Differentiated = 2
        }
        
        public decimal TotalSum { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfClosing { get; set; }
        public float Percent { get; set; }
        public CalculationType CreditType { get; set; }
        public int PaymentDay { get; set; }
    }
}