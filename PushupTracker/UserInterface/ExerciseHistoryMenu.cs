using ExerciseTracker.Helper;
using ExerciseTracker.Controllers;
using ExerciseTracker.Models;

namespace ExerciseTracker.UserInterface;

public class ExerciseHistoryMenu : BaseMenu
{
    private readonly ExerciseController _exerciseController;
    private readonly List<Pushup> _pushups;

    public ExerciseHistoryMenu(ExerciseController exerciseController)
    {
        _exerciseController = exerciseController;
        var result = _exerciseController.GetAllExercises().Result;
        _pushups = result.Data ?? [];
    }
    public override async Task ShowMenuAsync()
    {
        foreach (var pushup in _pushups)
        {
            Console.WriteLine($"ID: {pushup.Id}, Date: {pushup.Date}, Reps: {pushup.Reps}, Comments: {pushup.Comments}");
        }
    }
}
