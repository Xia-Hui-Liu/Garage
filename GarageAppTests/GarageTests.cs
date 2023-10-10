using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageApp.Garage;
using GarageApp.Vehicles;

namespace GarageApp.Garage.Tests
{
    [TestClass]
    public class GarageTests
    {
        [TestMethod]
        public void AddVehicle_ShouldSucceed()
        {
            // Arrange
            var garage = new Garage<IVehicle>(4);
            var car1 = new Car("abc123", "red", "volvo", 2019, 4);

            // Act
            garage.AddVehicle(car1);

            // Assert
            Assert.IsTrue(garage.Contains(car1));
        }

        [TestMethod]
        public void RemoveVehicle_ShouldSucceed()
        {
            // Arrange
            var garage = new Garage<IVehicle>(4);
            var car1 = new Car("abc123", "red", "volvo", 2019, 4);
            garage.AddVehicle(car1);

            // Act
            garage.RemoveVehicle(0);

            // Assert
            Assert.IsFalse(garage.Contains(car1));
        }

        [TestMethod]
        public void PopulateGarage_ShouldAddVehicles()
        {
            // Arrange
            var garage = new Garage<IVehicle>(4);
            var vehicles = new IVehicle[]
            {
                new Car("abc908", "green", "Toyota", 1989, 4),
                new Boat("ul345", "white", 0, 4, 6, 2),
                new Bus("bs456", "blue", 6, 80, "el"),
            };

            // Act
            garage.PopulateGarage(vehicles);

            // Assert
            Assert.AreEqual(3, vehicles.Length);
            Assert.IsTrue(garage.Contains(vehicles[0]));
            Assert.IsTrue(garage.Contains(vehicles[1]));
            Assert.IsTrue(garage.Contains(vehicles[2]));
        }

        [TestMethod]
        public void GetEnumerator_ShouldReturnAllVehicles()
        {
            // Arrange
            var garage = new Garage<IVehicle>(4);
            var vehicles = new IVehicle[]
            {
                new Car("Car"),
                new Truck("Truck"),
                new Motorcycle("Motorcycle")
            };
            garage.PopulateGarage(vehicles);

            // Act
            var enumerator = garage.GetEnumerator();

            // Assert
            int count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }

            Assert.AreEqual(3, count);
        }
    }
}
