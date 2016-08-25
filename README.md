# ExecuteAutomationWebApp
This application is used for automating selenium and coded UI frameworks course

#Automation framework development with Selenium C#
https://www.udemy.com/framework-development-with-selenium-csharp-advanced

#Advanced framework development with Coded UI Test 2015
https://www.udemy.com/framework-development-with-cuit

#How to Compile application ?
All you have to do is 

1. Clone the repo or download it
2. Open the project in Visual studio 2013/2015
3. Just build the project and run in any browser of your interest, the application will launch and ready for automation

#Advanced Topic
##What will happen while building project
The project will automatically create database for you in the default database server, since the connection string in Web.config is given as This
```xml
  <connectionStrings>
    <add name="EmployeeDb" connectionString="Data Source=.;initial catalog=EmployeeDB;integrated security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
```

