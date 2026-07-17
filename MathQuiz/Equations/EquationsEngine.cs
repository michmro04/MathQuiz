using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuiz.Equations
{
    internal class EquationsEngine
    {
        private Random _random;
        public string CurrentEquation { get; private set; }
        public int CurrentAnswer { get; private set; }
        public string CurrentExercise { get; private set; } = string.Empty;

        public enum Operation
        {
            Addition,       //0
            Subtraction,    //1
            Multiplication, //2
            Division        //3
        }

        public EquationsEngine()
        {
            _random = new Random();
            CurrentEquation = "";
            CurrentAnswer = 0;
        }

        public void GenerateNewQuestion()
        {
            int a = _random.Next(1, 11);
            int b = _random.Next(1, 11);
            
            Operation operation = (Operation)_random.Next(0, 4);

            switch (operation) {
                case Operation.Addition:
                    CurrentEquation = $"{a} + {b}";
                    CurrentAnswer = a + b;
                    break;

                case Operation.Subtraction:
                    CurrentEquation = $"{a} - {b}";
                    CurrentAnswer = a - b;
                    break;

                case Operation.Multiplication:
                    CurrentEquation = $"{a} * {b}";
                    CurrentAnswer = a * b;
                    break;

                case Operation.Division:
                    int correctResult = _random.Next(1, 11);
                    a = b*correctResult; // Ensure a is a multiple of b
                    CurrentEquation = $"{a} : {b}";
                    CurrentAnswer = correctResult;
                    break;
            }
        }

        public bool CheckAnswer(int userAnswer)
        {
            return userAnswer == CurrentAnswer;
        }

    }
}
