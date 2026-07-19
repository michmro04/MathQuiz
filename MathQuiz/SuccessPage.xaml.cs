using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Net.Mail;
using System.Windows.Navigation;
using System.Threading.Tasks;

namespace MathQuiz
{
    public partial class SuccessPage : Page
    {
        public SuccessPage()
        {
            InitializeComponent();
            GenerateSummary();
        }

        public void GenerateSummary()
        {
            StringBuilder summaryBuilder = new StringBuilder();
            summaryBuilder.AppendLine("Congratulations! You've completed the quiz!");
            summaryBuilder.AppendLine($"Date: {DateTime.Now}");
            summaryBuilder.AppendLine($"Target Score: {QuizSession.TargetScore}");
            summaryBuilder.AppendLine($"Total Score: {QuizSession.GetTotalScores()}");


            foreach (var module in QuizSession.ModuleScores)
            {
                if (module.Value > 0)
                {
                    summaryBuilder.AppendLine($"{module.Key} -> {module.Value}");
                }
            }

            SummaryText.Text = summaryBuilder.ToString();
        }


        private void SendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            EmailStatusText.Foreground = Brushes.Yellow;
            EmailStatusText.Text = "Sending...";
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            QuizSession.ResetSession();
            NavigationService.Navigate(new HomePage());
        }

        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}
