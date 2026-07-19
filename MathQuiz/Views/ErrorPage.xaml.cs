using MathQuiz.Services;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace MathQuiz.Views
{
    public partial class ErrorPage : Page
    {
        private string _technicalDescription;

        public ErrorPage(string errorMessage)
        {
            InitializeComponent();
            _technicalDescription = errorMessage;
        }

        private async void SendReportButton_Click(object sender, RoutedEventArgs e)
        {
            string targetEmail = Secrets.AdminEmail;
            string body = $"Message from user:\n{ErrorDescription.Text}\n\nTechnical Details:\n{_technicalDescription}";
            string subject = "MathQuiz Error Report";

            SendReportButton.IsEnabled = false;

            ReportStatusText.Foreground = Brushes.Yellow;
            ReportStatusText.Text = "Connecting with SMTP server...";

            try
            {
                
                await EmailEngine.SendEmail(targetEmail,subject, body);

                ReportStatusText.Foreground = Brushes.Green;
                ReportStatusText.Text = "Report sent successfully!";
            }
            catch
            {
                MessageBox.Show("Error during sending an email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ReportStatusText.Foreground = Brushes.Red;
                ReportStatusText.Text = "Error during sending an email";
            }
            finally
            {
                SendReportButton.IsEnabled = true;
            }
        }

        private void ReturnToMenu_Click(object sender, RoutedEventArgs e)
        {
            QuizSession.ResetSession();
            NavigationService.Navigate(new HomePage());
        }


    }
}
