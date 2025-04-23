# ExerciseTracker

<table>
  <tr>
    <td>
      <img src="https://github.com/user-attachments/assets/1b8c3a8d-144a-4bf7-be66-53748fe006eb" width="300">
    </td>
    <td>
      <h1>ExerciseTracker</h1>
      <p>This is an application where I record exercise data focusing on building the app using the <strong>Repository Pattern</strong> and <strong>Dependency Injection</strong>. I will be using EF Core for the database backend, and will focus on only one type of exercise to keep the app simple.<br>
      And to illustrate the Separation of Concerns by the repository pattern, I created a class to replace Entity Framework by Dapper or in my repository. I noticed I didn't need to touch my controller class at all!</p>
    </td>
  </tr>
</table>

---

## 📚 Resources I Used
> A list of tutorials, courses, blogs, or documentation that helped me build this project.

- [Learnt how to create the repository pattern following this article.](https://medium.com/@kerimkkara/implementing-the-repository-pattern-in-c-and-net-5fdd91950485)
- [Learnt how to use Dependency Injection through a video tutorial on YouTube.](https://www.youtube.com/watch?v=GAOCe-2nXqc&t=2391s)
- [Learnt about Change Tracking in EntityFramework by following MS Docs.](https://learn.microsoft.com/en-us/ef/core/change-tracking/)
- [Learnt how to debug Change Tracking in EntityFramework by following MS Docs.](https://learn.microsoft.com/en-us/ef/core/change-tracking/debug-views)

---

## 🛠️ Tech Stack

| Category        | Technology Used     |
|----------------|---------------------|
| Backend        | `ASP.NET Core`      |
| Database       | `SQL Server`, `EF Core`, `Dapper` |
| Dependency Injection | `Built-in .NET Core DI` |
| Logging        | `Serilog`           |
| ORM/Querying   | `EF Core`, `Dapper` |
| UI Formatting   | `Spectre.Console`,`ConsoleTableExt`|

---

## 🚀 How to Run This App

> Simple and clear instructions on how to get the app running locally.

1. Clone the repository
   ```bash
   git clone https://github.com/your-username/ExerciseTracker.git
2. Navigate to the project directory
   ```bash
   cd ExerciseTracker
3. Update the connection string in `appsettings.json`
4. Run the project
   ```bash
   dotnet run
