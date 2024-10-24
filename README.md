# MusicShop Project

For the latest version of this repository, visit the:  
## [main branch](https://github.com/CrnTarim/MusicShopAPI-.Net/tree/main)


**MusicShop** is an educational project based on .NET. The project is designed to be as simple as possible to ensure the understandability of fundamental concepts. The goals of the project are as follows:

- **Effective use of N-Tier architecture**
- **Creating related data tables by adopting the Code-First approach**
- **Applying software design patterns and SOLID principles to facilitate the sustainability and maintenance of the project**
- **Ensuring a clear understanding of core concepts like Generic structures, Dependency Injection, and dependency management**
- **Utilization of Relational and Non-Relational Data Structures: The project leverages both relational data structures through the Code-First approach with Entity Framework for core entities, while also incorporating non-relational data structures via MongoDB**
- **Implementing caching mechanisms using Redis for enhanced performance and efficiency**
## Technologies and Structures Used

- **DTO (Data Transfer Object)**: The project utilizes the DTO structure to facilitate data transfer and reduce dependencies between layers.

- **AutoMapper**: The AutoMapper library is used to automate data transformations. This allows for quick and error-free conversions between data entities and DTOs. Additionally, a common mapper has been created for many entity classes using `GenericMapper<T, TDto, TUpdate, TCreate>`.

- **IEntityTypeConfiguration**: In the project, 1-1, 1-m, and m-n relationships are fully defined, and the configuration of these relationships is achieved using `IEntityTypeConfiguration`. This provides a more dynamic and flexible structure. This structure facilitates the management of relationships, contributing to the overall architecture of the application.

- **MongoDB**: The project also incorporates MongoDB for logging purposes. By utilizing a non-relational database, it enhances the flexibility and scalability of data storage, allowing for efficient handling of log data without the constraints of traditional relational structures.
- **Redis**: To improve performance, Redis is integrated as a caching mechanism. This reduces the need for repeated database queries and provides fast access to frequently used data. Redis has been implemented using Docker to ensure seamless deployment and management within the project.
- **Docker**: The project uses Docker for the containerization of Redis,  other necessary services, ensuring a consistent environment across different development setups. This makes it easier to deploy and scale the application across different platforms.
