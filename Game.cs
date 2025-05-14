using MathGame.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static MathGame.Enums;

namespace MathGame
{
    internal class Game(Operation operation, Difficulty difficulty)
    {
        private readonly Stopwatch Timer = new Stopwatch();
        private byte Rounds = 1;
        internal byte Correct { get; private set; } = 0;
        internal readonly byte ROUND_LIMIT = 10;
        private readonly Random Rand = new Random();
        internal readonly Operation Operation = operation;
        internal readonly Difficulty Difficulty = difficulty;
        private readonly List<Solution> Solutions = new();

        internal Game StartGame()
        {
            Timer.Start();
            while (Rounds <= ROUND_LIMIT)
            {
                Console.Clear();
                AnsiConsole.MarkupLine($"[yellow]Round {Rounds} of {ROUND_LIMIT}[/]");
                AnsiConsole.MarkupLine("============================================");
                var solution = GetEquation(GetOperation(), Difficulty).Solve();
                if (solution.IsCorrect())
                {
                    Correct++;
                }
                Solutions.Add(solution);
                Rounds++;
            }
            Timer.Stop();
            AnsiConsole.MarkupLine($"Game finished! You took {GetElapsedTimeS()} seconds. You got {Correct} out of {ROUND_LIMIT} equations right");
            Console.ReadKey();
            return this;
        }

        private Operation GetOperation()
        {
            if (Operation == Operation.Random)
            {
                var filteredOperations = Enum.GetValues<Operation>().Cast<Operation>().Where(op => op != Operation.Random).ToArray();
                return filteredOperations[Rand.Next(filteredOperations.Length)];
            } else
            {
                return Operation;
            }
        }

        private Equation GetEquation(Operation operation, Difficulty difficulty) {
            switch (operation)
            {
                case Operation.Add:
                    return new Addition(difficulty);
                case Operation.Subtract:
                    return new Subtraction(difficulty);
                case Operation.Multiply:
                    return new Multiplication(difficulty);
                case Operation.Divide:
                    return new Division(difficulty);
                default:
                    throw new InvalidEnumArgumentException();
            }
        }

        internal int GetElapsedTimeS()
        {
            return Timer.Elapsed.Seconds;
        }
    }
}
