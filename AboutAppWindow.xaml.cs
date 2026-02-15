using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Timer_WPFApplication {
    /// <summary>
    /// AboutAppWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AboutAppWindow : Window {
        public AboutAppWindow() {
            InitializeComponent();
        }

        public void OnAboutMenuClick(object sender, RequestNavigateEventArgs e) {
            Process.Start(new ProcessStartInfo {
                FileName = e.Uri.OriginalString,
                UseShellExecute = true
            });
            e.Handled = true;
        }
    }
}
