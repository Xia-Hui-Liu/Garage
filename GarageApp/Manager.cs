using GarageApp.UI;
using GarageApp.Vehicles;
using GarageApp.GarageHandler;

namespace GarageApp
{
    public class Manager
    {
        private readonly IUI ui;
        private IHandler? handler;

        public Manager(IUI ui)
        {
            this.ui = ui;
        }

        internal void Run()
        {
            BuildGarage();
            ShowMainMenu();
        }

        private void BuildGarage()
        {
            ui.Print("Enter garage capacity: ");
            var capacity = int.Parse(ui.GetString());

            handler = new Handler(capacity);
        }

        private void ShowMainMenu()
        {
            while (true)
            {
                ui.Print("Please navigate to the Garage through the menu \n(1, 2, 3 , 4 , 5 , 6 , 0)\n"
                   + "\n1. List all parked vehicles"
                   + "\n2. List vehicle types and counts"
                   + "\n3. Find vehicle by registration number"
                   + "\n4. Search vehicle by properties"
                   + "\n5. Park vehicle"
                   + "\n6. Pickup vehicle"
                   + "\n0. Exit the application");

                string choice = ui.GetString();

                switch (choice)
                {
                    case "1":
                        ListAllVehicles();
                        break;
                    case "2":
                        ListVehicleTypes();
                        break;
                    case "3":
                        FindVehicleByRegistrationNumber();
                        break;
                    case "4":
                        SearchVehicleByProperty();
                        break;
                    case "5":
                        ParkVehicle();
                        break;
                    case "6":
                        PickUpVehicle();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        ui.Print("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ListAllVehicles()
        {
            var vehicles = handler!.GetAllVehicles();
            var indexedVehicles = vehicles.Select((vehicle, index) => new { Index = index, Vehicle = vehicle });

            foreach (var indexedVehicle in indexedVehicles)
            {
                ui.Print($"Slot {indexedVehicle.Index + 1}: A {indexedVehicle.Vehicle.Color} {indexedVehicle.Vehicle.GetType().Name} with license plate {indexedVehicle.Vehicle.RegistrationNumber}");
            }
        }

        private void ListVehicleTypes()
        {
            var vehicleCounts = handler!.ListVehiclesType();
            foreach (var entry in vehicleCounts)
            {
                ui.Print($"Type: {entry.Key}, Count: {entry.Value}\n");
                ui.Print($"{entry.Value} {entry.Key}s in the Garage.\n");
            }
        }

        private void FindVehicleByRegistrationNumber()
        {
            ui.Print("Enter registration number: ");
            var regNo = ui.GetString();
            var found = handler!.GetVehicleByRegNum(regNo);
            if (found != null)
            {
                ui.Print(found.ToString()!);
            }
            else
            {
                ui.Print($"Vehicle with registration number {regNo} was not found");
            }
        }

        private void SearchVehicleByProperty()
        {
            
            while (true)
            {
                ui.Print("Please navigate to search from vehicles through the menu by inputting the number \n(1, 2, 3 , 4 , 0)\n"
                        + "\n1. Search vehicles by color and wheels"
                        + "\n2. Search vehicles by type, color and wheels"
                        + "\n3. Search vehicles by type"
                        + "\n4. Search vehicles by color"
                        + "\n0. Exit"
                        );

                string choice = ui.GetString();

                switch (choice)
                {
                    case "1":
                        SearchByColorAndWheels();
                        break;
                    case "2":
                        SearchByTypeColorAndWheels();
                        break;
                    case "3":
                        SearchByType();
                        break;
                    case "4":
                        SearchByColor();
                        break;
                    case "0":
                        return; // Exit the method if the user chooses to go back to the main menu
                    default:
                        ui.Print("Invalid choice. Please try again.");
                        break;
                }
            }
            
        }

        private void SearchByColorAndWheels()
        {
            while (true)
            {
                ui.Print("Enter the property you want to search by (e.g., Color, Wheels): ");
                var property = ui.GetString();

                ui.Print($"Enter the value of {property} you want to search for: ");
                var searchInput = ui.GetString();

                IEnumerable<IVehicle> results;

                switch (property.ToLower())
                {
                    case "color":
                        results = handler!.Search(vehicle => vehicle.Color == searchInput);
                        break;
                    case "wheels":
                        results = handler!.Search(vehicle => vehicle.NumberOfWheels == int.Parse(searchInput));
                        break;
                    default:
                        ui.Print("Invalid property. Please try again.");
                        continue;
                }

                if (results != null && results.Any())
                {
                    // Filter the results further by color and number of wheels
                    ui.Print("Enter the color you want to search for: ");
                    var colorInput = ui.GetString();
                    ui.Print("Enter the number of wheels you want to search for: ");
                    var wheelsInput = int.Parse(ui.GetString());

                    results = results.Where(vehicle => vehicle.Color == colorInput && vehicle.NumberOfWheels == wheelsInput);

                    if (results.Any())
                    {
                        foreach (var result in results)
                        {
                            ui.Print($"{result}");
                        }
                    }
                    else
                    {
                        ui.Print("No results found with the specified color and number of wheels.");
                    }
                }
                else
                {
                    ui.Print("No results found with the specified property and value.");
                }
            }
        }

        private void SearchByTypeColorAndWheels()
        {
            ui.Print("Enter vehicle type (Car/Boat/Bus/Airplane/Motorcycle): ");
            string type = ui.GetString();

            ui.Print("Enter color: ");
            string color = ui.GetString();

            ui.Print("Enter number of wheels: ");
            int numberOfWheels = int.Parse(ui.GetString());

            var results = handler!.Search(vehicle =>
                vehicle.GetType().Name.ToLower() == type.ToLower()
                && vehicle.Color.ToLower() == color.ToLower()
                && vehicle.NumberOfWheels == numberOfWheels
            );

            if (results.Any())
            {
                foreach (var result in results)
                {
                    ui.Print($"Found {result.GetType().Name} in the garage:\n{result}");
                }
            }
            else
            {
                ui.Print("No matching vehicles found.");
            }
        }


        private void SearchByType()
        {
            ui.Print("Enter vehicle type (Car/Boat/Bus/Airplane/Motorcycle): ");
            string type = ui.GetString();

            var results = handler!.Search(vehicle =>
                vehicle.GetType().Name.ToLower() == type.ToLower()
            );

            if (results.Any())
            {
                foreach (var result in results)
                {
                    ui.Print($"{result}");
                }
            }
            else
            {
                ui.Print("No matching vehicles found.");
            }
        }

        private void SearchByColor()
        {
            ui.Print("Enter color: ");
            string color = ui.GetString();

            var results = handler!.Search(vehicle =>
                vehicle.Color.ToLower() == color.ToLower()
            );

            if (results.Any())
            {
                foreach (var result in results)
                {
                    ui.Print($"{result}");
                }
            }
            else
            {
                ui.Print("No matching vehicles found.");
            }
        }

        private void ParkVehicle()
        {
            if (handler == null)
            {
                ui.Print("No garage available. Please build a garage first.");
                return;
            }

            // a method to get the vehicle from the user
            IVehicle vehicle = GetVehicleFromUser()!;

            try
            {
                handler.ParkedVehicle(vehicle);
                ui.Print("Vehicle parked successfully.");
            }
            catch (InvalidOperationException ex)
            {
                ui.Print(ex.Message);
            }
        }

        private IVehicle? PickUpVehicle()
        {
            ui.Print("Enter the index of the vehicle you want to pick up:");
            int index = int.Parse(ui.GetString());

            try
            {
                IVehicle? removedVehicle = handler!.PickedUpVehicle(index);

                if (removedVehicle != null)
                {
                    ui.Print($"A {removedVehicle.GetType().Name} with registration number: {removedVehicle.RegistrationNumber} has been picked up.");
                }
                else
                {
                    ui.Print("Invalid index. No vehicle was picked up.");
                }

                return removedVehicle;
            }
            catch (Exception ex)
            {
                ui.Print(ex.Message);
                return null; // Handle the exception and return null
            }
        }

        private IVehicle? GetVehicleFromUser()
        {
            ui.Print("Enter vehicle details:");

            ui.Print("Registration Number:");
            string registrationNumber = ui.GetString();

            ui.Print("Color:");
            string color = ui.GetString();

            ui.Print("NumberOfWheels:");
            int numberOfWheels = ui.GetInt();

            ui.Print("Vehicle Type (Car/Boat/Bus/Airplane/Motorcycle):");
            string vehicleType = ui.GetString();

            IVehicle vehicle;

            switch (vehicleType.ToLower())
            {
                case "car":
                    ui.Print("year:");
                    int year = ui.GetInt();
                    ui.Print("make:");
                    string make = ui.GetString();
                    vehicle = new Car(registrationNumber, color, make, year, numberOfWheels);
                    break;
                case "boat":
                    ui.Print("Number of Engines:");
                    int boatEngines = ui.GetInt();
                    ui.Print("Number of Seats:");
                    int boatSeats = ui.GetInt();
                    ui.Print("Length:");
                    int length = ui.GetInt();
                    vehicle = new Boat(registrationNumber, color, numberOfWheels, boatSeats, length, boatEngines);
                    break;
                case "bus":
                    ui.Print("Fuel Type:");
                    string fuelType = ui.GetString();
                    ui.Print("Number of Seats:");
                    int busSeats = ui.GetInt();
                    vehicle = new Bus(registrationNumber, color, numberOfWheels, busSeats, fuelType);
                    break;
                case "motorcycle":
                    ui.Print("Number of Engines:");
                    int motorcycleEngines = ui.GetInt();
                    ui.Print("Number of Seats:");
                    int motorcycleSeats = ui.GetInt();
                    vehicle = new Motorcycle(registrationNumber, color, motorcycleEngines, numberOfWheels, motorcycleSeats);
                    break;
                case "airplane":
                    ui.Print("Number of Engines:");
                    int airplaneEngines = ui.GetInt();
                    ui.Print("Number of Seats:");
                    int airplaneSeats = ui.GetInt();
                    vehicle = new Airplane(registrationNumber, color, airplaneEngines, numberOfWheels, airplaneSeats);
                    break;
                default:
                    ui.Print("Invalid vehicle type.");
                    return null;
            }

            return vehicle;
        }
    }
}
