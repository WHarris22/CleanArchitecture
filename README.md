# Clean Architecture - Stock Market API

A modern, scalable stock market API built with .NET 10 following Clean Architecture principles. This project demonstrates best practices for building maintainable, testable, and extensible web APIs.

## 🏗️ Clean Architecture

Clean Architecture is a software design approach that helps create applications that are **easy to maintain, test, and extend**. It organizes code into distinct layers, each with its own responsibility.

### Why Clean Architecture?

**Traditional apps** often mix business logic, data access, and user interfaces together, making them hard to change. Clean Architecture separates these concerns so you can:

- **Test easily** - Each part can be tested independently
- **Change technology** - Swap databases or UI frameworks without rewriting everything
- **Add features** - New functionality fits cleanly into the existing structure
- **Maintain code** - Changes in one area don't break others

### Project Layers

```
┌─────────────────────────────────────┐
│         CleanArchitecture.Api       │  ← ASP.NET Core Web API
│         Controllers & Models        │
├─────────────────────────────────────┤
│         CleanArchitecture.Core      │  ← Business Logic
│         Services & Interfaces       │
├─────────────────────────────────────┤
│       CleanArchitecture.Domain      │  ← Domain Entities
│         Business Entities           │
├─────────────────────────────────────┤
│   CleanArchitecture.Infrastructure  │  ← Data Access
│         EF Core & Repositories      │
├─────────────────────────────────────┤
│     CleanArchitecture.Utilities     │  ← Shared Utilities
│         Result Types & Extensions   │
└─────────────────────────────────────┘
```

**Key Rule**: Inner layers don't know about outer layers. A database entity shouldn't know about HTTP requests.

##  Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
- Git

## 🚀 Getting Started

### Clone the Repository

```bash
git clone https://github.com/WHarris22/CleanArchitecture.git
cd CleanArchitecture
```

### Build the Solution

```bash
dotnet build
```

### Run the Application

```bash
cd src/CleanArchitecture.Api
dotnet run
```

The API will be available at `https://localhost:5001` (HTTPS) and `http://localhost:5000` (HTTP).

### Run Tests

```bash
dotnet test
```

## 📚 API Endpoints

### Stock Quotes

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/stockquotes` | Get all stock quotes |
| GET | `/api/stockquotes/{symbol}` | Get stock quote by symbol |
| POST | `/api/stockquotes` | Add new stock quote |

### Request/Response Examples

#### Get All Stock Quotes
```http
GET /api/stockquotes
```

#### Get Stock Quote by Symbol
```http
GET /api/stockquotes/AAPL
```

#### Add New Stock Quote
```http
POST /api/stockquotes
Content-Type: application/json

{
  "symbol": "AAPL",
  "companyName": "Apple Inc.",
  "lastPrice": 150.25,
  "changePercent": 2.5
}
```

## 🧪 Testing

The project includes a comprehensive testing setup:

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test project
dotnet test tests/CleanArchitecture.UnitTests/
```

### Test Structure

- **Unit Tests**: Business logic and service layer testing
- **Integration Tests**: Repository and infrastructure testing
- **API Tests**: Controller endpoint testing