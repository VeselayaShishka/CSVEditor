# CSV Editor 

## About 

    Web applicatiom which allows user to upload a Coma Separated Values file, organizes and validates data from it allowing for quick search and sorting of the fields 

## How to use 

  ### DB Initialization 

      terminal in the project root directory and run 

       dotnet ef database update

      Comman will automatically create the CsvEditorDb on your local SQL Server

  ### Running the project

      Project can be started via IDE UI or by executing following command in the terminal 

       dotnet run

  ### Testing application 

      There's two test files for functionality test, both of them located at '/TestCSV's', one of them contains list of correct data and the other one shows Error handling functionality 

      UI gives vast functionality, 

      

## Technologies stack 

    .NET 8 / ASP.NET Core MVC, EntityFramework, MS SQL server(code first approach), HTML+CSS+JavaScript+RazorPages 
