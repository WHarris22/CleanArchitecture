---
name: "Clean Architecture Unit Testing Conventions"
description: "Define MSTest, FluentAssertions, Moq, and test structure conventions for the CleanArchitecture.UnitTests project."
applyTo: "tests/CleanArchitecture.UnitTests/**/*.cs"
---

# Clean Architecture Unit Testing Conventions

## Framework and packages
- Use MSTest as the unit test framework for `tests/CleanArchitecture.UnitTests`.
- Prefer `FluentAssertions` for expressive assertions and `Moq` for dependency mocking.
- Keep package versions explicit and compatible with the project target framework.
- Recommended package references:
  - `Microsoft.NET.Test.Sdk`
  - `MSTest.TestAdapter`
  - `MSTest.TestFramework`
  - `FluentAssertions`
  - `Moq`

## Test structure and naming
- Follow the Arrange-Act-Assert (AAA) pattern in every test.
- Name test methods using the pattern:
  - `Should_DoSomething_When_ThisHappens`
- Keep test methods focused on a single behavior or scenario.
- Avoid large integration-style tests in unit test classes.

## Folder and namespace organization
- Mirror the production project folder structure under `tests/CleanArchitecture.UnitTests`.
- Keep namespaces aligned with the subject under test.
- Example:
  - `src/CleanArchitecture.Core/StockMarkets/StockMarketService.cs`
  - `tests/CleanArchitecture.UnitTests/StockMarkets/StockMarketServiceTests/`

## Test class organization
- Use one test class per method under test.
- Group tests for the same production method into a dedicated class file.
- Use `TestBase` for shared setup, reusable builders, and common mock configuration.
- Example structure:
  - `StockMarketServiceTests.cs` — for constructor and broad service invariants
  - `GetStockQuoteAsyncTests.cs` — for tests of the `GetStockQuoteAsync` method
  - `CreateQuoteTests.cs` — for tests of the `CreateQuote` method

## Shared test infrastructure
- Define a common abstract base class such as `TestBase` inside the test project.
- Put shared setup, common test utilities, and reusable mock arrangements in `TestBase`.
- Use helper methods for repeated mock setup to keep individual test methods readable.
- Avoid placing production logic in test helpers; helpers should only orchestrate test data and dependencies.

## Data arrangement and builders
- Use builder patterns for complex test data setup when it improves readability.
- Prefer a dedicated builder per aggregate or domain object when the arrangement is repeated.
- Example builder usage:
  - `var quote = new StockQuoteBuilder().WithSymbol("MSFT").WithPrice(300).Build();`
- Keep builders simple, expressive, and easy to reuse across tests.

## Mocking and dependency setup
- Use `Moq` to mock external dependencies and collaborators.
- Keep mock setup inside helper methods or `TestBase` methods when multiple tests share the arrangement.
- Assert mock interactions explicitly when the interaction is part of the contract.
- Use `FluentAssertions` for assertions rather than MSTest assertion helpers when possible.

## Test readability and maintainability
- Write tests with clear, intent-revealing names.
- Keep Arrange, Act, and Assert sections visually separated in the test body.
- Avoid excessive setup in individual tests; extract repeated setup into helpers or builders.
- Favor explicit test data over magic values.

## Documentation and project alignment
- Document any project-specific testing conventions in the unit test project or repository docs.
- Keep test conventions aligned with existing Clean Architecture rules for separation of concerns and layer boundaries.
- Review `tests/CleanArchitecture.UnitTests/CleanArchitecture.UnitTests.csproj` when adding packages or changing target frameworks.
