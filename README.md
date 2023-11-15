# AssesmentWebAPI
Assesment Project to demonstrate RESTfull Web API

This is a simple RESTful web API that allows users to perform CRUD operations on a resource.

Overview
This API provides endpoints to manage a collection of users. It follows REST principles and supports the standard HTTP methods:

GET: Retrieve resource(s) or information
POST: Create a new resource
PUT: Update an existing resource
DELETE: Delete a resource

Usage
The API endpoints can be accessed at http://localhost:50306/api.

Here are the available endpoints:

GET /Users: Retrieve all resources
GET /Users/:id: Retrieve a specific resource by ID
POST /Users: Create a new user.
PUT /Users/:id: Update a specific resource by ID
DELETE /Users/:id: Delete a specific resource by ID

Replace :id with the ID of the User you want to manipulate.


Examples: 

1. Reterive all users:
   GET http://localhost:50306/api/Users/GetUsers - JSON Response - List

2. Get User by ID
   GET http://localhost:50306/api/Users/GetUsersByID/1 - JSON Response - Object

3. Create a new user
   POST http://localhost:50306/api/Users/AddUsers - JSON Resonse - String
   body:
   {
        "username": "Someone",
        "email": "Someone@gmail.com",
        "phone_number": "145256352",
        "skillsets": "C#.NET, Python, VBA",
        "hobby": "Driving"
    }

4. Update an existing User:
   PUT http://localhost:50306/api/Users/UpdateUsers
   body:
   {
        "userId": 4,
        "username": "Someone Updated",
        "email": "Someone@gmail.com",
        "phone_number": "455875865",
        "skillsets": "C#.NET, ASP.NET(MVC)",
        "hobby": "Swimming"
    }

5. Delete an existing User
   DELETE http://localhost:50306/api/Users/DeleteUser/4 - JSON Resonse - String