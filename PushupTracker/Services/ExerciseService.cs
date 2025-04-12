using ExerciseTracker.Interfaces;
using ExerciseTracker.Models;

namespace ExerciseTracker.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _repository;

    public ExerciseService(IExerciseRepository repository)
    {
        _repository = repository;
    }
    public async Task Create(Pushup newEntity)
    {
        await _repository.AddAsync(newEntity);
    }

    public async Task Delete(Pushup pushup)
    {
        await _repository.DeleteAsync(pushup);
    }

    public async Task<List<Pushup>> GetAll()
    {
        return (await _repository.GetAllAsync()).ToList();
    }

    public async Task<Pushup> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public Task Update(Pushup updatedPushup)
    {
        return _repository.UpdateAsync(updatedPushup);
    }
}