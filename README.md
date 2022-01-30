### To run app and tests: 

#### Prerequisites: MySQL
1. Create a MySQL server.
2. Run script ' igs_products.sql' located in root folder to create database and seed.
3. Update "Default" string in appsettings.json to reflect the credentials/settings of your MySQL server. 
4. Run the App as Marketplace_v4 to use ports necessary for postman tests.
6. Swagger tests. 
5. To test in postman, import tests.json found in root, into postman. 

##### Having more time I would have liked to implement:
 - implement a restriction on the Price being a string that needs to be passable as an int.
 - Containerising the app in Docker
 - adding a scrip runner that would use the sql script to recreate the database for testing purposes
 - having different tables being used depending on IsDevelopment value. 