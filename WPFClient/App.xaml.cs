using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            foreach (var wndOtherWindow in Application.Current.Windows)
            {
                if (wndOtherWindow is Window1)
                {
                    (wndOtherWindow as Window).Close();
                }
            }

        }

        private void PART_MINIMIZE_Click(object sender, RoutedEventArgs e)
        {

            foreach (var wndOtherWindow in Application.Current.Windows)
            {
                if (wndOtherWindow is Window1)
                {
                    (wndOtherWindow as Window).WindowState = WindowState.Minimized;
                }
            }
        }

        private void PART_TITLEBAR_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                MainWindow.DragMove();
        }
    }
}
