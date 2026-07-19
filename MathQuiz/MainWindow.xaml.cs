using System.Windows;

namespace MathQuiz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Views.HomePage());
        }

        private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape)
            {
                if (MainFrame.Content is Views.HomePage)
                {
                    Application.Current.Shutdown();
                }
                else if (MainFrame.NavigationService.CanGoBack)
                {
                    MainFrame.NavigationService.GoBack();
                }
            }
        }
    }
}