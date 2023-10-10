using GarageApp.Vehicles;

namespace GarageApp.GarageHandler
{
    public interface IHandler
    {
        IEnumerable<IVehicle> GetAllVehicles();
        IVehicle? GetVehicleByRegNum(string regNo);
        Dictionary<string, int> ListVehiclesType();
        void ParkedVehicle(IVehicle vehicle);
        IVehicle? PickedUpVehicle(int index);
        IEnumerable<IVehicle> Search(Func<IVehicle, bool> predicate);
    }
}