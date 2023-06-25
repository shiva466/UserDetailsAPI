# UserDetailsAPI

 ### Web Application that anyone to perform CRUD using UserDetailsAPI.


 ### Pre-requisits:
 1. MySql WorkBench  --> https://dev.mysql.com/downloads/workbench/
 2. MySql Server  --> https://dev.mysql.com/downloads/installer/
 3. Visual Studio 2019 or later version
 4. .NET core (3.1)

### Set-up MySql
1. Install MySQL workbench by clicking on '*mysql-workbench-community*'.
2. Install MySQL server by clicking on '*mysql-installer-web-community*'.
3. Make sure you enter the password as '*root*' or please change the connection string as shown in step 6 of SetUp section.
<img width="580" alt="image" src="https://github.com/shiva466/UserDetailsAPI/assets/37341802/90cf9220-aeeb-4b6c-b00f-5d7477ca194e">
4. Open MySQL workbench.
5. Click on Database than click on Connect to Database then click on OK.
6. In the Query copy and paste the code from '*UserDetailsSetup.sql*'.
<img width="675" alt="image" src="https://github.com/shiva466/UserDetailsAPI/assets/37341802/28151f63-c6b3-4179-96a6-c8fa82ebef79">
7. Run the query excuter.

 ### Setup:
 1. Open MySQL Workbench (if the Db is not done in the set-up MySQL section).
 2. Run the '*UserDetailsSetup.sql*' in the query excuter (if the Db is not done in the set-up MySQL section).
 3. Clone the API project.
 4. Right click on the solution and click on build solution.
 5. Check if all the packages are installed
    <p>
    <img width="283" alt="image" src="https://github.com/shiva466/UserDetailsAPI/assets/37341802/d854a688-7df9-49ae-a201-06b438546eff"/>
    </p>
 6. Update the 'connection string' in '*appsettings.json*' (if the Db is not done in the set-up MySQL section).
    <p>
    <img width="914" alt="image" src="https://github.com/shiva466/UserDetailsAPI/assets/37341802/6b7afe6d-ebfc-4523-9ffc-2592893b3617"/>
    </p>
 7. Build the code and run "*IIS Express*"

### Plug-In (Auto installed in the Visual Studio during build process)
 1. Swagger
 2. .Net Core Entity Framework
 3. NUnit
 4. Moq

