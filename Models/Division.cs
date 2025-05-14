using System.Linq;
using static MathGame.Enums;

namespace MathGame.Models
{
    class Division : Equation
    {
        public Division(Difficulty difficulty) : base(difficulty)
        {
        }

        public override Solution Solve()
        {
            var userAnswer = Prompt('/');
            var expectedAnswer = FirstOperand / SecondOperand;

            return Submit(userAnswer, expectedAnswer);
        }

        public override void Initialize()
        {
            switch (Difficulty)
            {
                case Enums.Difficulty.Hard:
                    FirstOperand = random.Next(2, 11);
                    SecondOperand = random.Next(2, 11);
                    break;
                case Enums.Difficulty.Medium:
                    FirstOperand = random.Next(2, 8);
                    SecondOperand = random.Next(2, 8);
                    break;
                default:
                    FirstOperand = random.Next(2, 5);
                    SecondOperand = random.Next(2, 5);
                    break;
            }
            FirstOperand *= SecondOperand;
        }
    }
}
