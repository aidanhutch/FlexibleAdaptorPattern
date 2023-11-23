# Flexible Adapter Pattern

- By Aidan Hutchinson - 23/11/2023

## Overview

### Concept
- **Core Principle**: Instead of direct mapping, use an adaptable interface that acts as a mediator between domain objects and entities. This interface will handle data transformation and logic encapsulation.
- **Decoupling**: Achieve decoupling through abstract interfaces or protocols. These define the contract for interaction but not the implementation, allowing for flexibility in how data is manipulated and transferred.
- **Adaptability**: Implement adapters for different types of entities. These adapters will conform to the interface/protocol, providing a consistent way of interacting with different data types or sources.

### Components
- **Entity Interface**: Define a generic interface for entities. This interface should be broad enough to encompass the necessary operations across different domains.
- **Domain Object Interface**: Similar to the entity interface, create a general interface for domain objects focusing on the operations and data relevant at the domain level.
- **Adapter**: Implement concrete adapters for each type of entity. These adapters translate between the domain objects and entities, handling any necessary conversion or mapping logic.
- **Factory/Broker**: Optionally, include a factory or broker system to dynamically select and create the appropriate adapter based on context, such as data type or source.

### Benefits
- **Language Agnosticism**: By relying on interfaces/protocols, the pattern can be implemented in any language that supports these constructs.
- **Flexibility**: Easy to adapt to different data types or sources without changing the underlying domain logic.
- **Testability**: Decoupling allows for easier unit testing of domain logic without needing to involve actual data sources or entities.
- **Maintainability**: Changes in the data layer or domain layer can be handled more easily without affecting the other.

### Implementation Notes
- In languages like C# and Rust, interfaces and traits can be used to define the contract.
- In Python, due to its dynamic nature, protocols or abstract base classes can serve the purpose.
- Ensure that the adapter does not become a "god object" — it should be responsible only for translation, not business logic.
- Consider thread safety and concurrency, especially in languages like Rust and C#, where these are significant concerns.

### Applying the Pattern
- **C#**: Use interfaces and possibly generics to create adaptable and type-safe implementations.
- **Python**: Leverage duck typing and protocols to create flexible and dynamic adapters.
- **Rust**: Utilize traits and possibly macro systems to ensure type safety and performance.

## Code Examples

### C# Example

#### Overview
In the C# implementation, interfaces are used to define a contract for entities (`IEntity`) and domain objects (`IDomainObject`). Concrete classes (`UserEntity`, `UserDomainObject`) implement these interfaces. The `UserAdapter` class, implementing the adapter pattern, facilitates the transformation from `UserEntity` to `UserDomainObject`. Dependency injection via Microsoft's DI framework is employed for creating instances of adapters.

#### Key Points
- Interfaces ensure decoupling between domain logic and data entities.
- The adapter pattern is central in transforming entities to domain objects.
- Dependency injection enhances flexibility and testability.

---

### Python Example

#### Overview
In Python, due to its dynamic nature, the implementation leverages abstract base classes to define the contract for entities and domain objects. The `UserAdapter` class adapts a `UserEntity` to a `UserDomainObject`. This example demonstrates the application of the Flexible Adapter Pattern in a dynamically typed language.

#### Key Points
- Abstract base classes are used instead of interfaces.
- Dynamic typing in Python adds flexibility to the adapter implementation.
- The pattern's principles are maintained despite the lack of static typing.

---

### Rust Example

#### Overview
The Rust implementation uses traits to define behaviors (`IEntity`, `IDomainObject`) and structs (`UserEntity`, `UserDomainObject`) to implement these traits. The `UserAdapter` struct is responsible for adapting `UserEntity` into `UserDomainObject`. This example showcases the application of the pattern in a system programming language with a strong type system.

#### Key Points
- Traits in Rust serve the purpose of interfaces, defining a clear contract.
- Structs provide concrete implementations of these traits.
- The adapter pattern in Rust demonstrates the pattern's adaptability to system-level programming.

