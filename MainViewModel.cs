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

        public MainViewModel()
        {

        }

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
    }
}
