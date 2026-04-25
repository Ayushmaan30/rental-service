using RentalService.Data;
using RentalService.Models;
using Microsoft.EntityFrameworkCore;

namespace RentalService.Services
{
    public class PaymentService
    {
        private readonly ApplicationDbContext _context;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetPaymentsByRentalAsync(int rentalId)
        {
            return await _context.Payments
                .Where(p => p.RentalId == rentalId)
                .ToListAsync();
        }

        public async Task<Payment?> GetPaymentByIdAsync(int id)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalPaidAsync(int rentalId)
        {
            return await _context.Payments
                .Where(p => p.RentalId == rentalId && p.Status == "Completed")
                .SumAsync(p => p.Amount);
        }

        public async Task<bool> IsRentalFullyPaidAsync(int rentalId)
        {
            var rental = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == rentalId);
            if (rental == null) return false;

            var totalPaid = await GetTotalPaidAsync(rentalId);
            return totalPaid >= rental.TotalCost;
        }
    }
}