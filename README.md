# DocoSoftTestSln

Brief - create a Web API project with the following functionality / features.

• Create a user record  
• Update a user record  
• Get a user record  
• Use a database and a single table to store the user data  
• Use of SOLID practices is encouraged  
• You can use any version of .Net  
• Third-party libraries can be used  
• Unit Test – test your code with any test and isolation framework  
• The project should compile and load any third-party libraries
automatically  

## Solution Description 
### Framework . NET8

Clean Architecture using Repository and UnitOfWork patterns, Dapper (to execute basic sql queries and stored procedure), EntityFramework
Logging provided by Log4Net  
UnitTests of Controller methods, using Moq and various other test libraries  
REST api's performing CRUD operations, and writing to SQL Server DB (dbname: Docosoft)  

## Set-up  
• You will firstly need to create a database on your local SQL Server, called Docosoft (or any name you like, just ensure to update the Connection String accordingly)  
• Once you have created the database, execute the scripts in the DocoSoftTest.Sql\Scripts\User.sql file - these will create the **Users** table and the **GetUserById** stored procedure  
• Next, configure your connection string - you will find it at **\DocoSoftTestSln\DocoSoftTest.Api\appsettings.json**  
It should look something like -  
```
"ConnectionStrings": {
  "DBConnection": "Data Source=Terrys_laptop; Initial Catalog=DocoSoft;Integrated Security=True;TrustServerCertificate=true;"
}  
```

• Set **DocoSoftTest.Api** as your startup prooject  
• Run the solution from Visual Studio  
• You should see the following swagger api load in your browser -  
![image](https://github.com/user-attachments/assets/7159d6e1-d6c2-45a0-8f39-26784a11b975)  
• The app is currently configured to require authentication in order to execute the api methods  
• To do so, you can retrieve the **ApiKey** from **\DocoSoftTestSln\DocoSoftTest.Api\appsettings.json** (current value is cbf7ce96-b100-4fe5-be10-6ffc8c0309fd). The secondary key will also work as it is configured to do so.  
• Here is how to enter the authentication value when authorising on the swaggerui -  
![image](https://github.com/user-attachments/assets/8335ee83-6069-4d87-ba1b-ef82ea2ca91b)  
• Should you have trouble with Authentication, you can remove the need for it by amneding the BaseApiController at **\DocoSoftTestSln\DocoSoftTest.Api\Controllers\BaseApiController.cs**
• Remove the following code, and rebuild the application -  
```  
[TypeFilter(typeof(AuthorizationFilterAttribute))]  
```  
Tis will ensure that you do not need to authorise in order to execute any of the api methods, they will operate anonymously.

• All endpoints should work, you can confirm this by checking the state of the data in your **Users** table in your database  
• If you have any issues, you can contact me at <ins>terrydelahunt@hotmail.com </ins> or on  _0861921808_  

### Best of luck!
   
 


