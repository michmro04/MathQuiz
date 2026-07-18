using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuiz.Modules
{
    public class PercentagesEngine : IQuizEngine
    {
        private Random _random;
        public string CurrentTask { get; private set; }
        public double CurrentAnswer { get; private set; }


        public PercentagesEngine()
        {
            _random = new Random();
            CurrentTask = "";
            CurrentAnswer = 0;
        }

        public void GenerateNewQuestion()
        {
            int baseNumber = _random.Next(1, 10001);
            int percentage = _random.Next(1, 101);
            CurrentTask = $"What is {percentage}% of {baseNumber}?\n(round to integer)";
            CurrentAnswer = (percentage * baseNumber) / 100;
        }

        public bool CheckAnswer(double userAnswer)
        {
            return userAnswer == CurrentAnswer;
        }
    }
}
