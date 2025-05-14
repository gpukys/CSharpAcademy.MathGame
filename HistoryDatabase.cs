using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal class HistoryDatabase
    {
        private readonly List<Game> games = new();
        private readonly Table table = new ();

        internal HistoryDatabase()
        {
            table.AddColumn("Game");
            table.AddColumn("Mode");
            table.AddColumn("Difficulty");
            table.AddColumn("Result");
            table.AddColumn("Time");
        }

        internal void AddGame(Game game)
        {
            games.Add(game);
            table.AddRow($"{games.Count}", $"{game.Operation}", $"{game.Difficulty}", $"{game.Correct}/{game.ROUND_LIMIT}", $"{game.GetElapsedTimeS()}s");
        }

        internal void PrintResults()
        {
            AnsiConsole.Write(table);
            Console.ReadKey();
        }
    }
}
