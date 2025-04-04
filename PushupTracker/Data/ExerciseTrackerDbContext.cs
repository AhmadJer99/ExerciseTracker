using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Models;

namespace ExerciseTracker.Data;

public class ExerciseTrackerDbContext : DbContext
{
    public ExerciseTrackerDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Exercise> Exercises { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>()
            .HasKey(e => e.Id);
    }
}