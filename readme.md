# learn dotnet

## 1. create api without db

What I learn?

1. how to initialize project
```
dotnet new web -o <name-project>
```
2. run project and build project
```
dotnet watch run 
```
```
dotnet publish
```
3. structure folder
```
- Controllers
- Services
    - Interfaces
    - Implementations
- Models
```
4. basic csharp and .net

## 2. create api with db

What I learn?

1. moving from project structure by type to by feature
```
- <Name Feature>
    - Controller
    - Model
    - Service
    - Repository
    - Dto
    ...
```


2. how to use entity framework
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app