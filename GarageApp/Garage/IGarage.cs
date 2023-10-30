
using GarageApp.Vehicles;
using System.Collections;

namespace GarageApp.Garage
{

    public interface IGarage<T> : IEnumerable<T>
    {
        bool AddVehicle(T vehicle);

        T? RemoveVehicle(int index);
        bool IsFull { get; }

    }


    //public class EFGarage<T> : IGarage<T>
    //{
    //    private readonly ApplicationDbContext context;

    //    public bool IsFull { get; }


    //    public EFGarage(ApplicationDbContext context)
    //    {
    //        this.context = context;
    //    }

    //    public bool AddVehicle(T vehicle)
    //    {
    //        context.Vehicles.Add(vehicle);
    //        context.SaveChanges();
    //    }
    //    public T? RemoveVehicle(int index)
    //    {
    //        var v = context.Vehicles.FirstOrDEfault(v => v.Id == index);
    //        context.Vehicles.Remove(v);
    //        context.SaveChanges();
    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }


    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}