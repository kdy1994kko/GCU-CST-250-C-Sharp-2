/*
 * Kevvan Young
 * Programming in C# II
 * 10/20/2025
 * Vehicle Class Library
 * T1 Activity 1
*/

using System.Collections.Generic;
using VehicleClassLibrary.Models;
using VehicleClassLibrary.Services.DataAccessLayer;

namespace VehicleClassLibrary.Services.BusinessLogicLayer
{
    public class StoreLogic
    {
        // Declare class level variables
        private StoreDAO _storeDAO;

        /// <summary>
        /// Default constructor for StoreLogic
        /// </summary>
        public StoreLogic()
        {
            // Initialize the DAO variable
            _storeDAO = new StoreDAO();
        }

        /// <summary>
        /// Get a list of vehicles in the inventory
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetInventory()
        {
            return _storeDAO.GetInventory();
        }

        /// <summary>
        /// Get a list of the vehicles in the users shopping cart
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> GetShoppingCart()
        {
            return _storeDAO.GetShoppingCart();
        }
        
        /// <summary>
        /// Add a new vehicle to the inventory
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int AddVehicleToInventory(VehicleModel vehicle)
        {
            return _storeDAO.AddVehicleToInventory(vehicle);
        }

        /// <summary>
        /// Add a vehicle to the shopping cart based on the vehicles id
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public int AddVehicleToCart(int vehicleId)
        {
            return _storeDAO.AddVehicleToCart(vehicleId);
        }

        /// <summary>
        /// Write the inventory to a text file
        /// </summary>
        public void WriteInventory()
        {
            _storeDAO.WriteInventory();
        }

        /// <summary>
        /// Read the list of vehicles from a text file
        /// </summary>
        /// <returns></returns>
        public List<VehicleModel> ReadInventory()
        {
            return _storeDAO.ReadInventory();
        }

        /// <summary>
        /// Get the total of the users shopping cart and clear the cart
        /// </summary>
        /// <returns></returns>
        public decimal Checkout()
        {
            // Call and return the Checkout method in the DAO
            return _storeDAO.Checkout();
        }
    }
}

