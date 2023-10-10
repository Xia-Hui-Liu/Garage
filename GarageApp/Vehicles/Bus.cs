using System.Drawing;

namespace GarageApp.Vehicles
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public string? Fueltype { get; set; }

        public Bus(string registrationNumber, string color, int numberOfWheels, int numberOfSeats, string? fueltype) : base(registrationNumber, color, numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;
            NumberOfSeats = numberOfSeats;
            Fueltype = fueltype;
        }

        public override string ToString()
        {
            return $"{base.ToString()} NumberOfSeats: {NumberOfSeats} Fueltype: {Fueltype}";
        }
    }
}
