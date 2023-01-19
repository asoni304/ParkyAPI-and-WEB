# ParkyAPI-and-WEB
This project is a .NET Core 3.0 web application that provides an API for managing information about national parks and trails. It also includes a website that allows users to view and search for national parks and trails, as well as authenticate and consume the API.

Prerequisites

    .NET Core 3.0 SDK or higher
    Visual Studio 2019 or higher
    An internet connection
    
 Clone the repository to your local machine.
   git clone https://github.com/asoni304/ParkyAPI-and-WEB

 Open the solution file NationalParksAndTrails.sln in Visual Studio.

 Build the solution by clicking Build > Build Solution or by pressing Ctrl + Shift + B.

 Run the application by clicking Debug > Start Without Debugging or by pressing Ctrl + F5.
 
 API Endpoints

The API has the following endpoints for managing national parks and trails:

    GET /api/v1/nationalparks: Retrieves a list of all national parks.

    GET /api/v1/nationalparks/{id}: Retrieves a specific national park by ID.

    POST /api/v1/nationalparks: Creates a new national park.

    PUT /api/v1/nationalparks/{id}: Updates an existing national park.

    DELETE /api/v1/nationalparks/{id}: Deletes an existing national park.

    GET /api/v1/trails: Retrieves a list of all trails.

    GET /api/v1/trails/{id}: Retrieves a specific trail by ID.

    POST /api/v1/trails: Creates a new trail.

    PUT /api/v1/trails/{id}: Updates an existing trail.

    DELETE /api/v1/trails/{id}: Deletes an existing trail.

Authentication

The website uses JSON Web Tokens (JWT) for authentication. Users must register and login to access certain pages and consume the API.
Built With

    .NET Core 3.0
    ASP.NET Core
    Entity Framework Core
    JSON Web Tokens
    React
    Bootstrap
    Sql Server Database

Author

    Jean Anderson

Acknowledgments

    National Park Service API for providing the national park data.

License

This project is licensed under the MIT License - see the LICENSE.md file for details.

