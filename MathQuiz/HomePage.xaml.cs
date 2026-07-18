using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MathQuiz.Equations;
using MathQuiz.MissingAngle;

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
            NavigationService.Navigate(new UniversalQuizPage(new EquationsEngine()));
        }

        private void MissingAngleButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UniversalQuizPage(new MissingAngleEngine()));
        }

    }
}
