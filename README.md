# Ticket Support System

A **Customer Support Ticket Management System** built with ASP.NET Core Web API. Customers can raise support tickets, agents get assigned to them, comments can be added for communication, and ticket statuses are tracked throughout the lifecycle.

---

## Features

- Raise and manage support tickets
- Assign tickets to support agents
- Add comments on tickets for back-and-forth communication
- Track assignment status per ticket
- RESTful API with full Swagger documentation
- Clean layered architecture — Controllers, Services, Repositories

---

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core Web API (.NET 8) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Documentation | Swagger / OpenAPI |
| Language | C# |

---

## Project Structure

```
Ticket-Support-System/
│
├── Ticket Module/              # Ticket entity, repository, service, controller
├── Comment Module/             # Comment entity, repository, service, controller
├── Migrations/                 # EF Core database migrations
├── Properties/                 # Launch settings
├── Program.cs                  # App entry point, DI registration
├── appsettings.example.json    # Example config (copy to appsettings.json)
└── Ticket-Management.csproj    # Project file
```

---

## Modules

**Ticket Module** — core of the system. Handles creating, reading, updating, and deleting support tickets. Each ticket can be assigned to a user and carries a status.

**Comment Module** — allows customers and agents to add comments to a ticket, enabling communication within the system.

**Assignment** — links a ticket to a support agent. One ticket can be assigned to one agent at a time.

**Status** — tracks the current state of an assignment (e.g. Open, In Progress, Resolved).

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local or remote)
- Visual Studio 2022 or VS Code

### Setup

**1. Clone the repository**
```bash
git clone https://github.com/vikramjitsingh1/Ticket-Support-System.git
cd Ticket-Support-System
```

**2. Configure the database connection**

Copy the example config and fill in your connection string:
```bash
cp appsettings.example.json appsettings.json
```

Edit `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=TicketDB;Trusted_Connection=True;"
  }
}
```

**3. Apply migrations**
```bash
dotnet ef database update
```

**4. Run the project**
```bash
dotnet run
```

**5. Open Swagger UI**

Navigate to `https://localhost:{port}/swagger` to explore and test all endpoints.

---

## API Overview

| Module | Endpoints |
|---|---|
| Tickets | CRUD operations on support tickets |
| Comments | Add and retrieve comments per ticket |
| Users | Manage customer and agent accounts |
| Assignments | Assign tickets to agents |
| Status | Update and track assignment status |

Full interactive documentation is available via Swagger at runtime.

---

## Dependency Injection

All services and repositories are registered in `Program.cs` using the Scoped lifetime:

```csharp
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAssignmentService, AssignmentService>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
```

---

## Database Relationships

- `Ticket` ← one-to-many → `Assignment`
- `User` ← one-to-many → `Assignment`
- `Assignment` ← one-to-one → `Status`
- `Ticket` ← one-to-many → `Comment`

---

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

---

## License

This project is open source and available under the [MIT License](LICENSE).

---

<div align="center">

Developed with dedication by **Vikramjit Singh**

[GitHub](https://github.com/vikramjitsingh1)

</div>
