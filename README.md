# 🏠 StockHouse - Inventory Management System

A modern, distributed inventory management solution built with .NET 9, Clean Architecture, and React frontend integration.

## 📋 Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Technologies](#technologies)
- [Features](#features)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Database Schema](#database-schema)
- [Development](#development)
- [Deployment](#deployment)
- [Contributing](#contributing)

## 🎯 Overview

StockHouse is a comprehensive inventory management system designed to handle stock operations, product categorization, and inventory tracking. The system follows Clean Architecture principles with CQRS pattern implementation using MediatR.

### Key Components:
- **Backend API**: .NET 9 Web API with minimal APIs
- **Frontend**: React application (StockHouse-UI)
- **Database**: PostgreSQL for data persistence
- **Caching**: Redis for performance optimization
- **Orchestration**: .NET Aspire for service management

## 🏗️ Architecture

The solution follows **Clean Architecture** with the following layers:

```
┌─────────────────────────────────────────┐
│               StockHouse.AppHost        │  ← Aspire Host
├─────────────────────────────────────────┤
│            StockInventoryService        │  ← API Layer
├─────────────────────────────────────────┤
│         StockInventoryApplication       │  ← Application Layer
│         (Commands, Queries, DTOs)       │
├─────────────────────────────────────────┤
│           StockInventoryDomain          │  ← Domain Layer
│         (Entities, Interfaces)          │
├─────────────────────────────────────────┤
│        StockInventoryInfrastructure     │  ← Infrastructure Layer
│         (EF Core, Repositories)         │
└─────────────────────────────────────────┘
```

### Design Patterns:
- **CQRS (Command Query Responsibility Segregation)**
- **Repository Pattern**
- **Unit of Work Pattern**
- **Mediator Pattern** (via MediatR)
- **Soft Delete Pattern**

## 🛠️ Technologies

### Backend Stack:
- **.NET 9** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API development
- **Entity Framework Core** - ORM for database operations
- **PostgreSQL** - Primary database
- **Redis** - Caching and session storage
- **MediatR** - CQRS and Mediator pattern implementation
- **AutoMapper** - Object-to-object mapping
- **Docker** - Containerization

### Frontend Stack:
- **React** - Frontend framework
- **Vite** - Build tool and development server

### Infrastructure:
- **.NET Aspire** - Distributed application orchestration
- **Docker Compose** - Container orchestration
- **Swagger/OpenAPI** - API documentation

## ✨ Features

### 📦 Product Management
- Create, read, update, and delete products
- Product categorization
- SKU management
- Price tracking
- Unit of measure (UOM) support

### 📂 Category Management
- Hierarchical category structure
- Category codes and descriptions
- Sort order management
- Active/inactive status

### 📊 Inventory Management
- Real-time stock tracking
- Quantity management
- Product-based inventory
- Inventory status monitoring

### 🔧 System Features
- **Soft Delete**: Logical deletion with recovery capability
- **Audit Trail**: Created/Updated timestamps and user tracking
- **Health Checks**: Service health monitoring
- **CORS Support**: Cross-origin resource sharing
- **Caching**: Redis-based caching for performance
- **Logging**: Comprehensive logging with behaviors
- **Validation**: Request validation and error handling

## 🚀 Getting Started

### Prerequisites
- **.NET 9 SDK**
- **Docker Desktop**
- **Node.js** (for frontend)
- **PostgreSQL** (or use Docker)
- **Redis** (or use Docker)

### Quick Start

1. **Clone the repository**
   ```bash
   git clone https://github.com/tansudev/StockHouse.git
   cd StockHouse
   ```

2. **Start infrastructure services**
   ```bash
   docker-compose up -d
   ```

3. **Update database schema**
   ```bash
   cd StockInventoryProject/StockInventoryInfrastructure
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   cd StockHouse.AppHost
   dotnet run
   ```

5. **Access the application**
   - API: `http://localhost:5216`
   - Swagger UI: `http://localhost:5216/swagger`
   - Frontend: `http://localhost:3000`
   - Aspire Dashboard: `http://localhost:15002`

### Configuration

The application uses `appsettings.json` for configuration:

```json
{
  "ConnectionStrings": {
    "ConnectionString": "Host=localhost;Port=5432;Username=postgres;Password=stockhouse123;Database=StockHouseDB",
    "Redis": "localhost:6379"
  },
  "ReactProjectPath": "C:\\path\\to\\stockhouse-ui"
}
```

## 📁 Project Structure

```
StockHouse/
├── 📁 StockHouse.AppHost/              # Aspire orchestration host
├── 📁 StockHouse.ServiceDefaults/      # Shared service configurations
├── 📁 StockInventoryProject/
│   ├── 📁 StockInventoryService/        # Web API layer
│   │   ├── 📁 Endpoints/               # Minimal API endpoints
│   │   └── 📁 Extensions/              # Service extensions
│   ├── 📁 StockInventoryApplication/    # Application layer
│   │   ├── 📁 Products/                # Product CQRS handlers
│   │   ├── 📁 Categories/              # Category CQRS handlers
│   │   ├── 📁 Inventories/             # Inventory CQRS handlers
│   │   ├── 📁 Behaviors/               # MediatR behaviors
│   │   └── 📁 Common/                  # Shared application logic
│   ├── 📁 StockInventoryDomain/         # Domain layer
│   │   ├── 📁 Aggregates/              # Domain entities
│   │   ├── 📁 Abstractions/            # Domain interfaces
│   │   └── 📁 Common/                  # Domain base classes
│   ├── 📁 StockInventoryInfrastructure/ # Infrastructure layer
│   │   ├── 📁 Persistence/             # EF Core configuration
│   │   ├── 📁 Repositories/            # Repository implementations
│   │   └── 📁 Migrations/              # Database migrations
│   └── 📁 StockInventoryTests/          # Unit tests
├── 📄 docker-compose.yaml              # Docker services
└── 📄 README.md                        # This file
```

## 🔌 API Endpoints

### Products
- `GET /products` - Get all products
- `GET /products/{id}` - Get product by ID
- `POST /products` - Create new product
- `PUT /products/{id}` - Update product
- `DELETE /products/{id}` - Delete product
- `DELETE /products/soft/{id}` - Soft delete product

### Categories
- `GET /categories` - Get all categories
- `GET /categories/{id}` - Get category by ID
- `POST /categories` - Create new category
- `PUT /categories/{id}` - Update category
- `DELETE /categories/{id}` - Delete category
- `DELETE /categories/soft/{id}` - Soft delete category

### Inventories
- `GET /inventories` - Get all inventories
- `GET /inventories/{id}` - Get inventory by ID
- `POST /inventories` - Create new inventory
- `PUT /inventories/{id}` - Update inventory
- `DELETE /inventories/{id}` - Delete inventory
- `DELETE /inventories/soft/{id}` - Soft delete inventory

### Health Checks
- `GET /health` - Overall health status
- `GET /health/ready` - Readiness probe

## 🗄️ Database Schema

### Core Tables:
- **Products**: Product information with pricing and specifications
- **Categories**: Hierarchical category structure
- **Inventories**: Stock quantities and product associations

### Common Fields:
All entities include audit fields:
- `Id` (Guid) - Primary key
- `CreatedTime` - Creation timestamp
- `UpdatedTime` - Last update timestamp
- `CreatedBy` - User who created the record
- `UpdatedBy` - User who last updated the record
- `IsDeleted` - Soft delete flag
- `IsActive` - Active status flag

## 🔧 Development

### Running Locally

1. **Database Setup**
   ```bash
   # Using Docker
   docker-compose up -d db
   
   # Or use your local PostgreSQL instance
   # Update connection string in appsettings.json
   ```

2. **Run Migrations**
   ```bash
   cd StockInventoryProject/StockInventoryInfrastructure
   dotnet ef database update
   ```

3. **Start the API**
   ```bash
   cd StockInventoryProject/StockInventoryService
   dotnet run
   ```

4. **Start with Aspire (Recommended)**
   ```bash
   cd StockHouse.AppHost
   dotnet run
   ```

### Adding New Features

1. **Domain First**: Add entities to `StockInventoryDomain`
2. **Application Layer**: Create commands/queries in `StockInventoryApplication`
3. **Infrastructure**: Add repositories and configurations
4. **API Layer**: Create endpoints in `StockInventoryService`

### Testing

```bash
cd StockInventoryProject/StockInventoryTests
dotnet test
```

## 🚢 Deployment

### Docker Deployment

1. **Build and run with Docker Compose**
   ```bash
   docker-compose up -d --build
   ```

2. **Environment Variables**
   ```env
   DATABASE_URL=postgresql://postgres:stockhouse123@db:5432/StockHouseDB
   REDIS_URL=redis://redis:6379
   ASPNETCORE_ENVIRONMENT=Production
   ```

### Production Considerations

- Use secure connection strings
- Enable HTTPS
- Configure logging providers
- Set up monitoring and health checks
- Use production-grade Redis and PostgreSQL instances

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines

- Follow Clean Architecture principles
- Use CQRS pattern for new features
- Write unit tests for business logic
- Update API documentation
- Follow C# coding conventions

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙋‍♂️ Support

For support and questions:
- Create an issue on GitHub
- Contact: [Your Contact Information]

## 🗺️ Roadmap

- [ ] Authentication and Authorization
- [ ] Advanced reporting features
- [ ] Barcode scanning integration
- [ ] Multi-warehouse support
- [ ] REST API versioning
- [ ] GraphQL endpoint
- [ ] Mobile application
- [ ] Advanced analytics dashboard

---

**Built with ❤️ using .NET 9 and Clean Architecture**