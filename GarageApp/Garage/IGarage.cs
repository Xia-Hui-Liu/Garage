
using GarageApp.Vehicles;

namespace GarageApp.Garage
{

    public interface IGarage<T> : IEnumerable<T>
    {
        void AddVehicle(T vehicle);

        T? RemoveVehicle(int index);

    }
}