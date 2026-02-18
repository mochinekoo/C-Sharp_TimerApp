using CommunityToolkit.WinUI.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Timer_WPFApplication {
    public class TimerManager {

        private static TimerManager instance;
        private Timer timer;
        public int count = 0;

        private TimerManager() { }

        public static TimerManager Instance {
            get {
                if (instance == null) {
                    instance = new TimerManager();
                }
                return instance;
            }
        }

        public void startTimer() {
            if (timer != null) return;
            MainViewModel mainViewModel = (MainViewModel) Application.Current.MainWindow.DataContext;

            TimerCallback callback = state => {
                Application.Current.Dispatcher.Invoke(() => {
                    if (timer == null) return;
                    if (mainViewModel.status == TimerStatus.SLEEPING) return;

                    if (mainViewModel.SelectIndex == 0) {
                        if (count - 1 < 0) {
                            new ToastContentBuilder()
                                .AddText("タイマーが終了したよ")
                                .Show();
                            timer.Dispose();
                            isRunning = false;
                        }
                        else {
                            count--;
                            isRunning = true;
                        }
                    }
                    else if (mainViewModel.SelectIndex == 1) {
                        count++;
                        isRunning = true;
                    }

                    //mainViewModel.TimerText = mainViewModel.count.ToString();

                    TimeSpan timeSpan = TimeSpan.FromSeconds(Math.Max(0, count));
                    mainViewModel.TimerText = timeSpan.ToString(@"hh\:mm\:ss");

                });
            };
            timer = new Timer(callback, null, 0, 1000);
        }

        public void stopTimer() {
            if (timer == null) return;
            timer.Dispose();
        }

        public bool isRunning {
            get;
            private set;
        }

    }
}
