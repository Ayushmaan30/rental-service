namespace RentalService.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime LicenseExpiryDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Active"; // Active, Inactive, Suspended

        // Navigation property
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}