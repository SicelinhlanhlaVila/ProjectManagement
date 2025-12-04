📘 .NET 8 In-Memory API

A simple and clean .NET 8 Web API that demonstrates how to build CRUD endpoints using Entity Framework Core In-Memory Database.
This project will be used to learn react SPA.

🚀 Features

✔️ Built with .NET 8

✔️ Uses EF Core In-Memory Database (no installation needed)

✔️ Clean separation of Models, Data, and Controllers

✔️ Fully documented API endpoints

✔️ Ready to extend into a SQL-backed API later

🧰 Technologies Used
Technology	Purpose
.NET 8 Web API	Backend framework
Entity Framework Core InMemory	Lightweight database for development/testing
C# 12	Programming language
Swagger / Swashbuckle	Auto-generated API documentation
🗂 Project Structure
/Controllers
    ProjectsController.cs
    ProfileController.cs
    SkillsController.cs
/Data
    AppDbContext.cs
/Models
    Project.cs
    Profile.cs
    Skill.cs
Program.cs
README.md

🧠 In-Memory Database Explanation

This project uses EF Core’s In-Memory provider:

services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

What this means:

👍 No SQL Server or PostgreSQL required

🔄 Data resets each time the API restarts

🧪 Perfect for demos and automated tests

⚡ Faster development cycle

📡 API Endpoints
📍 GET /api/projects

Fetch all projects.

Response:

[
  {
    "id": 1,
    "name": "Project Alpha",
    "description": "Sample project"
  }
]

➕ POST /api/projects

Create a new project.

Request Body Example:

{
  "name": "New Project",
  "description": "Something cool"
}


Behavior:

Assigns an auto-generated ID.

Saves to in-memory storage.

✏️ PUT /api/projects/{id}

Update a project by its ID.

Example:

PUT /api/projects/3


Body:

{
  "name": "Updated Project",
  "description": "Updated description"
}


Returns 404 if the project does not exist.

👤 GET /api/profile

Returns developer profile information.

Response Example:

{
  "fullName": "John Doe",
  "title": "Software Developer",
  "bio": "6 years of experience..."
}

💡 GET /api/skills

Returns a list of skills.

Response Example:

[
  { "name": "C#", "level": "Advanced" },
  { "name": "SQL", "level": "Intermediate" }
]

▶️ Getting Started
1. Prerequisites

Make sure you have:

.NET 8 SDK
Download from: https://dotnet.microsoft.com/

2. Clone the Repository
git clone https://github.com/yourusername/yourrepo.git
cd yourrepo

3. Run the API
dotnet run


The API will start on a URL similar to:

https://localhost:5001

4. Open Swagger UI

If Swagger is enabled:

https://localhost:5001/swagger


Swagger provides:

Interactive testing

Schema documentation

Request/response samples

🧪 Testing the API

You can test using:

Swagger UI

Postman

CURL

Example CURL command:

curl https://localhost:5001/api/projects

📷 Screenshots (Optional)

You can add screenshots such as:

Swagger UI

Project structure

Sample requests

Example placeholder:

![Swagger Screenshot](./screenshots/swagger.png)

🤝 Contributing

Pull requests are welcome!

To contribute:

Fork the repo

Create a new branch

Commit your changes

Create a pull request

📄 License

You can choose one:

MIT (recommended for open projects)

Apache 2.0

GPL

Example:

This project is licensed under the MIT License.
