# CoreWebApi

Scaffold-DbContext "Data Source=localhost;Initial Catalog=CarRepairShopSupportSystemDataBaseCore;Integrated Security=true;POOLING=FALSE;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir MsSqlServerDB/Models -ContextDir MsSqlServerDB -Context MsSqlServerContext


Install-Package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


Arrange:

I want prepare empty migration witch add row to MigrationsHistory table but

EF Core not support: Add-Migration InitialCreate – IgnoreChanges.

I need use

Add-Migration InitialCreate

and comment all code in Up and Down method in InitialCreate migration

Update-Database

Step 1

Change your DbContext to IdentityDbContext

Step 2

Add AspNetCore Identity Services

using Microsoft.AspNetCore.Identity;

services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<MsSqlServerContext>();
  
Step 3

Add Authentication middleware

app.UseAuthentication();

Step 4 

Create Identity Tables

Add-Migration AddingIdentity

Update-Database -Migration AddingIdentity

# Angular

install runtime environment https://nodejs.org/en/

instal tool for generating the basic Angular structure https://cli.angular.io/ 

CMD:

npm cache clean --force (optional)

npm install -g @angular/cli

ng new my-first-project

cd my-first-project

code .

CODE:

Termina -> New Terminal -> npm install <- installing needed dependencies

Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser <-- usefull

ng generate module {YourModuleName} <-- create module

ng generate component {YourComponentName} //optional --module={YourModuleName}

ng serve <-- Compile

ctrl + c <-- stop Compile

ctrl + k + s <- save all
