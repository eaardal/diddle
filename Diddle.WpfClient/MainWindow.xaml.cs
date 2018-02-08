using System;
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
                TxtStatus.Text = "On";
                Title = "Diddle: On";
            }
            else
            {
                BrdrStatus.Background = new SolidColorBrush(Colors.DarkGray);
                TxtStatus.Text = "Off";
                Title = "Diddle: Off";
            }
        }

        private void OnEnableClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                FiddlerIISProxy.On();
                DrawStatus();
            }
            catch (Exception exception)
            {
                ShowMessageBoxWithError(exception);
            }
        }

        private void OnDisableClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                FiddlerIISProxy.Off();
                DrawStatus();
            }
            catch (Exception exception)
            {
                ShowMessageBoxWithError(exception);
            }
        }

        private void OnOpenDirectoryClicked(object sender, RoutedEventArgs e)
        {
            if (WwwrootDirectoryExists())
            {
                OpenWwwrootDirectory();
            }
            else
            {
                ShowMessageBoxForMissingWwwrootDirectory();    
            }
        }

        private void OnOpenFileClicked(object sender, RoutedEventArgs e)
        {
            if (WebConfigFileExists())
            {
                OpenWebConfigFile();
            }
            else
            {
                ShowMessageBoxForMissingWebConfig();
            }   
        }

        private static void OpenWebConfigFile()
        {
            Process.Start(FiddlerIISProxy.IISRootWebConfig);
        }

        private static void OpenWwwrootDirectory()
        {
            Process.Start("explorer", Path.GetDirectoryName(FiddlerIISProxy.IISRootWebConfig));
        }

        private static bool WebConfigFileExists()
        {
            return File.Exists(FiddlerIISProxy.IISRootWebConfig);
        }

        private static bool WwwrootDirectoryExists()
        {
            return Directory.Exists(Path.GetDirectoryName(FiddlerIISProxy.IISRootWebConfig));
        }

        private static void ShowMessageBoxForMissingWwwrootDirectory()
        {
            MessageBox.Show(
                $"The directory \"{Path.GetDirectoryName(FiddlerIISProxy.IISRootWebConfig)}\" does not exist. Is IIS enabled on your machine?",
                "Directory not found", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static void ShowMessageBoxForMissingWebConfig()
        {
            MessageBox.Show(
                $"The file \"{FiddlerIISProxy.IISRootWebConfig}\" does not exist. Enable Diddler to create this file automatically, then try to open it again.",
                "File not found", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static void ShowMessageBoxWithError(Exception exception)
        {
            MessageBox.Show(
                $"An error occurred. Are you running the app as Administrator?\n\n{exception.Message}\n{exception.StackTrace}",
                "An error occurred", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}