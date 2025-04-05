using Microsoft.EntityFrameworkCore;
using ExerciseTracker.Interfaces;
using Microsoft.Extensions.Logging;

namespace ExerciseTracker.Repository;

public class ExerciseRepository<T> : IRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly ILogger _logger;
    private readonly DbSet<T> _dbSet;

    public ExerciseRepository(DbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
        _dbSet = _context.Set<T>();

    }

    public async Task AddAsync(T entity)
    {
        if (entity == null)
        {
            _logger.LogError("Attempted to add a null entity of type {EntityType}", typeof(T).Name);
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
        }
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        catch
        {
            _logger.LogError("Error adding entity of type {EntityType}", typeof(T).Name);
            throw;
        }
    }

    public async Task DeleteAsync(T entity)
    {
        if (entity == null)
        {
            _logger.LogError("Attempted to delete a null entity of type {EntityType}", typeof(T).Name);
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
        }
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        catch
        {
            _logger.LogError("Error deleting entity of type {EntityType}", typeof(T).Name);
            throw;

        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all entities of type {EntityType}", typeof(T).Name);
            throw;

        }
    }

    public async Task<T> GetByIdAsync(int id)
    {
        try
        {
            return await _context.FindAsync<T>(id);
        }
        catch
        {
            _logger.LogError("Error retrieving entity of type {EntityType} with ID {Id}", typeof(T).Name, id);
            throw;

        }
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            _logger.LogError("Attempted to update a null entity of type {EntityType}", typeof(T).Name);
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
        }
        try
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch
        {
            _logger.LogError("Error updating entity of type {EntityType}", typeof(T).Name);
            throw;

        }
    }
}