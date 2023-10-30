using GarageApp.Vehicles;

namespace GarageApp.GarageHandler
{
    public interface IHandler
    {
        IEnumerable<DisplayVehicleDto> GetAllVehicles();
        IVehicle? GetVehicleByRegNum(string regNo);
        bool IsGarageFull();
        IEnumerable<string> ListVehiclesType();
        IEnumerable<IVehicle> NewSearch(VehicleBaseProps props);
        bool ParkedVehicle(IVehicle vehicle);
        IVehicle? PickedUpVehicle(int index);
        IEnumerable<IVehicle> Search(Func<IVehicle, bool> predicate);
    }
}