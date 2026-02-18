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
        public ICommand StopCommand {  get; private set; }

        public ButtonCommand(MainViewModel mainViewModel)
        {
            mainViewModel_ = mainViewModel;
            StartCommand = new BaseCommand(RunStartCommand);
            StopCommand = new BaseCommand(RunStopCommand);

        }

        private void RunStartCommand()
        {
            if (!TimerManager.Instance.isRunning) {
                TimerManager.Instance.startTimer();
            }
            mainViewModel_.status = TimerStatus.RUNNING;
        }

        private void RunStopCommand()
        {
            mainViewModel_.status = TimerStatus.SLEEPING;
        }

    }
}
