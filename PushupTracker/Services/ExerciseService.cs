using ExerciseTracker.Interfaces;
using ExerciseTracker.Models;
using ExerciseTracker.Repository;

namespace ExerciseTracker.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _repository;
    private readonly IExerciseRepository _dapperRepository;

    public ExerciseService(ExerciseRepository repository, ExerciseRepositoryDapper exerciseRepositoryDapper)
    {
        _repository = repository;
        _dapperRepository = exerciseRepositoryDapper;
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
        //return (await _repository.GetAllAsync()).ToList();
        return (await _dapperRepository.GetAllAsync()).ToList();
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