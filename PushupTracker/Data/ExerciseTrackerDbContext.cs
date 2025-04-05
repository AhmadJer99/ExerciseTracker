using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Models;

namespace ExerciseTracker.Data;

public class ExerciseTrackerDbContext<TEntity> : DbContext where TEntity : class
{
    public ExerciseTrackerDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<TEntity> Exercises { get; set; }
}