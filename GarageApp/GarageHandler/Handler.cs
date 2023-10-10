using GarageApp.Garage;
using GarageApp.Vehicles;

namespace GarageApp.GarageHandler
{
    public class Handler : IHandler
    {
        private Garage<IVehicle> garage;

        public Handler(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);

            var vehicle = new Vehicle[]
            {
                new Car("abc123", "green", "Toyota", 1980, 4),
                new Car("abc908", "green", "Toyota", 1989, 4),
                new Boat("ul345", "white", 0, 4, 6, 2),
                new Bus("bs456", "blue", 6, 80, "el"),
                new Motorcycle("mt890", "pink", 2, 3, 3),
                new Motorcycle("mt891", "pink", 3, 3, 4),
                new Airplane("ap90", "white", 3, 4, 250),
            };
            garage.PopulateGarage(vehicle);
        }

        public void ParkedVehicle(IVehicle vehicle)
        {
            garage.AddVehicle(vehicle);
        }

        public IVehicle? PickedUpVehicle(int index)
        {
            return garage.RemoveVehicle(index);
        }

        public IVehicle? GetVehicleByRegNum(string regNo)
        {
            return garage.FirstOrDefault(v => v.RegistrationNumber.ToLower() == regNo.ToLower());
        }

        public IEnumerable<IVehicle> GetAllVehicles()
        {
            return garage;
        }

        public IEnumerable<IVehicle> Search(Func<IVehicle, bool> predicate)
        {
            foreach (var vehicle in garage)
            {
                if (vehicle != null && predicate(vehicle))
                {
                    yield return vehicle;
                }
            }
        }
        public Dictionary<string, int> ListVehiclesType()
        {
            var vehicleType = garage.GroupBy(v => v.GetType().Name)
                            .ToDictionary(g => g.Key, g => g.Count());

            return vehicleType;
        }

    }
}