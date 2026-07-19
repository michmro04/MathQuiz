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
            summaryBuilder.AppendLine($"Student: {QuizSession.userName}");
            summaryBuilder.AppendLine($"Date: {DateTime.Now}");
            summaryBuilder.AppendLine($"Target Score: {QuizSession.TargetScore}");
            summaryBuilder.AppendLine($"Total Score: {QuizSession.GetTotalScores()}");


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

            SendEmailButton.IsEnabled = false;

            EmailStatusText.Foreground = Brushes.Yellow;
            EmailStatusText.Text = "Connecting with SMTP server...";

            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;

                    client.Credentials = new System.Net.NetworkCredential("mathquiz.bot.sender@gmail.com", Secrets.StmpPassword);

                    using(MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("mathquiz.bot.sender@gmail.com", "MathQuiz System");
                        mail.To.Add(targetEmail);
                        mail.Subject = "Math Quiz Summary";
                        mail.Body = body;

                        await client.SendMailAsync(mail);
                    }
                }

                EmailStatusText.Foreground = Brushes.Green;
                EmailStatusText.Text = "Email sent successfully!";
            }
            catch
            {
                MessageBox.Show("Error during sending an email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                EmailStatusText.Foreground = Brushes.Red;
                EmailStatusText.Text = "Error during sending an email";
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
            NavigationService.Navigate(new HomePage());
        }
    }
}
