# Jogoteca
A system to manage game's borrowing (like a library with that borrow books, but for games)

## To run the project
First start the PostgreSQL DB, if you dont have one you can use from from docker with ```docker-compose -f docker/docker-compose.yml up jogoteca_db```

Now you can open the project on **VS Code** and press F5 (the repository already contains configuration to run)

OR

run both the project and Postgres DB with **docker** from the project root directory: ```docker-compose -f docker/docker-compose.yml up```

OR you can run from **command line** with: ```dotnet ```

## Documentation
Some of this project documentation will be keeped on Google Drive for faster updates, you can access it throw this link: [Documentation](https://drive.google.com/drive/folders/1EtqdI-pLf5I0thqPEk_uS-3N3xJj52J0?usp=sharing)

## Archtecture
For this project, a architecture with layers was chosen for better responsabilities separation. Naming the Layers from most external to more internal we have:
1. **Views Layer**: are the pages that a client can interact with.
2. **Controllers Layer**: Make the comunication between all pages (front-end) and the server-size (back-end)
3. **Services Layer**: Responsable for keeping all business rules at one layer, increasing organization and reusability.
4. **Repository Layer**: Responsable for all data quering and changings from DB, making easier to change the DB access technology and keeping the project organized.
5. **Model Layer**: This layer has all systems modeling in terms of data, this been entities, view models, DTOs, and exceptions.



Note: From the **Services layer** on, we can move all code for a separeted project, generating a dll that can be reused. Since we have all business rules implemented, change from WEB to WEB API or create a second WEB API project would be trivial.

## Main Technologies & Libraries used
### Back-end
1. DotNet Core 3.1 (Framework Web)
2. Entity Famework 3.1 (ORM)
3. Identity (Managing users and authentication)
4. Dependency Injection
5. Entity Framework Migrations
6. Global exception handling with exception architecture
7. DotNet Filters
8. C# Extensions
### Front-end
1. HTML / CSS / Javascript
2. Razor Views
3. Bootstrap
4. Ajax (on the feature that mark a game as received)
5. CdnJS (to all libraries bellow):
  - FontAwesome
  - SweetAlert2 (on the feature that mark a game as received)
  - Axios (on the feature that mark a game as received)
 
### Others project and develop technologies
1. gitignore.io (to generate gitignore)
2. Database PostgreSQL
3. Docker & Docker Compose
4. Nuget
5. Unit Test
6. Continuous integration, using GitHub Actions (short time to make CD, but i can)

## Development process
First a docker to keep PostgreSQL up while developing was crated, you can find it at /docker/docker-compose.yml (only the db works for now, the app dont work throw docker yeet)

For project creation: dotnet new mvc -n 'Jogoteca.Web'

For generatin sln: dotnet new sln -n Jogoteca.Web

For external dependencies: dotnet add package

For internal dependencies: dotnet add reference

For migrations: dotnet ef migrations add && dotnet ef migrations update 

For Controllers and Views: dotnet aspnet-codegenerator controller -m Model && editing manualy
