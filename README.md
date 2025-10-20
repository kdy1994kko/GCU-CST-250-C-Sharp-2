==============================================
Car Store Application (.NET Console App)
==============================================

DESCRIPTION: 
------------
This is a C# console-based vehicle storefront application using a clean multi-layer architecture (Models, Business Logic, and Data Access). It allows users to browse, manage, and purchase various vehicle types including Cars, Pickups, and Motorcycles. Inventory is persisted to a local text file.

Key Features:
- Users can:
  - View current vehicle inventory
  - Add vehicles to a shopping cart
  - Checkout and get cart total
- Admins/Developers can:
  - Add vehicles to inventory
  - Persist inventory data to a text file
  - Restore inventory from saved files
- Uses layered design for clean separation of concerns
- Fully tested with xUnit

==============================================
CONTENTS:
---------
1. UML Class Design
2. Application Flowchart
3. C# Classes Included
4. Unit Test Coverage
5. Example Use Case

==============================================
1. UML CLASS DIAGRAM 
---------------------

+-----------------------+
| VehicleModel          |
+-----------------------+
| Id, Make, Model, ...  |
| +ToString()           |
+-----------------------+

+----------------------------+
| CarModel / PickupModel /  |
| MotorcycleModel           |
+----------------------------+
| +ToString() overrides     |
+----------------------------+
<<extend VehicleModel>>

+----------------------------+
| StoreDAO                   |
+----------------------------+
| _inventory, _cart          |
| +AddVehicleToInventory()   |
| +AddVehicleToCart()        |
| +ReadInventory(), Write...|
| +Checkout()                |
+----------------------------+

+----------------------------+
| StoreLogic                 |
+----------------------------+
| +Acts as business layer    |
| +Delegates to DAO          |
+----------------------------+

==============================================
2. FLOWCHART OF USER INTERACTION 
• Ovals (🞅) – Start and End 
• Rectangles (▭) – Processing 
• Parallelograms (⧫) – Input/Output 
• Diamonds (◆) – Decisions
---------------------------------

[🞅 Start]
   |
[▭ Initialize StoreDAO + Logic]
   |
[▭ Load Inventory (if any)]
   |
[⧫ Display Menu]
   |
[◆ Choose Action?]
   |
   +--- View Inventory
   |
   +--- Add Vehicle to Cart
   |
   +--- Checkout
   |
   +--- Write Inventory
   |
   +--- Exit
   |
[◆ Continue?]
   |
   No → [🞅 End]

==============================================
3. C# CLASSES INCLUDED
-------------------------
- `VehicleModel.cs` – Base vehicle class
- `CarModel.cs`, `PickupModel.cs`, `MotorcycleModel.cs` – Specialized vehicles
- `StoreDAO.cs` – Handles inventory/shopping cart, file I/O
- `StoreLogic.cs` – Business logic layer delegating to DAO
- `StoreLogicTests.cs` – Unit tests (xUnit)

==============================================
4. XUNIT TEST COVERAGE
-----------------------
✅ Tested with xUnit

Tested features:
- Adding vehicles to inventory and cart
- Retrieving shopping cart and inventory
- Checkout logic
- Empty state validations

Run via:
- Visual Studio Test Explorer
- `dotnet test` CLI

Dependencies:
- xUnit (`xunit`, `xunit.runner.visualstudio`)

==============================================
5. SAMPLE USAGE
----------------
==== Welcome to the Car Store ====

Available Inventory:
- 1: 2019 Jeep Wrangler with 4 wheels and a 14.7 cubic foot trunk with a convertible top – $27,000.00  
- 2: 2015 Yamaha Bolt with 2 wheels and a 44.1 inch seat without a side car – $8,000.00

→ Add vehicle to cart: Enter ID = 1  
✅ Vehicle added to cart.

→ View cart:  
🛒 1: 2019 Jeep Wrangler – $27,000.00

→ Checkout:  
💰 Total = $27,000.00  
🧹 Cart cleared.

→ Save inventory:  
💾 Inventory written to text file.

==============================================
NOTES:
------
- Inventory saved to `Data/inventory.txt`
- In case of file read errors, system gracefully loads empty inventory
- Multi-layer architecture promotes maintainability and testability
- DataAccessLayer and BusinessLogicLayer are separated for scalability
- You can extend this system to use a database or API in future

==============================================
Kevvan Deion Young  
10/20/25
