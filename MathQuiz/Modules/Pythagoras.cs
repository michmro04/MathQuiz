using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MathQuiz.Modules
{
    public class Pythagoras : IQuizEngine
    {
        private Random _random;
        public string CurrentTask { get; private set; }
        public double CurrentAnswer { get; private set; }

        private readonly (int a, int b, int c)[] _triples = new[]
        {
            (3, 4, 5),
            (5, 12, 13),
            (8, 15, 17),
            (7, 24, 25),
            (9, 40, 41),
            (11, 60, 61),
            (12, 35, 37),
            (20, 21, 29)
        };

        public Pythagoras()
        {
            _random = new Random();
            CurrentTask = "";
            CurrentAnswer = 0;
        }


        public void GenerateNewQuestion()
        {
            int multiplier = _random.Next(1, 6);
            var triple = _triples[_random.Next(_triples.Length)];

            int missingSideIndex = _random.Next(3);

            switch (missingSideIndex)
            {
                case 0: //find a (leg)
                    {
                        int legB = triple.b * multiplier;
                        int legC = triple.c * multiplier;
                        CurrentAnswer = triple.a * multiplier;
                        CurrentTask = $"Find the length of missing leg of a right triangle with leg {legB} and hypotenuse {legC}";
                        break;
                    }

                case 1: //find b (leg)   
                    {
                        int legA = triple.a * multiplier;
                        int legC = triple.c * multiplier;
                        CurrentAnswer = triple.b * multiplier;
                        CurrentTask = $"Find the length of missing leg of a right triangle with leg {legA} and hypotenuse {legC}";
                        break;
                    }

                case 2: //find c (hypotenuse)
                    {
                        int legA = triple.a * multiplier;
                        int legB = triple.b * multiplier;
                        CurrentAnswer = triple.c * multiplier;
                        CurrentTask = $"Find the length of missing hypotenuse of a right triangle with legs {legA} and {legB}";
                        break;
                    }
            }
        }


        public bool CheckAnswer(double userAnswer)
        {
            return userAnswer == CurrentAnswer;
        }

    }
}
