# Healthcare Appointment API

## Overview

A .NET-based RESTful API for managing healthcare appointments. This project provides a robust backend system for scheduling, managing, and tracking medical appointments.

## Project Structure

### Database Files
* `appointment.db` & `appointments.db`: SQLite database files storing appointment data

### Configuration Files
* `AppointmentAPI.csproj`: Project configuration file
* `AppointmentAPI.sln`: Solution file for Visual Studio
* `appsettings.Development.json` & `appsettings.json`: Configuration files for different environments
* `Dockerfile`: Container configuration for Docker deployment

### Core Directories
* `/Controllers`: API endpoint implementations
* `/Data`: Data access layer and database context
* `/Migrations`: Database migration files
* `/Models`: Data models and entities
* `/Services`: Business logic implementation
* `/Properties`: Project properties and launch settings

## Getting Started

### Prerequisites
* .NET 6.0 or later
* SQLite

### Installation

1. Clone the repository
2. Navigate to the project directory
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Update the database:
   ```bash
   dotnet ef database update
   ```

### Running the Application
```bash
dotnet run
```

The API will be available at `http://localhost:5000` by default.

## API Documentation

### Available Endpoints
* Managing appointments
* Patient scheduling
* Healthcare provider availability
* Appointment status updates

Detailed API documentation can be found by running the application and navigating to `/swagger`.

## Docker Support

The project includes Docker support for containerized deployment:

```bash
docker build -t healthcare-appointment-api .
docker run -p 8080:80 healthcare-appointment-api
```

## Configuration

Application settings can be modified in:
* `appsettings.json`: Production configuration
* `appsettings.Development.json`: Development configuration

## Project Status

This project is under active development. The current version includes basic appointment management functionality with planned expansions for additional healthcare-specific features.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

---

*For more information, please contact the project maintainers.*
