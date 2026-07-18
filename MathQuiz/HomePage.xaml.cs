using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Navigation;
using MathQuiz.Modules;

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
            NavigationService.Navigate(new UniversalQuizPage(new Equations()));
        }

        private void MissingAngleButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UniversalQuizPage(new MissingAngle()));
        }

        private void PercentagesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UniversalQuizPage(new Percentages()));
        }

        private void PythagorasButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UniversalQuizPage(new Pythagoras()));
        }
    }
}
