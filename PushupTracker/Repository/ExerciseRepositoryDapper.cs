using ExerciseTracker.Interfaces;
using ExerciseTracker.Models;
using ExerciseTracker.Data;
using Dapper;
using Microsoft.Extensions.Logging;

namespace ExerciseTracker.Repository;

public class ExerciseRepositoryDapper : IExerciseRepository
{
    private readonly ExerciseTrackerDapperDbContext _dbContext;
    private readonly ILogger<ExerciseRepositoryDapper> _logger;

    public ExerciseRepositoryDapper(ExerciseTrackerDapperDbContext dbContext, ILogger<ExerciseRepositoryDapper> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
        EnsureTableCreated();
    }

    private void EnsureTableCreated()
    {
        using var connection = _dbContext.CreateConnection();
        connection.Open();

        var checkTableCommand = connection.CreateCommand();
        checkTableCommand.CommandText =
            @"
                SELECT TABLE_NAME 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Exercises';
            ";

        var tableName = checkTableCommand.ExecuteScalar() as string;

        if (string.IsNullOrEmpty(tableName))
        {
            _logger.LogInformation("Table 'Exercises' does not exist. Creating table...");

            var createQuery =
                @"
                    CREATE TABLE Exercises (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Date DATETIME2(7),
                        Reps INT NOT NULL,
                        Comments NVARCHAR(MAX) NULL
                    );
                ";

            using var createCommand = connection.CreateCommand();
            createCommand.CommandText = createQuery;
            createCommand.ExecuteNonQuery();

            _logger.LogInformation("Table 'Exercises' created successfully.");
        }
        else
            _logger.LogInformation("Table 'Exercises' already exists. Skipping creation.");
    }

    public async Task AddAsync(Pushup entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Pushup entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Pushup>> GetAllAsync()
    {
        using var connection = _dbContext.CreateConnection();
        connection.Open();

        var query = "SELECT * FROM Exercises";
        var pushups = await connection.QueryAsync<Pushup>(query);

        return pushups;
    }

    public async Task<Pushup> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Pushup entity)
    {
        throw new NotImplementedException();
    }
}
