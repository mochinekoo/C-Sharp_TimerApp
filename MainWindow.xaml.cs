using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Timer_WPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            MainViewModel mainViewModel = (MainViewModel) DataContext;

            TimerCallback callback = state =>
            {
                if (mainViewModel.status == TimerStatus.SLEEPING) return;

                if (mainViewModel.SelectIndex == 0)
                {
                    mainViewModel.count--;
                }
                else if (mainViewModel.SelectIndex == 1)
                {
                    mainViewModel.count++;
                }
                    
                Dispatcher.Invoke(() =>
                {
                    mainViewModel.TimerText = mainViewModel.count.ToString();
                });
            };
            mainViewModel.timer = new Timer(callback, null, 0, 1000);
        }
    }
}