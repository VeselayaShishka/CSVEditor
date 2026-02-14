# CSV Editor 

## About 

    Web applicatiom which allows user to upload a Coma Separated Values file, 
    organizes and validates data from it allowing for quick search and sorting of the fields 

## Technologies stack 

    .NET 8 / ASP.NET Core MVC, EntityFramework, MS SQL server(code first approach), HTML+CSS+JavaScript+RazorPages 

## How to use 

  ### DB Initialization 

      open terminal in the project root directory and run 

           dotnet ef database update

      Command will automatically create the CsvEditorDb on your local SQL Server

  ### Running the project

      Project can be started via IDE UI or by executing following command in the terminal 

            dotnet run

  ### Testing application 

      There's two test files for functionality test, both of them located at '/TestCSV's', 
      one of them contains list of correct data and the other one shows Error handling functionality 

      UI gives vast functionality such as: 
            - Adding new CSV's files
            - Filtering by fields(1st click: ascending/ 2nd click: descending/ 3rd click: default)
            - Search bar given, and works with every field
            - Saving updates to the fields 
            - Deleting rows

## Code architecture 

### Backend Logic 

    CSV parsing located at Services/CsvService.cs
    Validation of Birthday/Salary(no characters check)/Married fields located in Services/DataVAlidation.cs
    VAlidation of FullName/Phone/Salary(MAX ammount) fields locaetd in Models/UserRecord.cs and uses EF features

### Frontend Logic 

    Sorting/Searching/Error Handling located in <script> blocks within Views/User/Index.cshtml
