using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuiz
{
    internal interface IQuizEngine
    {
        string CurrentTask { get; }
        double CurrentAnswer { get; }


        void GenerateNewQuestion();
        bool CheckAnswer(double userAnswer);
    }
}
