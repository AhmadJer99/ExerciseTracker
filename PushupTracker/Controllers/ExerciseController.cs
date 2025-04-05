using AutoMapper;
using ExerciseTracker.Interfaces;
using ExerciseTracker.Models;

namespace ExerciseTracker.Controllers;

public class ExerciseController : BaseController
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService, IMapper mapper) : base(mapper)
    {
        _exerciseService = exerciseService;
    }

    public async Task<List<Pushup>> GetAllExercises()
    {
        var exercises = await _exerciseService.GetAll();
        return exercises;
    }

    public async Task<Pushup> GetExerciseById(int id)
    {
        var exercise = await _exerciseService.GetById(id);

        return exercise;
    }

    public async Task<bool> CreateExercise(Pushup newExercise)
    {
        if (newExercise == null)
        {
            return false;
        }
        await _exerciseService.Create(newExercise);
        return true;
    }

    public async Task<bool> UpdateExercise(int id, Pushup updatedExercise)
    {
        if (id != updatedExercise.Id)
        {
            return false;
        }
        var existingExercise = await _exerciseService.GetById(id);
        if (existingExercise == null)
        {
            return false;
        }
        await _exerciseService.Update(updatedExercise);
        return true;
    }

    public async Task<bool> DeleteExercise(int id)
    {
        var exercise = await _exerciseService.GetById(id);
        if (exercise == null)
        {
            return false;
        }
        await _exerciseService.Delete(exercise);
        return true;
    }
}