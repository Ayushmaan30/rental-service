using Microsoft.AspNetCore.Mvc;
using RentalService.Models;
using RentalService.Services;
using System.Diagnostics;

namespace RentalService.Controllers
{
    public class HomeController : Controller
    {
        private readonly VehicleService _vehicleService;
        private readonly RentalService.Services.RentalService _rentalService;

        public HomeController(VehicleService vehicleService, RentalService.Services.RentalService rentalService)
        {
            _vehicleService = vehicleService;
            _rentalService = rentalService;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return View(vehicles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}