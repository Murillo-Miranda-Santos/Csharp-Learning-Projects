# LibraryStockUpdater

LibraryStockUpdater is a simple C# console application that connects to a MySQL database to display books and update their stock quantity.

This project was created as a learning exercise to practice database connections, SQL queries, and environment variable management in .NET.

## Technologies Used

- C#
- .NET Console Application
- MySQL
- MySql.Data
- DotNetEnv

## Features

- Connects to a MySQL database
- Lists all books stored in the database
- Allows the user to update the quantity of a book
- Uses environment variables for secure database credentials

## Project Structure

LibraryStockUpdater
│
├── Program.cs  
├── LibraryStockUpdater.csproj  
├── .env.example  
├── .gitignore  
└── README.md  

## Setup

1. Clone the repository

git clone https://github.com/yourusername/LibraryStockUpdater.git

2. Create a `.env` file in the root folder based on `.env.example`

Example:

DB_SERVER=localhost  
DB_DATABASE=library  
DB_USER=your_user  
DB_PASSWORD=your_password  

3. Install dependencies

dotnet restore

4. Run the application

dotnet run

## Learning Goals

This project was created to practice:

- Database connections with MySQL
- SQL queries in C#
- Input validation
- Environment variable management
- Basic project organization

## Author

Murillo Miranda Santos