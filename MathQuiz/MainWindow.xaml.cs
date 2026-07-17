using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

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