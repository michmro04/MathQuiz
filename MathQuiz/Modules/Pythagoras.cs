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
                case 0: //find a
                    {
                        int leg1 = triple.b * multiplier;
                        int leg2 = triple.c * multiplier;
                        CurrentAnswer = triple.a * multiplier;
                        CurrentTask = $"Find the length of missing side of a right triangle with sides {triple.b} and {triple.c}";
                        break;
                    }

                case 1: //find b        
                    {
                        int leg1 = triple.a * multiplier;
                        int leg2 = triple.c * multiplier;
                        CurrentAnswer = triple.b * multiplier;
                        CurrentTask = $"Find the length of missing side of a right triangle with sides {triple.a} and {triple.c}";
                        break;
                    }

                case 2: //find c
                    {
                        int leg1 = triple.a * multiplier;
                        int leg2 = triple.b * multiplier;
                        CurrentAnswer= triple.c * multiplier;
                        CurrentTask = $"Find the length of missing side of a right triangle with sides {triple.a} and {triple.b}";
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
