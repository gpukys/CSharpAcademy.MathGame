using Spectre.Console;
using System;
using System.Linq;
using static MathGame.Enums;

namespace MathGame.Models
{
    internal abstract class Equation
    {
        protected int FirstOperand;
        protected int SecondOperand;
        protected string Question;
        protected Random random = new();
        protected Difficulty Difficulty;
        protected Equation(Difficulty difficulty)
        {
            Difficulty = difficulty;
            Initialize();
        }

        protected int Prompt(char sign)
        {
            Question = $"{FirstOperand} {sign} {SecondOperand}";
            return AnsiConsole.Ask<int>($"What is {Question}?");
        }

        protected Solution Submit(int answer, int expected)
        {
            return new Solution(this, answer, expected);
        }

        public virtual void Initialize()
        {
            switch (Difficulty)
            {
                case Difficulty.Hard:
                    FirstOperand = random.Next(100, 1000);
                    SecondOperand = random.Next(100, 1000);
                    break;
                case Difficulty.Medium:
                    FirstOperand = random.Next(10, 100);
                    SecondOperand = random.Next(10, 100);
                    break;
                default:
                    FirstOperand = random.Next(1, 10);
                    SecondOperand = random.Next(1, 10);
                    break;
            }
        }

        public abstract Solution Solve();
    }

    internal class Solution
    {
        Equation Equation;
        int Answer;
        int Expected;
        public Solution(Equation equation, int answer, int expected)
        {
            Equation = equation;
            Answer = answer;
            Expected = expected;
        }

        public bool IsCorrect()
        {
            return Answer == Expected;
        }
    }
}
