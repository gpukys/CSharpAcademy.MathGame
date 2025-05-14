using MathGame;
using Spectre.Console;
using static MathGame.Enums;
HistoryDatabase db = new();

while (true)
{
    Console.Clear();
    AnsiConsole.MarkupLine("Welcome to the console math game!");
    var menu = AnsiConsole.Prompt(
        new SelectionPrompt<Menu>()
        .Title("What would you like to do?")
        .AddChoices(Enum.GetValues<Menu>()));

    switch (menu)
    {
        case Menu.Play:
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<Operation>()
                .Title("Choose which operation you would like to play with:")
                .AddChoices(Enum.GetValues<Operation>()));

            var difficulty = AnsiConsole.Prompt(
                new SelectionPrompt<Difficulty>()
                .Title("Choose your difficulty:")
                .AddChoices(Enum.GetValues<Difficulty>()));
            Game game = new(choice, difficulty);
            db.AddGame(game.StartGame());
            break;
        case Menu.History:
            db.PrintResults();
            break;

    }




}
