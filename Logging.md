# Logging
Notes on logging
## Projects that have logging enable (PLEASE UPDATE THIS LIST IF YOU HAVE ENABLED LOGGING IN A PROJECT)
- API
## To enable logging on project
1. check the list, see if its already enable
2. if it is not enabled `cd` into the project folder
3. run command `dotnet add package Serilog; dotnet add package Serilog.Sinks.Console; dotnet add package Serilog.Sinks.File`
4. thats it!
## To use logging
All logs are stored in the `backend/logs/` and are suffixed by the date
### Namespaces
In the file you need to invoke the logger in add the using directive `using Serilog;`
### Logging types
The main two logging functions are:
```csharp
// Used for sending infomational messages
// for example: Log.Information("This API function was called");
Log.Informaion(messageString);
```
and
 ```csharp
// Used for sending error messages
// for example: Log.Error(ex,"This exception happend!!!");
Log.Error(exception,messageString);
```