namespace GarageApp.Vehicles
{
    public class Car : Vehicle
    {
        public string Make { get; set; }
        public int Year { get; set; }

        public Car(string registrationNumber, string color, string make, int year, int numberOfWheels) : base(registrationNumber, color, numberOfWheels)
        {
            Make = make;
            Year = year;
        }

        public override string ToString()
        {
            return $"{base.ToString()} Make: {Make} Year: {Year}";
        }
    }
}
