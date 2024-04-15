1. Prerequisites <a name="prerequisites"></a>

Before running the Todo API, ensure you have the following prerequisites installed on your machine:

    .NET Core SDK
    SQL Server

2. Getting Started <a name="getting-started"></a>

To run the Todo API locally, follow these steps:

    Clone the repository to your local machine.
    Navigate to the project directory.

    locate the Database Folder:
    To install a backed-up database, follow these steps:

    - Locate the backup file (.bak) of the database.
    - Move the backup file to this directory C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup.
    - Open SQL Server Management Studio (SSMS) or a similar tool.
    - Connect to your SQL Server instance.
    - Right-click on Databases in the Object Explorer and select Restore Database.
    - In the Restore Database window, select Device and click the ellipsis (...) to browse for your backup file.
    - Choose the backup file from the root directory or the Database folder and click OK.
    - Click OK to restore the database.
    - Once the restore process completes, verify the connection string in appsettings.json to ensure it matches the restored database.

    -Configure the database connection string in appsettings.json.

    Open a terminal and run the following commands:

    dotnet restore
    dotnet build
    dotnet run

    The API should now be running locally on https://localhost:7134.

3. API Endpoints <a name="api-endpoints"></a>

The Todo API exposes the following endpoints:

    GET /api/TodoRead: Retrieve all TodoItems.
    GET /api/TodoRead/{id}: Retrieve a TodoItem by ID.
    POST /api/Todo: Create a new TodoItem.
    PUT /api/TodoUpdate/{id}: Update a TodoItem by ID.
    DELETE /api/TodoDelete/{id}: Delete a TodoItem by ID.

4. Swagger Documentation <a name="swagger-documentation"></a>

The API documentation is available through Swagger. You can access the Swagger UI at https://localhost:7134/swagger/index.html.
5. Usage Examples <a name="usage-examples"></a>

Here are some examples of how to use the API endpoints:

    To retrieve all TodoItems:

GET https://localhost:7134/api/TodoRead

To create a new TodoItem:


    POST https://localhost:7134/api/Todo

6. Contributing <a name="contributing"></a>

Contributions to the Todo API are welcome.
