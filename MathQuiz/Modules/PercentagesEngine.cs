using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuiz.Modules
{
    public class PercentagesEngine : IQuizEngine
    {
        private Random random;
        public string CurrentTask { get; private set; }
        public double CurrentAnswer { get; private set; }


        public PercentagesEngine()
        {
            random = new Random();
            CurrentTask = "";
            CurrentAnswer = 0;
        }

        public void GenerateNewQuestion()
        {
            int baseNumber = random.Next(1, 10001);
            int percentage = random.Next(1, 101);
            CurrentTask = $"What is {percentage}% of {baseNumber}?";
            CurrentAnswer = (percentage / 100.0) * baseNumber;
        }

        public bool CheckAnswer(double userAnswer)
        {
            return userAnswer == CurrentAnswer;
        }
    }
}
