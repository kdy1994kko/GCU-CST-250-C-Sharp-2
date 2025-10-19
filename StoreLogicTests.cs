/*
 * Kevvan Young
 * Programming in C# II
 * 10/20/2025
 * Vehicle Class Library
 * T1 Activity 1
*/

using System.Collections.Generic;
using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.BusinessLogicLayer;
using Xunit;

namespace VehicleClassLibrary.Tests
{
    public class StoreLogicTests
    {
        // Mark this method as a unit test using the [Fact] attribute from xUnit
        [Fact]
        public void AddVehicleToInventory_ShouldIncreaseInventoryCount()
        {
            // Arrange: Create an instance of StoreLogic (System Under Test – SUT)
            StoreLogic store = new StoreLogic();

            // Create a new CarModel object to add to inventory
            CarModel car = new CarModel
            {
                Id = 1,
                Make = "Toyota",
                Model = "Camry",
                Year = 2020,
                Price = 25000m,
                NumWheels = 4,
                IsConvertible = true,
                TrunkSize = 2.5m
            };

            // Act: Add the vehicle to the inventory
           // store.AddVehicleToInventory(car);

            // Retrieve the current inventory
            List<VehicleModel> inventory = store.GetInventory();

            // Assert: Verify that the vehicle was added to inventory
            Assert.Contains(car, inventory);
        }

        // Test for GetInventory when no vehicles have been added
        [Fact]
        public void GetInventory_ShouldReturnEmptyList_WhenNoVehiclesAdded()
        {
            // Arrange: Create an instance of StoreLogic
            StoreLogic store = new StoreLogic();

            // Act: Retrieve the inventory without adding any vehicles
            List<VehicleModel> inventory = store.GetInventory();

            // Assert: The inventory should be empty
            Assert.Empty(inventory);
        } 

        // Test adding a vehicle to the shopping cart
        [Fact]
        public void AddVehicleToCart_ShouldAddVehicle_WhenValidVehicleIdGiven()
        {
            // Arrange: Create an instance of StoreLogic
            StoreLogic store = new StoreLogic();

            // Create and add a vehicle to the inventory
            CarModel car = new CarModel
            {
                Id = 1,
                Make = "Honda",
                Model = "Civic",
                Year = 2019,
                Price = 20000m,
                NumWheels = 4,
                IsConvertible = true,
                TrunkSize = 2.5m
            };

           //# store.AddVehicleToInventory(car);

            // Act: Add the vehicle to the shopping cart using its VehicleId
           //# int result = store.AddVehicleToCart(car.Id);

            // Retrieve the shopping cart contents
            List<VehicleModel> cart = store.GetShoppingCart();

            // Assert: Verify that AddVehicleToCart returned success (assumed to be 1)
           //# Assert.Equal(1, result);

            // Assert: Verify that the cart contains the correct vehicle
            Assert.Contains(cart, verify => verify.Id == car.Id);
        }

        // Test that GetShoppingCart returns an empty list when no vehicles are added
        [Fact]
        public void GetShoppingCart_ShouldReturnEmptyList_WhenNoVehiclesAdded()
        {
            // Arrange: Create an instance of StoreLogic
            StoreLogic store = new StoreLogic();

            // Act: Retrieve the shopping cart without adding any vehicles
            List<VehicleModel> cart = store.GetShoppingCart();

            // Assert: The shopping cart should be empty
            Assert.Empty(cart);
        }

        // Test that Checkout returns the correct total and clears the shopping cart
        [Fact]
        public void Checkout_ShouldReturnCorrectTotal_AndClearCart()
        {
            // Arrange: Create an instance of StoreLogic
            StoreLogic store = new StoreLogic();

            // Create two vehicles to add to inventory and cart
            CarModel car1 = new CarModel
            {
                Id = 3,
                Make = "Ford",
                Model = "F-150",
                Year = 2021,
                Price = 40000m,
                NumWheels = 4,
                IsConvertible = true,
                TrunkSize = 2.5m
            };

            CarModel car2 = new CarModel
            {
                Id = 4,
                Make = "Chevrolet",
                Model = "Silverado",
                Year = 2022,
                Price = 45000m,
                NumWheels = 4,
                IsConvertible = true,
                TrunkSize = 2.5m
            };

            // Add both vehicles to inventory
            store.AddVehicleToInventory(car1);
            store.AddVehicleToInventory(car2);

            // Add both vehicles to the shopping cart
            store.AddVehicleToCart(car1.Id);
            store.AddVehicleToCart(car2.Id);

            // Act: Perform the checkout operation
            decimal total = store.Checkout();

            // Retrieve the shopping cart contents after checkout
            List<VehicleModel> cartAfterCheckout = store.GetShoppingCart();

            // Assert: Verify that the total is approximately correct
            // (Allowing small variance for business logic such as discounts, taxes, etc.)
            Assert.True(total >= (car1.Price + car2.Price) * 0.95m);
            Assert.True(total <= (car1.Price + car2.Price) * 1.05m);

            // Assert: Verify that the shopping cart is now empty after checkout
            Assert.Empty(cartAfterCheckout);
        }
    }
}

