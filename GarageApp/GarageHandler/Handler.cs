using GarageApp.Garage;
using GarageApp.Vehicles;

namespace GarageApp.GarageHandler
{
    public class Handler : IHandler
    {
        private IGarage<IVehicle> garage;

        public Handler(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);

            var vehicles = new List<IVehicle>()
            {
                new Car("abc123", "green", "Toyota", 1980, 4),
                new Car("abc908", "green", "Toyota", 1989, 4),
                new Boat("ul345", "white", 0, 4, 6, 2),
                new Bus("bs456", "blue", 6, 80, "el"),
                new Motorcycle("mt890", "pink", 2, 3, 3),
                new Motorcycle("mt891", "pink", 3, 3, 4),
                new Airplane("ap90", "white", 3, 4, 250),
            };

            vehicles.ForEach(vehicle => garage.AddVehicle(vehicle));
        }

        public bool ParkedVehicle(IVehicle vehicle)
        {

           return garage.AddVehicle(vehicle);
        }

        public IVehicle? PickedUpVehicle(int index)
        {
            return garage.RemoveVehicle(index);
        }

        public IVehicle? GetVehicleByRegNum(string regNo)
        {
            return garage.FirstOrDefault(v => v.RegistrationNumber.ToLower() == regNo.ToLower());
        }

        public IEnumerable<DisplayVehicleDto> GetAllVehicles()
        {
            return garage.Select((vehicle, index) => new DisplayVehicleDto { Index = index, Vehicle = vehicle });

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
        public IEnumerable<string> ListVehiclesType()
        {
            return garage.GroupBy(v => v.GetType().Name).Select(g => $"Type: {g.Key}, Count: {g.Count()}");
                            //.ToDictionary(g => g.Key, g => g.Count());

           // return vehicleType;
        }

        public bool IsGarageFull()
        {
            return garage.IsFull;
        }

        public IEnumerable<IVehicle> NewSearch(VehicleBaseProps props)
        {
           
            var res = string.IsNullOrEmpty(props.VehicleType) ? garage
                : garage.Where(v => v.GetType().Name == props.VehicleType);

            if (!string.IsNullOrEmpty(props.Color))
            {
                res = res.Where(v => v.Color == props.Color);
            }

            //Nr

            //Regno


            return res.ToList();
        }
    }
}