using System;
using System.Net;
using System.Windows;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using Microsoft.Maps.MapControl.WPF;

namespace BingMapsMahAppsSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => DialogHost.IsOpen = true));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs e)
        {
            if ((bool)e.Parameter)
            {
                //System.Net.WebRequest.DefaultWebProxy = new WebProxy("", 80);
                //System.Net.WebRequest.DefaultWebProxy.Credentials = new NetworkCredential("", "");
                Map.CredentialsProvider = new ApplicationIdCredentialsProvider(AppIdTextBox.Text);
                Map.Mode = new RoadMode();
            }
            else
            {
                Application.Current.Shutdown(0);
            }
        }
    }
}