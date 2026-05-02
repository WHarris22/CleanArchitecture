---
name: 'Clean Architecture Coding and Docs Standards'
description: 'Apply repository-wide Clean Architecture conventions, service/infrastructure result wrapper patterns, XML documentation rules, and documentation expectations for C# and markdown files.'
applyTo: '**/*.{cs,md}'
---

# Clean Architecture Coding and Documentation Standards

## Architecture and layering
- Follow the repo’s Clean Architecture layering exactly: `Api` for controllers and DTOs, `Core` for business services and interfaces, `Domain` for entities and repository contracts, `Infrastructure` for data access and persistence implementations, and `Utilities` for shared result types.
- Keep dependencies inward-facing: inner layers must not depend on outer layers.
- Use DI registration extension methods such as `AddCore()` and `AddInfrastructure()` in `Program.cs`.

## Naming conventions
- Prefix interfaces with `I` and suffix implementation classes with `Service` or `Repository`.
- Name API models with `Request` and `Response` suffixes.
- Use `_camelCase` for private readonly fields.
- Keep namespaces aligned with folder structure and project layer.

## Result wrapper usage
- Use `Result<T>` and `ResultStatus` for service-boundary responses and infrastructure/outcome flows.
- For business operations that can succeed, fail, be invalid, or return missing data, return a result wrapper rather than throwing for normal flow control.
- Infrastructure and cross-layer flows should also surface outcome results when they involve validation, persistence, lookup failures, or status semantics.
- Example outcomes to model explicitly: `Success`, `Created`, `Invalid`, `NotFound`, `InternalError`.
- Plain `Task<T>` is acceptable only for simple repository reads that do not need status metadata or failure semantics.

## XML documentation
- Add XML doc comments for public interfaces, public classes, and public properties.
- Also document private methods or non-public implementations when the behavior is not obvious or needs explanation.
- Use `/// <summary>`, `/// <param name="...">`, and `/// <returns>` to describe intent and contract semantics.
- Prefer documentation that explains why a rule exists, not just what it does.

## Documentation expectations
- Keep repository documentation consistent across `README.md`, `roadmap.md`, and future docs such as `ARCHITECTURE.md` and `CODE_STYLE.md`.
- Document architecture decisions, layer responsibilities, naming conventions, and result flow patterns in workspace docs.
- Use markdown in docs to make conventions explicit and link to implementation examples where needed.
- Ensure docs are part of the project and reflect the actual code structure and patterns in the repository.

## Reasoning
- These conventions help enforce maintainable Clean Architecture boundaries, consistent cross-layer result handling, and readable public and implementation contracts.
- They also support project-wide clarity by making coding and documentation rules explicit for all contributors.
