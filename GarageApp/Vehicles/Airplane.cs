namespace GarageApp.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }
        public int NumberOfSeats { get; set; }

        public Airplane(string registrationNumber, string color, int numberOfEngines, int numberOfWheels, int numberOfSeats) : base(registrationNumber, color, numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfEngines = numberOfEngines;
            NumberOfSeats = numberOfSeats;
            NumberOfWheels = numberOfWheels;

        }

        public override string ToString()
        {
            return $"{base.ToString()} NumberOfSeats: {NumberOfSeats} NumberOfSeats: {NumberOfSeats}";
        }
    }
}
