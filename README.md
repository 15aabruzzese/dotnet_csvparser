# .NET 8.0 CSV Parser Application

## Developer Notes

- **Headers in File**: The application does not account for headers in the file. Please remove headers before placing the file in the CSVInput Directory.
- **Singleton Class**: Use the `ParseCSV` method to change files.

## Dependencies

The project relies on the following dependencies:

- `Microsoft.NET.Test.Sdk`, Version 17.6.0
- `NUnit`, Version 3.13.3
- `NUnit3TestAdapter`, Version 4.2.1
- `NUnit.Analyzers`, Version 3.6.1
- `coverlet.collector`, Version 6.0.0

## Set-Up in Visual Studio Code

To set up the project in Visual Studio Code, ensure the following extensions are installed:

- C# Extension
- C# DevKit Extension
- NuGet Package Manager Extension

## How to Run the Application

1. Open Terminal (make sure you are in the `dotnet_csvparser` directory).
2. Enter in the terminal: `dotnet run --project CSVParser`

## How to Run Tests

1. Open Terminal (make sure you are in the `dotnet_csvparser` directory).
2. Enter in the terminal: `dotnet test -v normal`
