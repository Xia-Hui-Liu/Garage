using GarageApp.Vehicles;

namespace GarageApp.GarageHandler
{
    public class DisplayVehicleDto
    {
        public int Index { get; set; }
        public IVehicle Vehicle { get; set; }
    }
}