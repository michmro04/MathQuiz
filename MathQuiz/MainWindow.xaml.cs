using System.Windows;

namespace MathQuiz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new HomePage());
        }
    }
}