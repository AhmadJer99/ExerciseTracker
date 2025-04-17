using ExerciseTracker.Controllers;
using Spectre.Console;

namespace ExerciseTracker.UserInterface;

public class MainMenu : BaseMenu
{
    private readonly ExerciseController _exerciseController;
    private readonly ExerciseHistoryMenu _exerciseHistoryMenu;

    private enum MenuOptions
    {
        AddExercise = 1,
        Progress,
        Challenges,
        ExerciseHistory,
        Exit
    }

    public MainMenu(ExerciseController exerciseController, ExerciseHistoryMenu exerciseHistoryMenu)
    {
        _exerciseController = exerciseController;
        _exerciseHistoryMenu = exerciseHistoryMenu;
    }

    public override async Task ShowMenuAsync()
    {
        while (true)
        {
            Console.Clear();

            var selectedOption = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
            .Title("[teal]Main Menu[/]")
            .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (selectedOption)
            {
                case MenuOptions.AddExercise:
                    // Call the method to add an exercise
                    AnsiConsole.MarkupLine("[green]Adding Exercise...[/]");
                    break;
                case MenuOptions.Progress:
                    // Call the method to show progress
                    AnsiConsole.MarkupLine("[green]Showing Progress...[/]");
                    break;
                case MenuOptions.Challenges:
                    // Call the method to show challenges
                    AnsiConsole.MarkupLine("[green]Showing Challenges...[/]");
                    break;
                case MenuOptions.ExerciseHistory:
                    await _exerciseHistoryMenu.ShowMenuAsync();
                    PressAnyKeyToContinue();
                    break;
                case MenuOptions.Exit:
                    AnsiConsole.MarkupLine("[red]Exiting...[/]");
                    return;
            }
        }
    }
}