DEVELOPER NOTES: 
    -Does not account for headers in file, remove headers before placing the file in the CSVInput Directory
    -Singleton Class: Use ParseCSV Method to change files

Dependencies:
    "Microsoft.NET.Test.Sdk" Version="17.6.0"
    "NUnit" Version="3.13.3"
    "NUnit3TestAdapter" Version="4.2.1"
    "NUnit.Analyzers" Version="3.6.1"
    "coverlet.collector" Version="6.0.0"

Set-Up(Visual Studio Code)
    C# Extention
    C# DevKit Extention
    NuGet Package Manager Extention

How to Run: Application
    1. Open Terminal(in dotnet_csvparser directory)
    2. Enter In terminal: dotnet run --project CSVParser

How to Run: Tests
    1. Open Terminal(in dotnet_csvparser directory)
    2. Enter In terminal: dotnet test -v normal

