Set Up Project
Database:
The project is configured to work with an in-memory database, so you don't need to create a database initially. If you want to use a physical database, you can create one by executing the script placed in the specified folder. After that, adjust the connection string in the appsettings.Development.json file to match your new database.

Finally, go to the ServiceCollectionExtensions.cs file, uncomment line 37, and comment out line 38.

You can also create the database using migrations. The migrations are located in the Migrations folder inside the CodereTecnicalTest.Infrastructure project.

ApiKey:
You can check and change the ApiKey in the appsettings.Development.json file.

Technical Decisions
2.1. CQRS (Command Query Responsibility Segregation) Design Pattern:
I used this pattern mainly for scalability and clear separation of concerns. It provides a clear distinction between commands, which define specific actions (e.g., the ManageShowById command fetches the show from the TVmaze API and inserts it into the database), and queries, which retrieve data from the database.

Additionally, this pattern, combined with dependency injection, makes it easier to test processes with mock data.

2.2. API Key in appsettings.Development.json:
Since we don't have different clients with different API Keys, I considered it unnecessary to store the API Key in the database.

2.3. Tests:
I created unit tests for the different Mappers used in the application to ensure the correctness of data translation. Additionally, I created integration tests to verify that the entire workflow functions correctly. These tests include:

One test for the get method.
Another test to verify the process of retrieving data from the TVmaze API, storing it in our database, and then retrieving it.
A test that simulates a scenario where the information of a show changes. It involves calling the process twice, with the mock data from the HttpService changing between calls, and verifying that the show's information is updated in the database.
The final test addresses the possibility that a show may be removed from the TVmaze API. When this occurs, the test checks that the show is also removed from our database.

Ruben Orea Gorriz