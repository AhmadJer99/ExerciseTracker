using ExerciseTracker.Models;

namespace ExerciseTracker.Interfaces;

public interface IExerciseService
{
    public Task<List<Pushup>> GetAll();
    public Task<Pushup> GetById(int id);
    public Task<Pushup> Create(Pushup newEntity);
    public Task<Pushup> Update(int id, Pushup updatedEntity);
    public Task<string> Delete(int id);
}
