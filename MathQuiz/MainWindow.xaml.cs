using System.Windows;
using System.Windows.Media;

namespace MathQuiz
{
    public partial class MainWindow : Window
    {
        private QuizEngine _quiz;
        public MainWindow()
        {
            InitializeComponent();

            _quiz = new QuizEngine();
            
            AskNewQuestion();
        }

        private void AskNewQuestion()
        {
            _quiz.GenerateNewQuestion();
            EquationText.Text = _quiz.CurrentEquation;

            AnswerInput.Text = ""; //clearing textbox for new answer
            AnswerInput.Focus(); //setting focus to the answer input box
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = AnswerInput.Text;

            if(int.TryParse(userInput, out int parsedAnswer))
            {
                if (_quiz.CheckAnswer(parsedAnswer))
                {
                    FeedbackText.Foreground = Brushes.Green;
                    FeedbackText.Text = "Correct!";
                    AskNewQuestion();
                }
                else if (!_quiz.CheckAnswer(parsedAnswer))
                {
                    FeedbackText.Foreground = Brushes.Red;
                    FeedbackText.Text = $"Incorrect! Answer is {_quiz.CurrentAnswer}.";
                    AskNewQuestion();
                }
            }
            else
            {
                FeedbackText.Foreground = Brushes.Orange;
                FeedbackText.Text = "Please enter a integer number.";
            }

        }
    }
}