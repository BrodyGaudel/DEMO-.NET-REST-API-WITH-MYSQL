Certainly, here's the README.md file in English for your C# and .NET REST API application with MySQL for product management:

```markdown
# Product Service REST API

This application is a REST API developed using C#, .NET, and MySQL for product management. It provides basic functionalities such as creating, updating, deleting, and searching for products, along with operations related to categories.

## Prerequisites

Make sure you have the following installed on your machine before starting the application:
- [.NET SDK](https://dotnet.microsoft.com/download)
- [MySQL Server](https://dev.mysql.com/downloads/)

## Database Configuration

1. Create a MySQL database named `product_db`.
2. Update the database connection information in the `OnConfiguring` method of the `ApplicationDbContext.cs` file.

## Running the Application

1. Open a console and navigate to the root directory of the project.
2. Run the following command to restore dependencies: 
   ```bash
   dotnet restore
   ```
3. Run the following command to create and apply migrations to the database:
   ```bash
   dotnet ef database update
   ```
4. Run the application with the command:
   ```bash
   dotnet run
   ```

The API will be available at https://localhost:7061/swagger/index.html .

## Endpoints

- **GET /api/product**: Retrieve the list of all products.
- **GET /api/product/{id}**: Retrieve a product by its ID.
- **POST /api/product**: Create a new product.
- **PUT /api/product/{id}**: Update an existing product.
- **DELETE /api/product/{id}**: Delete a product by its ID.
- **DELETE /api/product/delete-all**: Delete all products.

- **GET /api/product/search?keyword={keyword}**: Search for products by keyword.

Make sure to check the full API documentation for more details on requests and responses.

## Author

Your Name

## License

This project is licensed under the [MIT License](LICENSE).
```