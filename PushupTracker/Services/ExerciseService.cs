using ExerciseTracker.Interfaces;
using ExerciseTracker.Models;

namespace ExerciseTracker.Services;

public class ExerciseService : IExerciseService
{
    public Task<Pushup> Create(Pushup newEntity)
    {
        throw new NotImplementedException();
    }

    public Task<string> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Pushup>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Pushup> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Pushup> Update(int id, Pushup updatedEntity)
    {
        throw new NotImplementedException();
    }
}
