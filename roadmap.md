# Clean Architecture Roadmap

This document outlines planned improvements and enhancements for the Clean Architecture project.

## 📋 Planned Changes

### 1. Command/Query Separation Pattern (CQRS)
**Status:** ✅ Completed
**Priority:** High
**Completed:** 2026-06-06

Successfully implemented Command Query Responsibility Segregation (CQRS) pattern with a custom lightweight mediator dispatcher.

**Scope:**
- ✅ Separate read operations (Queries) from write operations (Commands)
- ✅ Create dedicated command and query handlers
- ✅ Implement custom mediator pattern (`IMediator`) with reflection-based handler discovery
- ✅ Maintained single data model (eventual consistency deferred)
- ✅ Removed old `StockMarketService` classes

**Implementation Details:**
- Created mediator core abstractions: `ICommand<T>`, `ICommandHandler<,>`, `IQuery<T>`, `IQueryHandler<,>`, `IMediator`, `Mediator`
- Implemented 3 query handlers: `GetAllQuotesQuery`, `GetQuoteBySymbolQuery`
- Implemented 1 command handler: `AddQuoteCommand`
- Auto-discovered and registered handlers via reflection in DI container
- Updated `StockQuotesController` to inject single `IMediator` dependency
- Maintained `Result<T>` error handling pattern
- All tests passing

**Benefits Realized:**
- ✅ Better separation of concerns
- ✅ Improved testability
- ✅ Cleaner business logic organization
- ✅ No external dependencies (custom implementation)
- ✅ Single injection point reduces coupling
- ✅ Ready for cross-cutting concerns (logging, validation pipelines, etc.)

**Commits:**
- `6094b8c` - Implement CQRS pattern with custom mediator for StockMarkets domain
- `82dbfec` - Remove old StockMarketService classes - replaced by CQRS mediator pattern

### 2. Fast Endpoints Integration
**Status:** Planned
**Priority:** Medium

Replace ASP.NET Core MVC controllers with FastEndpoints for improved performance and developer experience.

**Scope:**
- Replace `StockQuotesController` with FastEndpoint implementations
- Implement request/response DTOs
- Configure endpoint validation
- Update dependency injection

**Benefits:**
- Faster request processing
- Built-in validation
- Reduced boilerplate code
- Better performance metrics

**Implementation Steps:**
1. Add FastEndpoints package
2. Create endpoint classes
3. Implement request/response models
4. Configure routing and validation
5. Update Program.cs configuration

### 3. Unit Test Coverage Enhancement
**Status:** Planned
**Priority:** High

Improve unit test coverage across all projects.

**Scope:**
- Core business logic tests
- Repository implementation tests
- Controller endpoint tests
- Integration tests for API endpoints
- Mock implementations for external dependencies

**Current Coverage:** ~30%
**Target Coverage:** 80%+

**Benefits:**
- Increased code reliability
- Regression prevention
- Documentation through tests
- Confidence in refactoring

**Test Categories:**
- Unit tests for services
- Integration tests for repositories
- API endpoint tests
- Validation tests

### 4. Architecture Guidelines and Code Style Instructions
**Status:** Planned
**Priority:** Medium

Create comprehensive documentation for architecture guidelines and coding standards.

**Scope:**
- Project structure guidelines
- Naming conventions
- Code organization patterns
- Dependency injection rules
- Testing standards
- Git workflow guidelines

**Deliverables:**
- `ARCHITECTURE.md` - Architecture decisions and patterns
- `CONTRIBUTING.md` - Development workflow and standards
- `CODE_STYLE.md` - Code formatting and style guidelines
- `.editorconfig` - Editor configuration for consistent formatting

### 5. Cancellation Token Support

**Status:** Planned

**Priority:** High

Implement comprehensive cancellation token support across all async operations in the application.

**Scope:**

- Add `CancellationToken` parameters to all async methods in services, repositories, and handlers
- Implement cancellation token propagation through the entire request pipeline
- Update command and query handlers to support cancellation
- Configure ASP.NET Core to propagate request cancellation tokens
- Add proper cancellation handling in long-running operations

**Benefits:**

- Graceful handling of client disconnections
- Reduced server resource waste
- Better user experience for cancelled requests
- Compliance with async best practices
- Improved application responsiveness under load

**Implementation Steps:**

1. Update repository interfaces and implementations with `CancellationToken` parameters
2. Update service layer methods with `CancellationToken` parameters
3. Update command/query handlers with `CancellationToken` support
4. Configure controller actions to pass `HttpContext.RequestAborted` tokens
5. Update Entity Framework Core queries to accept cancellation tokens
6. Add unit tests for cancellation scenarios
7. Document cancellation token usage patterns

### 6. OpenAPI Documentation
**Status:** Planned
**Priority:** Medium

Enhance the API with OpenAPI/Swagger documentation and tooling.

**Scope:**
- Add API documentation generation to the ASP.NET Core API project
- Configure Swagger/OpenAPI metadata and UI
- Expose generated OpenAPI JSON documentation
- Use XML comments for endpoint descriptions and request/response models

**Benefits:**
- Public API discovery and consumability
- Auto-generated API contract for clients
- Improved developer onboarding
- Easier integration testing and validation

**Implementation Steps:**
1. Add `Swashbuckle.AspNetCore` package to the API project
2. Register OpenAPI and Swagger services in `Program.cs`
3. Configure XML comment file support and endpoint metadata
4. Enable Swagger UI in development and optionally staging
5. Validate the OpenAPI JSON document and UI routes

## 🎯 Implementation Order

1. ✅ **CQRS Pattern** (Completed 2026-06-06) - Major architectural improvement
2. **Unit Test Coverage** (Foundation for future changes)
3. **Cancellation Token Support** (Async best practices)
4. **Fast Endpoints** (Performance and DX improvement)
5. **OpenAPI Documentation** (API discoverability and contract generation)
6. **Documentation** (Knowledge sharing and onboarding)

## 📊 Success Metrics

- **Documentation:** 100% of public APIs documented
- **OpenAPI:** Swagger UI and OpenAPI JSON available for the API
- **Testing:** 80%+ code coverage
- **Performance:** Measure endpoint response times before/after FastEndpoints
- **Maintainability:** Reduced complexity through CQRS separation
- **Developer Experience:** Faster onboarding with comprehensive docs

## 🔄 Dependencies

- CQRS implementation should be done before FastEndpoints
- Cancellation token support should be added after CQRS implementation
- OpenAPI documentation should be implemented alongside FastEndpoints or before final docs
- Unit tests should be enhanced throughout all changes, especially for cancellation scenarios
- Documentation should be updated as changes are implemented