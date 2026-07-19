using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Navigation;
using MathQuiz.Modules;
using MathQuiz.Services;

namespace MathQuiz
{   
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void EquationsButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputScoreGoal.Text, out int target))
            {
                QuizSession.TargetScore = target;
            }

            NavigationService.Navigate(new UniversalQuizPage(new Equations(), "Equations"));
        }

        private void MissingAngleButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputScoreGoal.Text, out int target))
            {
                QuizSession.TargetScore = target;
            }

            NavigationService.Navigate(new UniversalQuizPage(new MissingAngle(), "Missing Angle"));
        }

        private void PercentagesButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputScoreGoal.Text, out int target))
            {
                QuizSession.TargetScore = target;
            }

            NavigationService.Navigate(new UniversalQuizPage(new Percentages(), "Percentages"));
        }

        private void PythagorasButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputScoreGoal.Text, out int target))
            {
                QuizSession.TargetScore = target;
            }

            NavigationService.Navigate(new UniversalQuizPage(new Pythagoras(), "Pythagoras"));
        }

        private void InputScoreGoal_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int target = int.Parse(InputScoreGoal.Text);
                QuizSession.TargetScore = target;
            }
            catch
            {
                
            }
        }

        private void InputName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = InputName.Text;
            if (!string.IsNullOrWhiteSpace(name))
            {
                QuizSession.userName = name; 
            }
        }
    }
}
