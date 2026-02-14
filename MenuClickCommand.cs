using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Timer_WPFApplication
{
    class MenuClickCommand
    {

        private readonly MainViewModel mainViewModel_;
        public ICommand ExitCommand { get; private set; }

        public MenuClickCommand(MainViewModel mainViewModel)
        {
            ExitCommand = new BaseCommand(RunExitCommand);
        }

        public void RunExitCommand()
        {
            Application.Current.Shutdown();
        }
    }
}
