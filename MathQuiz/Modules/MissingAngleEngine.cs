namespace MathQuiz.Modules
{
    public class MissingAngleEngine : IQuizEngine
    {
        private Random _random;
        public string CurrentTask { get; private set; }
        public double CurrentAnswer { get; private set; }
        public MissingAngleEngine() { 
            _random = new Random();
            CurrentTask = "";
            CurrentAnswer = 0;
        }

        public enum Polygon
        {
            Triangle,       //0
            Quadrilateral,  //1
            //Pentagon,       //2
            //Hexagon         //3
        }

        public void GenerateNewQuestion()
        {
            Polygon polygon = (Polygon)_random.Next(0, Enum.GetValues(typeof(Polygon)).Length);

            switch (polygon)
            {
                case Polygon.Triangle:
                    {
                        int angle1 = _random.Next(1, 179);
                        int angle2 = _random.Next(1, (180-angle1-1));
                        CurrentTask = $"Triangle ({angle1}, {angle2}, x) - find the 'x' angle.";
                        CurrentAnswer = 180 - angle1 - angle2;
                        break;
                    }
                case Polygon.Quadrilateral:
                    {
                        int angle1 = _random.Next(30, 140);
                        int angle2 = _random.Next(30, 140);
                        int remaining = 360 - angle1 - angle2;
                        int maxAngle3 = Math.Min(140, remaining - 30);
                        int angle3 = _random.Next(30, maxAngle3);

                        CurrentAnswer = 360 - angle1 - angle2 - angle3;
                        CurrentTask = $"Quadrilateral ({angle1}, {angle2}, {angle3}, x) - find the 'x' angle.";
                        CurrentAnswer = 360 - angle1 - angle2 - angle3;
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
