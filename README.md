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

- ADDING SORTING, PAGINATION, AND FILTERING:
