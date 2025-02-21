# Book Management API

## Overview
Book Management API is a RESTful web service that allows users to manage books and authors, along with user authentication and authorization using JWT tokens.

## Features
- User authentication (Register, Login)
- JWT-based authentication and authorization
- CRUD operations for books and authors
- Secure API endpoints with access control

## Technologies Used
- ASP.NET Core
- Entity Framework Core
- JWT Authentication
- PostgreSQL (or any configured database)
- Swagger for API documentation

## Installation
### Prerequisites
- .NET 8
- PostgreSQL (or any compatible database)
- Visual Studio / VS Code

### Steps to Run
1. Clone the repository:
   ```sh
   https://github.com/sanjar1999/Book-Management.git
   ```
2. Update the `appsettings.json` file with your database connection string and JWT secret key.
3. Run database migrations:
   ```sh
   dotnet ef database update
   ```
4. Run the application:
   ```sh
   dotnet run
   ```
5. Access the Swagger UI at `https://localhost:xxxx/swagger/index.html`.

## API Endpoints
### Authentication
- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Authenticate a user and return JWT

### Authors
- `GET /api/authors` - Retrieve all authors
- `GET /api/authors/{id}` - Retrieve a specific author
- `POST /api/authors` - Add a new author
- `PUT /api/authors` - Update an author
- `DELETE /api/authors/{id}` - Delete an author

## Authentication
All protected endpoints require a valid JWT token. Include the token in the `Authorization` header:
```sh
Authorization: YOUR_JWT_TOKEN
```

## Contributing
1. Fork the repository
2. Create a new branch (`feature-branch`)
3. Commit your changes
4. Push to the branch
5. Create a pull request

## License
This project is licensed under the MIT License.

