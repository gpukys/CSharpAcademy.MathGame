using System.Linq;
using static MathGame.Enums;

namespace MathGame.Models
{
    internal class Subtraction : Equation
    {
        public Subtraction(Difficulty difficulty) : base(difficulty)
        {
        }

        public override Solution Solve()
        {
            var userAnswer = Prompt('-');
            var expectedAnswer = FirstOperand - SecondOperand;
            return Submit(userAnswer, expectedAnswer);
        }

        public override void Initialize()
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
            if (Difficulty != Difficulty.Hard && SecondOperand > FirstOperand)
            {
                var temp = SecondOperand;
                SecondOperand = FirstOperand;
                FirstOperand = temp;
            }
        }
    }
}
