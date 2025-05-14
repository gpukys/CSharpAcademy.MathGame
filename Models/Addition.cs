using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathGame.Enums;

namespace MathGame.Models
{
    internal class Addition : Equation
    {
        public Addition(Difficulty difficulty) : base(difficulty)
        {
        }

        public override Solution Solve()
        {
            var userAnswer = Prompt('+');
            var expectedAnswer = FirstOperand + SecondOperand;
            return Submit(userAnswer, expectedAnswer);
        }
    }
}
