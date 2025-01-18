
API Endpoints
1. Get All Products
URL: GET /api/product

Response: List of all products.


2. Get Product by ID
URL: GET /api/product/{id}

Response: A single product object.

3. Create Product
URL: POST /api/product

Request Body:
{
    "name": "Product Name",
    "description": "Product Description",
    "price": 10.00,
    "quantity": 100
}
Response: The ID of the created product.



4. Update Product
URL: PUT /api/product/{id}

Request Body:
{
    "name": "Updated Product Name",
    "description": "Updated Description",
    "price": 15.00,
    "quantity": 150
}
Response: No content (HTTP 204) if successful.

5. Delete Product
URL: DELETE /api/product/{id}

Response: No content (HTTP 204) if successful.


--MVC Routes
Index: GET /Products - Displays all products.
Details: GET /Products/Details/{id} - Shows details of a product.
Create: GET /Products/Create and POST /Products/Create - Create a new product.
Edit: GET /Products/Edit/{id} and POST /Products/Edit/{id} - Edit an existing product.
Delete: GET /Products/Delete/{id} and POST /Products/Delete/{id} - Delete a product.


Notes
This application uses AutoMapper to map between database entities and DTOs.
The application supports both MVC and Web API architectures, where you can either use the web interface or interact with the backend via HTTP requests.


Folder Structure
- /APIs
  - Controllers
    - ProductController.cs
      
- /Conigurations layer
  
- /Services
  - ProductService.cs
  - IProductService.cs
- /DAL
  - ProductContext.cs
  - ProductRepository.cs
  - IUnitOfWork.cs
- /Models
  - ProductDto.cs
  - ProductAddDto.cs
  - Product.cs
- /Controllers
  - ProductsController.cs
- /Views
  - Products
    - Index.cshtml
    - Create.cshtml
    - Edit.cshtml
    - Details.cshtml
    - Delete.cshtml
- appsettings.json
- Program.cs
- Startup.cs (if using .NET Core 3.x)
