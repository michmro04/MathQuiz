namespace MathQuiz
{
    public interface IQuizEngine
    {
        string CurrentTask { get; }
        double CurrentAnswer { get; }


        void GenerateNewQuestion();
        bool CheckAnswer(double userAnswer);
    }
}
