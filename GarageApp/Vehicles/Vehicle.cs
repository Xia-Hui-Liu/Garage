namespace GarageApp.Vehicles
{
    public class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }

        public string Color { get; set; }

        public int NumberOfWheels { get; set; }

        public Vehicle(string registrationNumber, string color, int numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name}, Registration Number: {RegistrationNumber}, Color: {Color}";
        }
    }
}
