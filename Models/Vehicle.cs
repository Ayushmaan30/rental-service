namespace RentalService.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public decimal DailyRateUSD { get; set; }
        public string VehicleType { get; set; } = "Car"; // Car, SUV, Van, Truck
        public int Mileage { get; set; }
        public string Status { get; set; } = "Available"; // Available, Rented, Maintenance
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    }
}