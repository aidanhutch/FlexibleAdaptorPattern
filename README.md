[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
# Flexible Adapter Pattern

(c) 2023 Aidan Hutchinson - first published 23/11/2023

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


## So why use this over conventional DDD techniques?

The Flexible Adapter Pattern offers several advantages over conventional Domain-Driven Design (DDD) approaches, particularly in terms of flexibility, maintainability, and adaptability across different environments and technologies. Here's how it enhances the DDD experience:

### 1. **Decoupling of Domain Logic from Data Entities**

Conventional DDD often tightly couples domain entities with domain logic. This can lead to challenges when there are changes in the underlying data models or when integrating with external systems. The Flexible Adapter Pattern introduces a layer of abstraction through adapters, allowing domain logic to remain isolated and unaffected by changes in data entities.

### 2. **Adaptability Across Different Data Sources**

One of the core strengths of this pattern is its adaptability. It allows for easy integration with various data sources or types without altering the domain logic. In conventional DDD, adapting to different data sources might require significant changes in the domain layer, but the adapter pattern externalizes this complexity.

### 3. **Language and Technology Agnosticism**

The Flexible Adapter Pattern is designed to be independent of specific programming languages or technologies. This is particularly beneficial in polyglot programming environments where different systems or components may be implemented in different languages. Conventional DDD approaches might be more language-specific, potentially limiting their applicability across diverse technology stacks.

### 4. **Enhanced Testability**

By decoupling the domain logic from data entities, the pattern significantly improves testability. You can test domain logic without needing to set up actual databases or data entities. In traditional DDD, testing domain logic might involve setting up more complex dependencies, which can be cumbersome and time-consuming.

### 5. **Ease of Maintenance and Scalability**

Maintaining and scaling systems is simpler with the Flexible Adapter Pattern. Changes in the data layer, like modifying a database schema or switching data sources, have minimal impact on the domain layer. Similarly, changes in the domain logic do not necessitate alterations in the data layer. This separation simplifies maintenance and makes scaling different aspects of the system more manageable.

### 6. **Avoidance of Overloaded Domain Models**

Conventional DDD can sometimes lead to domain models becoming bloated or overly complex as they try to accommodate various concerns (like persistence, validation, and business logic). The Flexible Adapter Pattern helps keep domain models focused and lean by externalizing data mapping concerns.

### Conclusion

While Domain-Driven Design provides a robust methodology for dealing with complex domain logic, the Flexible Adapter Pattern enhances it by introducing a more adaptable, maintainable, and testable approach to handling the interaction between domain logic and data entities. This pattern is particularly advantageous in modern, multi-paradigm development environments where flexibility and adaptability are crucial.

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

