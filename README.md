## C# Asp dot net core web api
Implementation of the RESTful Web API using Asp.Net core 6 api and EF Core (Entity Framework Core).

---

## Installation
The tools installed on my computer:
Visual Studio 2022
Microsoft SQL Server Express

.NET 6.0 SDK
ASP.NET Core 6.0 Runtime (v6.0.12) - Windows Hosting Bundle
Download Link
https://dotnet.microsoft.com/en-us/download/dotnet/6.0

---

## log4net
Install log4net
1. Go to Tools > NuGet Package Manager > Package Manager Console,
```cmd
Install-Package Microsoft.Extensions.Logging.Log4Net.AspNetCore
```

---

## packages
Microsoft.EntityFrameworkCore
Microsoft.Extensions.Logging.Log4Net.AspNetCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

---

## Migrations
```cmd
Add-Migration v1
Update-Database
```
