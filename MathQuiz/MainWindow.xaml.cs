using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MathQuiz
{
    public partial class MainWindow : Window
    {
        private QuizEngine _quiz;
        private int _score = 0;
        private int _indexOfEquation = 1;

        public MainWindow()
        {
            InitializeComponent();

            _quiz = new QuizEngine();
            FeedbackText.Text = "";

            AskNewQuestion();
        }

        private void AskNewQuestion()
        {
            FeedbackText.Text = "";

            _quiz.GenerateNewQuestion();
            EquationText.Text = $"{_indexOfEquation}.  {_quiz.CurrentEquation}";
            _indexOfEquation++;

            ScoreText.Text = $"Score = {_score}";

            AnswerInput.Text = ""; //clearing textbox for new answer
            AnswerInput.Focus(); //setting focus to the answer input box
        }

        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = AnswerInput.Text;

            if (int.TryParse(userInput, out int parsedAnswer))
            {
                if (_quiz.CheckAnswer(parsedAnswer))
                {
                    FeedbackText.Foreground = Brushes.Green;
                    FeedbackText.Text = "Correct!";
                    _score++;
                    await Task.Delay(2000);

                    AskNewQuestion();
                }
                else if (!_quiz.CheckAnswer(parsedAnswer))
                {
                    FeedbackText.Foreground = Brushes.Red;
                    FeedbackText.Text = $"Incorrect! Answer is {_quiz.CurrentAnswer}.";
                    _score--;
                    await Task.Delay(1500);
                    AskNewQuestion();
                }
            }
            else
            {
                FeedbackText.Foreground = Brushes.Orange;
                FeedbackText.Text = "Please enter a integer number.";
            }

        }

        private void AnswerInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                CheckButton_Click(sender, e);
            }
        }
    }
}