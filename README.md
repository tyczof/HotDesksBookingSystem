# Hot Desk Booking System

## Description

The Hot Desk Booking System is designed to automate the reservation of desks in an office through an easy-to-use online booking system. 
The system provides functionalities for managing desk locations, booking desks, and handling reservations efficiently.

## Project Structure

- **HotDesks**: Backend (API)
- **HotDesks.Test**: Tests
- **hot-desks-front**: Frontend

The solution file `HotDesks.sln` is located in the root folder.

## Technologies

- **Backend**: .NET 8, SQL Server
- **Frontend**: Angular CLI 18.2.4, Node 20.17.0, npm 10.8.3
- **Operating System**: Windows 32 x64

## Installation

### Backend
1. Clone the repository:
    ```bash
    git clone https://github.com/tyczof/HotDesksBookingSystem.git
    ```
2. Navigate to the root directory:
    ```bash
    cd HotDesks
    ```
3. Restore dependencies:
    ```bash
    dotnet restore
    ```
4. Configure the database connection in `appsettings.json`.
5. Apply database migrations:
    ```bash
    dotnet ef database update
    ```
6. Run the API:
    ```bash
    dotnet run
    ```

### Frontend
1. Navigate to the frontend directory:
    ```bash
    cd HotDesks/hot-desks-front
    ```
2. Install dependencies:
    ```bash
    npm install
    ```
3. Start the Angular application:
    ```bash
    ng serve
    ```
4. Open your browser and go to `http://localhost:4200`.

## Usage

After starting the backend and frontend application, access the homepage at `http://localhost:4200`.

## Testing

To run unit tests for the backend, use `dotnet test` in the `HotDesks` directory.
