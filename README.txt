Instructions for Installing the Database

Prerequisites:
- .NET Core SDK
- SQL Server

Steps:
1. Open a command prompt or terminal.
2. Navigate to the root directory of the API project.
3. Update the connection string in the `appsettings.json` file to point to your local database server. For example:
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=CanvasDatabase;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
4. Run the following command to create the database and apply the migrations:
   dotnet ef database update

If the command executes successfully, the database will be set up with the latest schema defined in the migrations.