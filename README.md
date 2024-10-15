# MusicShop Project

**MusicShop** is an educational project based on .NET. The project is designed to be as simple as possible to ensure the understandability of fundamental concepts. The goals of the project are as follows:

- **Effective use of N-Tier architecture**
- **Creating related data tables by adopting the Code-First approach**
- **Applying software design patterns and SOLID principles to facilitate the sustainability and maintenance of the project**
- **Ensuring a clear understanding of core concepts like Generic structures, Dependency Injection, and dependency management**

## Technologies and Structures Used

- **DTO (Data Transfer Object)**: The project utilizes the DTO structure to facilitate data transfer and reduce dependencies between layers.

- **AutoMapper**: The AutoMapper library is used to automate data transformations. This allows for quick and error-free conversions between data entities and DTOs. Additionally, a common mapper has been created for many entity classes using `GenericMapper<T, TDto, TUpdate, TCreate>`.

- **IEntityTypeConfiguration**: In the project, 1-1, 1-m, and m-n relationships are fully defined, and the configuration of these relationships is achieved using `IEntityTypeConfiguration`. This provides a more dynamic and flexible structure. This structure facilitates the management of relationships, contributing to the overall architecture of the application.
