# Assignment_App_dotNet
# Task Management Application
This application is a task management system developed with **.NET 9** for the backend and **React** for the frontend. It uses **Clean Architecture**, **CQRS**, **MediatR 13**, **FluentValidation**, and an **InMemory Database** for development purposes.

## Project Structure
**Backend**
  - Domain: entities and business logic
  - Application: commands, queries, and validations
  - Infrastructure: persistence and technical implementations
  - API: controllers and configuration
**Frontend**
  - User interface developed with React
  - Consumes the API to manage tasks

## Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Node.js and npm](https://nodejs.org/)
- A modern browser to access Swagger and the frontend

## Running the Backend
1. Open a terminal in the backend folder.
2. Restore NuGet packages: dotnet restore
Run the API: dotnet run
The API listens on: http://localhost:5225
Endpoints are available via Swagger: http://localhost:5225/swagger/index.html

## Running the Frontend
Open a terminal in the React frontend folder.
Install dependencies: npm install
Start the development server:  npm start
The frontend application will open at: http://localhost:3000
It communicates with the backend on http://localhost:5225 thanks to CORS configuration.

##Main Features
Task creation and display
Backend validation using FluentValidation
CQRS architecture with MediatR 13
Swagger/OpenAPI for API testing
Validation pipeline via ValidationBehavior

##Unit Tests
Unit tests are included to verify business logic and command validations:
Running the tests
Open a terminal in the test project folder (Assignment_App.Tests).
Run the tests: dotnet test
Example of tests
•	Verifying task creation with CreateTaskCommandHandlerTests

##Notes
Docker is not currently configured, but the project can be run locally without it.
The database is in-memory for development purposes (temporary persistence).
All API features are testable via Swagger or the frontend.

This README covers:

How to run the backend and frontend
Ports used
Swagger
Project structure and main features
Notes on Docker and in-memory database
