using ExerciseTracker.Services;
using ExerciseTracker.Controllers;
using ExerciseTracker.Models;
using ConsoleTableExt;
using Spectre.Console;

namespace ExerciseTracker.UserInterface;

public class ExerciseHistoryMenu : BaseMenu
{
    private readonly ExerciseController _exerciseController;
    private readonly List<Pushup> _pushups;

    public ExerciseHistoryMenu(ExerciseController exerciseController)
    {
        _exerciseController = exerciseController;
        var result = _exerciseController.GetAllExercisesAsync().Result;
        _pushups = result.Data ?? [];
    }
    public override async Task ShowMenuAsync()
    {
        Console.Clear();
        if (_pushups == null || _pushups.Count == 0)
        {
            Console.WriteLine("No exercise history found.");
            return;
        }
        TableVisualisationEngine<Pushup>.ViewAsTable(_pushups, TableAligntment.Left, ["ID", "Date", "Reps", "Comments"], "Exercise History");
    }
}
