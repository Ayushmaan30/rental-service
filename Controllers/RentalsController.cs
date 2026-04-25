using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RentalService.Models;
using RentalService.Services;

namespace RentalService.Controllers
{
    [Authorize]
    public class RentalsController : Controller
    {
        private readonly RentalService.Services.RentalService _rentalService;
        private readonly VehicleService _vehicleService;
        private readonly CustomerService _customerService;

        public RentalsController(RentalService.Services.RentalService rentalService, VehicleService vehicleService, CustomerService customerService)
        {
            _rentalService = rentalService;
            _vehicleService = vehicleService;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return View(rentals);
        }

        public async Task<IActionResult> Details(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            if (rental == null)
                return NotFound();
            return View(rental);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Customers = new SelectList(await _customerService.GetAllCustomersAsync(), "Id", "FirstName");
            ViewBag.Vehicles = new SelectList(await _vehicleService.GetAvailableVehiclesAsync(), "Id", "Model");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rental rental)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _rentalService.CreateRentalAsync(rental);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Customers = new SelectList(await _customerService.GetAllCustomersAsync(), "Id", "FirstName");
            ViewBag.Vehicles = new SelectList(await _vehicleService.GetAvailableVehiclesAsync(), "Id", "Model");
            return View(rental);
        }

        public async Task<IActionResult> CompleteRental(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            if (rental == null)
                return NotFound();
            return View(rental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteRental(int id, int mileageAtEnd)
        {
            try
            {
                await _rentalService.CompleteRentalAsync(id, mileageAtEnd);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            var rental = await _rentalService.GetRentalByIdAsync(id);
            return View(rental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelRental(int id)
        {
            try
            {
                await _rentalService.CancelRentalAsync(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}