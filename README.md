Healthcare Appointment API
A .NET-based RESTful API for managing healthcare appointments. This project provides a robust backend system for scheduling, managing, and tracking medical appointments.
Project Structure

appointment.db & appointments.db: SQLite database files storing appointment data
AppointmentAPI.csproj: Project configuration file
AppointmentAPI.sln: Solution file for Visual Studio
appsettings.Development.json & appsettings.json: Configuration files for different environments
Dockerfile: Container configuration for Docker deployment

Core Directories

/Controllers: API endpoint implementations
/Data: Data access layer and database context
/Migrations: Database migration files
/Models: Data models and entities
/Services: Business logic implementation
/Properties: Project properties and launch settings

Getting Started
Prerequisites

.NET 6.0 or later
SQLite

Installation

Clone the repository
Navigate to the project directory
Restore dependencies:
bashCopydotnet restore

Update the database:
bashCopydotnet ef database update


Running the Application
bashCopydotnet run
The API will be available at http://localhost:5000 by default.
API Documentation
The API provides endpoints for:

Managing appointments
Patient scheduling
Healthcare provider availability
Appointment status updates

Detailed API documentation can be found by running the application and navigating to /swagger.
Docker Support
The project includes Docker support for containerized deployment:
bashCopydocker build -t healthcare-appointment-api .
docker run -p 8080:80 healthcare-appointment-api
Configuration
Application settings can be modified in:

appsettings.json: Production configuration
appsettings.Development.json: Development configuration

Project Status
This project is under active development. The current version includes basic appointment management functionality with planned expansions for additional healthcare-specific features.
Contributing

Fork the repository
Create a feature branch
Commit your changes
Push to the branch
Open a Pull Request
