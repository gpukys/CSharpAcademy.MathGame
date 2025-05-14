using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathGame.Enums;

namespace MathGame.Models
{
    class Multiplication : Equation
    {
        public Multiplication(Difficulty difficulty) : base(difficulty)
        {
        }

        public override Solution Solve()
        {
            var userAnswer = Prompt('*');
            var expectedAnswer = FirstOperand * SecondOperand;
            return Submit(userAnswer, expectedAnswer);
        }

        public override void Initialize()
        {
            switch (Difficulty)
            {
                case Enums.Difficulty.Hard:
                    FirstOperand = random.Next(5, 20);
                    SecondOperand = random.Next(5, 20);
                    break;
                case Enums.Difficulty.Medium:
                    FirstOperand = random.Next(2, 10);
                    SecondOperand = random.Next(2, 10);
                    break;
                default:
                    FirstOperand = random.Next(2, 5);
                    SecondOperand = random.Next(2, 5);
                    break;
            }
        }

    }
}
