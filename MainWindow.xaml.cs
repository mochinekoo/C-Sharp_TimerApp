using CommunityToolkit.WinUI.Notifications;
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
                Dispatcher.Invoke(() =>
                {
                    if (mainViewModel.status == TimerStatus.SLEEPING) return;

                    if (mainViewModel.SelectIndex == 0) {
                        if (mainViewModel.count - 1 < 0) {
                            new ToastContentBuilder()
                                .AddText("タイマーが終了したよ")
                                .Show();
                            mainViewModel.timer.Dispose();
                        }
                        else {
                            mainViewModel.count--;
                        }                           
                    }
                    else if (mainViewModel.SelectIndex == 1) {
                        mainViewModel.count++;
                    }

                    //mainViewModel.TimerText = mainViewModel.count.ToString();

                    TimeSpan timeSpan = TimeSpan.FromSeconds(Math.Max(0, mainViewModel.count));
                    mainViewModel.TimerText = timeSpan.ToString(@"hh\:mm\:ss");

                });
            };
            mainViewModel.timer = new Timer(callback, null, 0, 1000);
        }
    }
}
