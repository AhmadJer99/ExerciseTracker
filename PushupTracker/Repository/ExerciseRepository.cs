using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Interfaces;
using Microsoft.Extensions.Logging;
using ExerciseTracker.Data;
using ExerciseTracker.Models;

namespace ExerciseTracker.Repository;

public class ExerciseRepository : IExerciseRepository
{
    private readonly ExerciseTrackerDbContext _context;
    private readonly ILogger<ExerciseRepository> _logger;

    public ExerciseRepository(ExerciseTrackerDbContext context, ILogger<ExerciseRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task AddAsync(Pushup pushup)
    {
        if (pushup == null)
        {
            _logger.LogError("Attempted to add a null entity of type {EntityType}", typeof(Pushup).Name);
            throw new ArgumentNullException(nameof(pushup), "Entity cannot be null");
        }
        try
        {
            await _context.Exercises.AddAsync(pushup);
            await _context.SaveChangesAsync();
        }
        catch
        {
            _logger.LogError("Error adding entity of type {EntityType}", typeof(Pushup).Name);
            throw;
        }
    }

    public async Task DeleteAsync(Pushup pushup)
    {
        var pushupById = await _context.Exercises.AsNoTracking().Where(e => e.Id == pushup.Id).FirstOrDefaultAsync();
        if (pushupById == null)
        {
            _logger.LogError("Attempted to delete a null entity of type {EntityType}", typeof(Pushup).Name);
            throw new ArgumentNullException(nameof(pushup), "Entity cannot be null");
        }
        try
        {
            _context.Exercises.Remove(pushup);
            await _context.SaveChangesAsync();
        }
        catch
        {
            _logger.LogError("Error deleting entity of type {EntityType}", typeof(Pushup).Name);
            throw;
        }
    }

    public async Task<IEnumerable<Pushup>> GetAllAsync()
    {
        try
        {
            return await _context.Exercises.AsNoTracking().ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all entities of type {EntityType}", typeof(Pushup).Name);
            throw;
        }
    }

    public async Task<Pushup> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Exercises.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        catch
        {
            _logger.LogError("Error retrieving entity of type {EntityType} with ID {Id}", typeof(Pushup).Name, id);
            throw;
        }
    }

    public async Task UpdateAsync(Pushup pushup)
    {
        if (pushup == null)
        {
            _logger.LogError("Attempted to update a null entity of type {EntityType}", typeof(Pushup).Name);
            throw new ArgumentNullException(nameof(pushup), "Entity cannot be null");
        }
        try
        {
            _context.Entry(pushup).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch
        {
            _logger.LogError("Error updating entity of type {EntityType}", typeof(Pushup).Name);
            throw;
        }
    }
}
