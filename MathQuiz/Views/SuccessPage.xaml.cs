using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Net.Mail;
using System.Windows.Navigation;
using System.Threading.Tasks;
using MathQuiz.Services;
using MathQuiz.Modules;
using MathQuiz.Views;

namespace MathQuiz.Views
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
            
            summaryBuilder.AppendLine($"Student: {QuizSession.userName}");
            summaryBuilder.AppendLine($"Date: {DateTime.Now}");
            summaryBuilder.AppendLine($"Target Score: {QuizSession.TargetScore}");
            summaryBuilder.AppendLine($"Total Score: {QuizSession.GetTotalScores()}");

            if(QuizSession.GetTotalScores() > QuizSession.TargetScore)
            {
                summaryBuilder.AppendLine($"Extra Points:  +{(QuizSession.GetTotalScores() - QuizSession.TargetScore)}");
            }

            foreach (var module in QuizSession.ModuleScores)
            {
                if (module.Value > 0)
                {
                    summaryBuilder.AppendLine($"  - {module.Key}: {module.Value}");
                }
            }

            SummaryText.Text = summaryBuilder.ToString();
        }


        private async void SendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            string targetEmail = EmailInput.Text;
            string body = SummaryText.Text;
            string subject = "Math Quiz Summary";

            SendEmailButton.IsEnabled = false;

            EmailStatusText.Foreground = Brushes.Yellow;
            EmailStatusText.Text = "Connecting with SMTP server...";

            try
            {
                //throw new Exception("Test exception"); //for testing error handling

                await EmailEngine.SendEmail(targetEmail, subject, body);

                EmailStatusText.Foreground = Brushes.Green;
                EmailStatusText.Text = "Email sent successfully!";
            }
            catch (Exception ex)
            {
                try
                {
                    NavigationService.Navigate(new ErrorPage($"Error on SuccessPage: {ex.Message}"));
                }
                catch
                {
                    MessageBox.Show("Error during sending an email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    EmailStatusText.Foreground = Brushes.Red;
                    EmailStatusText.Text = "Error during sending an email";
                }
            }
            finally
            {
                SendEmailButton.IsEnabled = true;
            }
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            QuizSession.ResetSession();
            NavigationService.Navigate(new HomePage());
        }

        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            QuizSession.ResetSession();
            NavigationService.Navigate(new HomePage());
        }
    }
}
