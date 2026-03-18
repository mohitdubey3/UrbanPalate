**UrbanPalate** is full-stack restaurant website where customers can browse food menus, create accounts, and place orders.

## 🚀 Key Features

* **Interactive Menu Browsing:** Real-time display of available dishes with descriptions and pricing.
* **Session-Based Shopping Cart:** Implemented **ASP.NET Core Sessions** to allow users to add items to a cart and persist data without immediate database writes.
* **Order Management:** Secure checkout process for authenticated users to place and track orders.
* **Inventory & Ingredient Control:** A specialized Admin dashboard to edit menu items and manage raw ingredient availability.
* **Role-Based Access Control (RBAC):** Distinct permissions for "Customer" and "Admin" roles to ensure data security.

## 🛠 Tech Stack

* **Framework:** ASP.NET Core 9.0 (MVC)
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **State Management:** Microsoft.AspNetCore.Session
* **Auth:** ASP.NET Core Identity

## 🏗 Database Logic

The system uses a relational schema where:
* **Orders** are linked to **Users**.
* **Menu Items** are linked to **Ingredients** via a many-to-many relationship.
* **Sessions** handle the temporary state of the Shopping Cart.

## ⚙️ Setup & Installation

1. Clone the repo: `git clone https://github.com/yourusername/RestaurantManagement.git`
2. Configure your SQL Server string in `appsettings.json`.
3. Run `dotnet ef database update` in the terminal.
4. Launch the app using `dotnet run`.
