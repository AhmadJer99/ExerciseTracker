using ExerciseTracker.Services;
using ExerciseTracker.Controllers;
using ExerciseTracker.Models;
using ConsoleTableExt;
using Spectre.Console;
using ExerciseTracker.Helper;

namespace ExerciseTracker.UserInterface;

public class ExerciseHistoryMenu : BaseMenu
{
    private readonly ExerciseController _exerciseController;

    public ExerciseHistoryMenu(ExerciseController exerciseController)
    {
        _exerciseController = exerciseController;
    }
    public override async Task ShowMenuAsync()
    {
        var result = _exerciseController.GetAllExercisesAsync().Result;
        var _pushups = result.Data ?? [];
        if (result.Success)
        {
            Console.WriteLine(result.Message);
            await ShowExerciseHistoryAsync(_pushups);
        }
        else
        {
            Console.WriteLine(result.Message);
        }
    }

    private async Task ShowExerciseHistoryAsync(List<Pushup> pushups)
    {
        Console.Clear();
        if (pushups == null || pushups.Count == 0)
        {
            Console.WriteLine("No exercise history found.");
            return;
        }
        TableVisualisationEngine<Pushup>.ViewAsTable(pushups, TableAligntment.Left, ["ID", "Date", "Reps", "Comments"], "Exercise History");
        await PromptActionOnRowAsync();
    }

    private async Task PromptActionOnRowAsync()
    {
        while (true)
        {
            Console.Write("\nEnter action (e.g., E1 to edit row with id=1, D1 to delete row with id=1, Q to quit): ");
            var input = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(input))
                continue;

            if (input == "Q")
                break;

            if (input.StartsWith('E') && int.TryParse(input[1..], out int editId))
            {
                // Call your edit method
                await HandleRowEditAsync(editId);
                break;
            }
            else if (input.StartsWith('D') && int.TryParse(input[1..], out int deleteId))
            {
                await HandleRowDeleteAsync(deleteId);
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
        await ShowMenuAsync();
    }

    private async Task HandleRowEditAsync(int editId)
    {
        // I can edit Date,Reps or comments
    }

    private async Task HandleRowDeleteAsync(int deleteId)
    {
        var result = await _exerciseController.DeleteExerciseAsync(deleteId);
        AnsiConsole.MarkupLine($"[green]{result.Message}[/]");
        PressAnyKeyToContinue();
    }
}