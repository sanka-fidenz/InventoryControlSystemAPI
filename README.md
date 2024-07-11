# .NET Core Assignment | Level 02 (Inventory Control System API)

## Run application locally

### Prerequisites:

* [.NET 8.0](https://dotnet.microsoft.com/en-us/download)
* [Visual Studio Code](https://visualstudio.microsoft.com/) (or Visual Studio)
    * C# Dev Kit extension(if you are using Visual Studio Code)
* [PostgreSQL](https://www.postgresql.org/download/) database

### Steps:

* Clone the project
`git clone git@github.com:sanka-fidenz/InventoryControlSystemAPI.git`

* Create a database

* Open using Visual Studio Code(it will automatically install packages)

* Change the `ConnectionStrings.DefaultConnection` value in `appsettings.json` with you DB ConnectionStrings

* Create initial table of database(run migrations) `dotnet ef database update`

* Build application `dotnet run`

### Note:

To test end points a JWT token is required. To generate a token, make `POST` request to `https://localhost:<port>/api/Auth` with following payload (change the port number with the port number your application runs).

```
{
  "username": "Manager", // or Operator
  "password": "password"
}
```

Manager has access to all API endpoint but Operator has only for Product, Category and Inventory related APIs