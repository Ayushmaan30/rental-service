using RentalService.Data;
using RentalService.Models;
using Microsoft.EntityFrameworkCore;

namespace RentalService.Services
{
    public class RentalService
    {
        private readonly ApplicationDbContext _context;
        private readonly VehicleService _vehicleService;
        private readonly CustomerService _customerService;

        public RentalService(ApplicationDbContext context, VehicleService vehicleService, CustomerService customerService)
        {
            _context = context;
            _vehicleService = vehicleService;
            _customerService = customerService;
        }

        public async Task<List<Rental>> GetAllRentalsAsync()
        {
            return await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Vehicle)
                .ToListAsync();
        }

        public async Task<Rental?> GetRentalByIdAsync(int id)
        {
            return await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Vehicle)
                .Include(r => r.Payments)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Rental> CreateRentalAsync(Rental rental)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(rental.VehicleId);
            if (vehicle == null || vehicle.Status != "Available")
                throw new InvalidOperationException("Vehicle is not available for rental.");

            var customer = await _customerService.GetCustomerByIdAsync(rental.CustomerId);
            if (customer == null)
                throw new InvalidOperationException("Customer not found.");

            if (!await _customerService.IsLicenseValidAsync(rental.CustomerId))
                throw new InvalidOperationException("Customer license is invalid or expired.");

            // Calculate total cost
            var days = (rental.RentalEndDate - rental.RentalStartDate).Days;
            rental.TotalCost = days * vehicle.DailyRateUSD;
            rental.MileageAtStart = vehicle.Mileage;

            // Update vehicle status
            vehicle.Status = "Rented";
            await _vehicleService.UpdateVehicleAsync(vehicle);

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
            return rental;
        }

        public async Task CompleteRentalAsync(int rentalId, int mileageAtEnd)
        {
            var rental = await GetRentalByIdAsync(rentalId);
            if (rental == null)
                throw new InvalidOperationException("Rental not found.");

            rental.ActualReturnDate = DateTime.UtcNow;
            rental.Status = "Completed";
            rental.MileageAtEnd = mileageAtEnd;

            if (rental.Vehicle != null)
            {
                rental.Vehicle.Mileage = mileageAtEnd;
                rental.Vehicle.Status = "Available";
                _context.Vehicles.Update(rental.Vehicle);
            }

            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task CancelRentalAsync(int rentalId)
        {
            var rental = await GetRentalByIdAsync(rentalId);
            if (rental == null)
                throw new InvalidOperationException("Rental not found.");

            rental.Status = "Cancelled";

            if (rental.Vehicle != null)
            {
                rental.Vehicle.Status = "Available";
                _context.Vehicles.Update(rental.Vehicle);
            }

            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }
    }
}