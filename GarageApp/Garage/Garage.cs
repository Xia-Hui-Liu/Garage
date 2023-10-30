using GarageApp.Vehicles;
using System.Collections;

namespace GarageApp.Garage
{
    public class Garage<T> : IGarage<T> where T : IVehicle
    {
        private T[] vehicles;
        private int Count { get; set; }
        private int Capacity { get; set; }
        public bool IsFull { get { return Capacity == Count; } }

        public bool IsEmpty { get { return Count == 0; } }

        public Garage(int capacity)
        {
            //Validate capacity!
            vehicles = new T[capacity];
            this.Capacity = capacity;
        }

        public bool AddVehicle(T vehicle)
        {
            //Check if garage is full!
            bool ok = false;

            if (IsFull)
            {
                return ok;
            }
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    ok = true;
                    Count++;
                    break;
                }

            }

            return ok;

        }

        //count--
        public T? RemoveVehicle(int index)
        {
           


            if (index < 0 || index >= vehicles.Length)
            {
                Console.WriteLine("Invalid index.");
                return default;
            }

            if (vehicles[index] != null)
            {
                T? pickedUpVehicle = vehicles[index];
                vehicles[index] = default!; // Remove the vehicle from the spot
                Count--;
                return pickedUpVehicle;
            }

            return default;
        }

        public void PopulateGarage(T[] initialVehicles, int capacity)
        {
            if (initialVehicles.Length > capacity)
            {
                throw new InvalidOperationException("Not enough space in the garage to populate with all initial vehicles.");
            }

            for (int i = 0; i < capacity; i++)
            {
                vehicles[i] = initialVehicles[i];
                Count++;
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in vehicles)
            {
                if (item != null)
                    yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
