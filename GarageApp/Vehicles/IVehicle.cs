namespace GarageApp.Vehicles
{
    public interface IVehicle
    {
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        string RegistrationNumber { get; set; }
    }
}