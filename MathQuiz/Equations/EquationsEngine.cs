namespace MathQuiz.Equations
{
    public class EquationsEngine : IQuizEngine
    {
        private Random _random;
        public string CurrentTask { get; private set; }
        public double CurrentAnswer { get; private set; }

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
            CurrentTask = "";
            CurrentAnswer = 0;
        }

        public void GenerateNewQuestion()
        {
            int a = _random.Next(1, 11);
            int b = _random.Next(1, 11);
            
            Operation operation = (Operation)_random.Next(0, 4);

            switch (operation) {
                case Operation.Addition:
                    CurrentTask = $"{a} + {b}";
                    CurrentAnswer = a + b;
                    break;

                case Operation.Subtraction:
                    CurrentTask = $"{a} - {b}";
                    CurrentAnswer = a - b;
                    break;

                case Operation.Multiplication:
                    CurrentTask = $"{a} * {b}";
                    CurrentAnswer = a * b;
                    break;

                case Operation.Division:
                    double correctResult = _random.Next(1, 11);
                    a = (int)(b * correctResult); // Ensure a is a multiple of b
                    CurrentTask = $"{a} : {b}";
                    CurrentAnswer = correctResult;
                    break;
            }
        }

        public bool CheckAnswer(double userAnswer)
        {
            return userAnswer == CurrentAnswer;
        }

    }
}
