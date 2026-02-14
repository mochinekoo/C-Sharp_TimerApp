using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Timer_WPFApplication
{
    class ButtonCommand
    {

        private readonly MainViewModel mainViewModel_;

        public ICommand StartCommand { get; private set; }

        public ButtonCommand(MainViewModel mainViewModel)
        {
            mainViewModel_ = mainViewModel;
            StartCommand = new BaseCommand(RunStartCommand);
        }

        private void RunStartCommand()
        {
            mainViewModel_.status = TimerStatus.RUNNING;
        }

    }
}
