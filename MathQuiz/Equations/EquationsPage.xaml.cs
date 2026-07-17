using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MathQuiz.Equations
{
    public partial class EquationsPage : Page
    {
        private EquationsEngine _quiz;
        private int _score = 0;
        private int _indexOfEquation = 1;

        public EquationsPage()
        {
            InitializeComponent();

            _quiz = new EquationsEngine();
            FeedbackText.Text = "";

            AskNewQuestion();
        }
        private void AskNewQuestion()
        {
            FeedbackText.Text = "";

            _quiz.GenerateNewQuestion();
            ExerciseText.Text = $"{_indexOfEquation}. Enter the solution.";
            _indexOfEquation++;

            ScoreText.Text = $"Score: {_score}";
            EquationText.Text = $"{_quiz.CurrentEquation} =";

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
                    FeedbackText.Foreground = Brushes.LightGreen;
                    FeedbackText.Text = "Correct!";
                    _score++;
                    await Task.Delay(1500);

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
