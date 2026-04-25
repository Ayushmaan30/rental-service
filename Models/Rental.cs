namespace RentalService.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; } = "Active"; // Active, Completed, Cancelled
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int MileageAtStart { get; set; }
        public int? MileageAtEnd { get; set; }

        // Navigation properties
        public Customer? Customer { get; set; }
        public Vehicle? Vehicle { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}