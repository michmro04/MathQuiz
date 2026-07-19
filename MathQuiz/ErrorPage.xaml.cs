using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace MathQuiz
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

            SendReportButton.IsEnabled = false;

            ReportStatusText.Foreground = Brushes.Yellow;
            ReportStatusText.Text = "Connecting with SMTP server...";

            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;

                    client.Credentials = new System.Net.NetworkCredential(Secrets.BotEmail, Secrets.StmpPassword);

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(Secrets.BotEmail, "MathQuiz System - error report");
                        mail.To.Add(targetEmail);
                        mail.Subject = "MathQuiz Error Report";
                        mail.Body = body;

                        await client.SendMailAsync(mail);
                    }
                }

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
