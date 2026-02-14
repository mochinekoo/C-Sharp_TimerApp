using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;

namespace Timer_WPFApplication
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public Timer timer;
        public int count = 0;
        public TimerStatus status = TimerStatus.SLEEPING;

        public MainViewModel()
        {
            ButtonCommand = new ButtonCommand(this);
        }

        public ButtonCommand ButtonCommand { get; set; }

        private int selectIndex_ = 0;
        public int SelectIndex
        {
            get { return selectIndex_; }
            set
            {
                selectIndex_ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectIndex)));

            }
        }

        private string timerText_ = "";
        public string TimerText
        {
            get { return timerText_; }
            set
            {
                timerText_ = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TimerText)));
            }
        }
    }

    enum TimerStatus
    {
        RUNNING,
        SLEEPING
    }
}
