using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Diddle.Core;

namespace Diddle.WpfClient
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            DrawStatus();
        }

        private void DrawStatus()
        {
            var status = FiddlerIISProxy.Status();

            if (status)
            {
                BrdrStatus.Background = new SolidColorBrush(Colors.DarkSeaGreen);
                BrdrStatus.BorderBrush = new SolidColorBrush(Colors.DarkGreen);
                TxtStatus.Text = "On";
                Title = "Diddle: On";
            }
            else
            {
                BrdrStatus.Background = new SolidColorBrush(Colors.DarkGray);
                BrdrStatus.BorderBrush = new SolidColorBrush(Colors.DimGray);
                TxtStatus.Text = "Off";
                Title = "Diddle: Off";
            }
        }

        private void OnEnableClicked(object sender, RoutedEventArgs e)
        {
            FiddlerIISProxy.On();
            DrawStatus();
        }

        private void OnDisableClicked(object sender, RoutedEventArgs e)
        {
            FiddlerIISProxy.Off();
            DrawStatus();
        }

        private void OnOpenDirectoryClicked(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer", Path.GetDirectoryName(FiddlerIISProxy.IISRootWebConfig));
        }

        private void OnOpenFileClicked(object sender, RoutedEventArgs e)
        {
            Process.Start(FiddlerIISProxy.IISRootWebConfig);
        }
    }
}