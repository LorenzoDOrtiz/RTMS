# Resistance Training Management System (RTMS)

## Overview
The Resistance Training Management System (RTMS) is a web application designed to help users effectively manage and track their resistance training workouts. Built with ASP.NET Core and Blazor, RTMS offers a seamless user experience focusing on workout data tracking and real-time updates.

## Features
- **User-Friendly Interface**: Intuitive and responsive design using MudBlazor components.
- **Workout Template Management**: Create, edit, and delete workout templates with multiple exercises.
- **Active Workout Tracking**: Start workouts from templates, track time, and monitor progress.
- **Exercise and Set Management**: Add and manage sets dynamically during workouts.
- **Rest Timer Functionality**: Manage recovery time with built-in rest timers between sets.
- **Workout History and Analytics**: Save and review past workouts to track progress over time.
- **Service-Oriented Architecture**: Follows clean architecture principles for maintainability and scalability.
- **Validation and Error Handling**: Input validation to ensure data integrity and provide user feedback.
- **Modals and Dialogs**: Interactive modals for confirmations and additional information.

## Technologies Used
- **Backend**: ASP.NET Core (latest version)
- **Frontend**: Blazor Server
- **Database**: EFCore and PostgreSQL
- **Component Library**: MudBlazor
- **Hosting**: Azure App Services
- **Version Control**: GitHub

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (latest version)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [PostgreSQL](https://www.postgresql.org/)

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/RTMS.git
   cd RTMS
#### If using vscode
2. Restore the dependencies:
   ```bash
   dotnet restore
3. Set up the database::
    - Update the connection string in appsettings.development.json.
    - Run the database migrations:
   ```bash
   dotnet ef database update

4. Set up the database:
   ```bash
   dotnet run

Open your browser and navigate to https://localhost:7029/ to view the application.

Usage
1. Register or log in to your account.
2. Create workout templates and add exercises.
3. Start an active workout to track progress.
4. Manage sets, including adding or removing exercises.
5. Save workout history for future reference.

## Contributing
Contributions are welcome! Please fork the repository and create a pull request with your changes. For major changes, please open an issue first to discuss what you want to change.

## License
This project is licensed under the MIT License