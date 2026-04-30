Here is the updated English version of the documentation, with the **API Endpoints** table adjusted to match the specific routes shown in your Swagger UI image.

---

# Library Management System API

This is a lightweight Web API project built using **.NET 8**, **Entity Framework Core (EF Core)**, and **SQLite**. It provides a full suite of CRUD (Create, Read, Update, Delete) operations for a "Book" entity.

The project follows a **layered architecture**, with business logic encapsulated within a dedicated Service layer (`IBookService` / `BookService`).

---

## Prerequisites

Before running this project, ensure your development environment includes the following:

1.  **.NET 8.0 SDK**: [Download and install .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).
2.  **IDE / Text Editor**: Visual Studio 2022 (recommended) or Visual Studio Code with the C# Dev Kit extension.

---

## Getting Started

This project is designed for **"Zero-Setup" execution**. You do **not** need to install external database software or manually run migration commands to create tables.

### 1. Clone & Navigate
Open your terminal or command prompt and navigate to the project directory (the folder containing the `.csproj` file):
```bash
cd LibraryManagementSystem/LibraryManagementSystem
```

### 2. Run the Application
Execute the following command to start the API:
```bash
dotnet run
```

* **Database**: Upon startup, the application automatically creates a `library.db` SQLite file in the root directory and initializes the schema.
* **Swagger UI**: If running via an IDE or `dotnet run`, your default browser should automatically open to the **Swagger UI** page, allowing you to test the API endpoints immediately.

### 3. Testing the API
You can interact with the API using several methods:
* **Swagger UI (Recommended)**: Navigate to `https://localhost:<port>/swagger` to view interactive documentation.
* **HTTP Files**: Use the included `LibraryManagementSystem.http` file within Visual Studio or VS Code.
* **External Tools**: Use Postman or `curl` to send requests to the endpoints listed below.

---

## API Endpoints

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| **GET** | `/api/Books/GetAllBooks` | Retrieve a list of all books |
| **GET** | `/api/Books/GetBookById/{id}` | Retrieve details for a specific book by ID |
| **GET** | `/api/Books/GetBookByTitle/{title}` | Search for a book by its title |
| **PUT** | `/api/Books/UpdateBook` | Update information for an existing book |
| **POST** | `/api/Books/AddBook` | Add a new book to the library |
| **DELETE** | `/api/Books/DeleteBook/{id}` | Remove a book from the library |

---

## Sample Request Body (POST / PUT)

```json
{ 
  "title": "Book Title 1",
  "author": "Author 1", 
  "description": "New Book",
  "publishDate": "2026-04-30T00:00:00" 
}
```

> **Note:** For the `AddBook` (POST) request, the `id` field should be omitted or set to `0` as the database generates it automatically. For `UpdateBook` (PUT), ensure the `id` in the JSON body matches the record you intend to modify.