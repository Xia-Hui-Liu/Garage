namespace GarageApp.Vehicles
{
    public class Boat : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public int NumberOfEngines { get; set; }
        public double Length { get; set; }

        public Boat(string registrationNumber, string color, int numberOfWheels, int numberOfSeats, double length, int numberOfEngines) : base(registrationNumber, color, numberOfWheels)
        {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfSeats = numberOfSeats;
            Length = length;
            NumberOfWheels = numberOfWheels;
            NumberOfEngines = numberOfEngines;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Length: {Length} NumberOfEngines: {NumberOfEngines}";
        }
    }
}
