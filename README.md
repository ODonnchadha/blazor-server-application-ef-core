## Building a Data-driven Blazor Server Application with EF Core
-  by Thomas Claudius Huber

- CREATING A BLAZOR WEB PROJECT:
    - .NET 8. Visual Studio 2022.
    - Why? Hosting models:
        - Blazor WebAssembly: Client-side. Runs on top of .NET runtime. Uses DOM.
        - Blazor server: Runs on the server. Renders user interface with SignalR.
        - .NET 8. Can decide at the component level.
            - Client-side rendering (CSR:)
                - Interactive WebAssembly.
            - Server-side rendering (SSR:)
                - Static Server. Static HTML is sent to the client.
                - Interactive Server using Blazor Server. SignalR.
            - Interactive auto.
        - Browser: ASP.NET Core Web API. EF Core. Database.
        - Server: EF Core. Database. SignalR. Browser.
            - No need for a seperate Web API.
            - Use EF Core directly within components.
            - Powerful combination for data-driven applications.
            - ALSO: Scaffolder to generate CRUD components using EF Core.

- GENERATING CRUD COMPONENTS USING EF CORE:
    - Create Employee class. Scaffold. Modify Db connection.
    - Package Manager Console:
    ```javascript
        Add-Migration Init
        Update-Database
    ```
    - [Bootstrap Icons](https://icons.getbootstrap.com/)
    - [SVG to CSS converter](https://www.svgbackgrounds.com/tools/svg-to-css/)
    - Validation logic is defined by the class-related annotations.
    ```javascript
        <DataAnnotationsValidator />
        <ValidationSummary class="text-danger" role="alert"/>
        <ValidationMessage For="() => Employee.FirstName" class="text-danger" />
        @rendermode InteractiveServer
    ```
    - NOTE: Data will be fetched and load per each pagination.

- ADDING SORTING, PAGINATION, AND FILTERING:
    - See codebase.

- WORKING WITH RELATED DATA:
    - "Hey compiler. This won't be null."
    ```javascript
        <PropertyColumn Property="employee => employee.Department!.Name" Title="Is Developer" />
    ```
    - `using` variable means that the variable will be disposed at the end of the method.
    ```javascript
        using var context = DbFactory.CreateDbContext();
    ```
    - NOTE: Foreign key is defined as cascading. Employees associated to a deleted department are also deleted within warning.

- PUBLISHING YOUR APP TO AZURE:
    - Code:
        - Right-click within the project context menu and select `publish.`
        - From the context dialog select "Azure."
        - Select "Azure App Service (Linux)."
        - Select a "App Service" instance.
            - Create a new instance.
                - Create a new resource group.
                - Select a new hosting plan. And location. And size.
        - AFter creation, severice is now selected in dialog.
        - Select finish. And we now have a publish profile.
        - Change deployment mode from "framework dependent" to "self- contained." 
            - Ensure that everything the application needs is within the bundle.
        - NOTE: Within properties folder is a publish profiles folder.
        - Right-click within the project context menu and select `publish.`
        - We are ready to publish. But the SQL service dependencies need a bit of work.
    - Set up a database within Azure:
        - Connect to a dependency. Select Azure SQL database.
            - Create new. 
                - Create a database server.
                - Specify a user name and a password.
            - And create.
        - Enter user name and password via the connect to Azure SQL Database dialog.
        - Copy connection string to clipboard.
        - The next button provides a summary.
    - Run the database migrations:
        - Against the *new* Azure dB.
        - Within the Azure UI. Attempt to login. Copy IP address from error.
        - Within set server firewall and specify a firewall rule.
        - Open the app settings. And update the connectionString.
        - Via tools - Package manager. And apply the migrations.
        ```javascript
            Update-Database
        ```
    - Publish the application:
        - Publish button. "Warming up your site."
            - Publish succeeded. Navigate to website.
