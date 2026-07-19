using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;


namespace MathQuiz
{
    public partial class UniversalQuizPage : Page
    {
        private IQuizEngine _quiz;
        private int _score = 0;
        private int indexOfQuestion = 1;
        private string _moduleName;

        public UniversalQuizPage(IQuizEngine engine, string moduleName)
        {
            InitializeComponent();
            _quiz = engine;
            _moduleName = moduleName;
            FeedbackText.Text = "";
            AskNewQuestion();
        }

        private void AskNewQuestion()
        {
            FeedbackText.Text = "";

            _quiz.GenerateNewQuestion();
            ExerciseText.Text = $"{indexOfQuestion}. Enter the solution.";
            indexOfQuestion++;

            ScoreText.Text = $"Score: {_score}/ {QuizSession.TargetScore}";
            EquationText.Text = $"{_quiz.CurrentTask}";

            AnswerInput.Text = ""; //clearing textbox for new answer
            AnswerInput.Focus(); //setting focus to the answer input box
        }

        private async void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput = AnswerInput.Text;

            if (double.TryParse(userInput, out double parsedAnswer))
            {
                if (_quiz.CheckAnswer(parsedAnswer))
                {
                    FeedbackText.Foreground = Brushes.LightGreen;
                    FeedbackText.Text = "Correct!";
                    _score++;
                    QuizSession.AddPoint(_moduleName);

                    if(_score >= QuizSession.TargetScore)
                    {
                        FeedbackText.Text = "Congratulations! You've reached the target score!";
                        await Task.Delay(2000);
                        NavigationService.Navigate(new SuccessPage());
                        return;
                    }

                    await Task.Delay(1500);

                    AskNewQuestion();
                }
                else if (!_quiz.CheckAnswer(parsedAnswer))
                {
                    FeedbackText.Foreground = Brushes.Red;
                    FeedbackText.Text = $"Incorrect! Answer is {_quiz.CurrentAnswer}.";
                    _score--;
                    QuizSession.SubPoint(_moduleName);
                    await Task.Delay(1500);
                    AskNewQuestion();
                }
            }
            else
            {
                FeedbackText.Foreground = Brushes.Orange;
                FeedbackText.Text = "Please enter a decimal number.";
            }

        }

        private void AnswerInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                CheckButton_Click(sender, e);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


    }
}
