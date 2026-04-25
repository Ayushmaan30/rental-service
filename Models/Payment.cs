namespace RentalService.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string PaymentMethod { get; set; } = "Credit Card"; // Credit Card, Debit Card, Cash, Online
        public string Status { get; set; } = "Completed"; // Pending, Completed, Failed, Refunded
        public string? TransactionId { get; set; }
        public string? Notes { get; set; }

        // Navigation property
        public Rental? Rental { get; set; }
    }
}