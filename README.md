# Vehicle Rental System

A comprehensive ASP.NET Core MVC web application for managing vehicle rentals with SQL Server database integration.

## Features

✅ **Vehicle Management**
- Add, update, and delete vehicles
- Track vehicle status (Available, Rented, Maintenance)
- Manage daily rental rates

✅ **Customer Management**
- Register and manage customers
- Track driver's license information
- Customer status management

✅ **Rental Management**
- Create rental bookings
- Track active and completed rentals
- Calculate rental costs automatically
- Complete and cancel rentals

✅ **Payment Tracking**
- Record payments for rentals
- Multiple payment methods support
- Payment status management

✅ **User Authentication**
- ASP.NET Core Identity integration
- Secure login and registration
- Role-based access control

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **UI**: ASP.NET Core MVC with Bootstrap 5
- **Database**: SQL Server with Entity Framework Core
- **Authentication**: ASP.NET Core Identity
- **Language**: C#

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server (Express or Full)
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Ayushmaan30/rental-service.git
   cd rental-service
   ```

2. **Update Connection String**
   - Open `appsettings.json`
   - Update the SQL Server connection string
   ```json
   "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=RentalServiceDB;Trusted_Connection=true;Encrypt=false;"
   ```

3. **Run Migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```

5. **Access the Application**
   - Navigate to `https://localhost:5001`
   - Register a new account
   - Start managing your vehicle rental business

## Project Structure

```
RentalService/
├── Models/                 # Database entities
│   ├── Vehicle.cs
│   ├── Customer.cs
│   ├── Rental.cs
│   └── Payment.cs
├── Data/
│   └── ApplicationDbContext.cs    # EF Core DbContext
├── Services/               # Business logic layer
│   ├── VehicleService.cs
│   ├── CustomerService.cs
│   ├── RentalService.cs
│   └── PaymentService.cs
├── Controllers/            # MVC Controllers
│   ├── HomeController.cs
│   ├── VehiclesController.cs
│   ├── CustomersController.cs
│   └── RentalsController.cs
└── Views/                  # Razor Views
    ├── Home/
    ├── Vehicles/
    ├── Customers/
    └── Shared/
```

## Database Schema

### Tables
- **Vehicles**: Store vehicle information
- **Customers**: Store customer details
- **Rentals**: Track rental transactions
- **Payments**: Record payment information
- **AspNetUsers**: User accounts (Identity)

## Key Features

### Automatic Cost Calculation
When creating a rental, the system automatically calculates the total cost based on:
- Number of rental days
- Vehicle daily rate

### Availability Check
Before creating a rental, the system verifies:
- Vehicle is available
- Customer license is valid and not expired
- No conflicting rental bookings

### Status Tracking
- Vehicles: Available, Rented, Maintenance
- Customers: Active, Inactive, Suspended
- Rentals: Active, Completed, Cancelled
- Payments: Pending, Completed, Failed, Refunded

## API Endpoints

### Vehicles
- `GET /Vehicles/Index` - List all vehicles
- `GET /Vehicles/Details/{id}` - Get vehicle details
- `GET /Vehicles/Create` - Create vehicle form
- `POST /Vehicles/Create` - Submit new vehicle
- `GET /Vehicles/Edit/{id}` - Edit vehicle form
- `POST /Vehicles/Edit/{id}` - Update vehicle
- `GET /Vehicles/Delete/{id}` - Delete vehicle form
- `POST /Vehicles/Delete/{id}` - Confirm delete

### Customers
- `GET /Customers/Index` - List all customers
- `GET /Customers/Details/{id}` - Get customer details
- `GET /Customers/Create` - Create customer form
- `POST /Customers/Create` - Submit new customer
- `GET /Customers/Edit/{id}` - Edit customer form
- `POST /Customers/Edit/{id}` - Update customer
- `GET /Customers/Delete/{id}` - Delete customer form
- `POST /Customers/Delete/{id}` - Confirm delete

### Rentals
- `GET /Rentals/Index` - List all rentals
- `GET /Rentals/Details/{id}` - Get rental details
- `GET /Rentals/Create` - Create rental form
- `POST /Rentals/Create` - Submit new rental
- `GET /Rentals/CompleteRental/{id}` - Complete rental form
- `POST /Rentals/CompleteRental` - Finish rental
- `POST /Rentals/CancelRental/{id}` - Cancel rental

## Future Enhancements

- 📊 Advanced reporting and analytics
- 💳 Payment gateway integration (Stripe, PayPal)
- 📧 Email notifications
- 📱 Mobile app
- 🗺️ GPS tracking for rentals
- 📋 Insurance management
- ⭐ Customer reviews and ratings

## License

This project is licensed under the MIT License.

---

**Happy Renting! 🚗**