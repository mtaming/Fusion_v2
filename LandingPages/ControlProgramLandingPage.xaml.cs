using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ControlzEx.Theming;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using Fusion_v2.ViewMenu;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Fusion_v2.LandingPages
{
    /// <summary>
    /// Interaction logic for ControlProgramLandingPage.xaml
    /// </summary>
    public partial class ControlProgramLandingPage : MetroWindow
    {
        public ControlProgramLandingPage()
        {
            InitializeComponent();
            
            ThemeManager.Current.ChangeTheme(this, "Light.Orange");
            Style = (Style)FindResource(typeof(Window));
            xpndMachine.Width = 72;
        }

        private void cpLogout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "Fusion Logout", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {

            }
            else
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
        }

        private void xCP_Collapsed(object sender, RoutedEventArgs e)
        {
            xpndMachine.Width = 72;
            sideBarContProg.Visibility = Visibility.Collapsed;
            logoExpanded.Visibility = Visibility.Collapsed;
            gridIcon.Visibility = Visibility.Visible;
        }

        private void xCP_Expanded(object sender, RoutedEventArgs e)
        {
            xpndMachine.Width = 300;
            sideBarContProg.Visibility = Visibility.Visible;
            logoExpanded.Visibility = Visibility.Visible;
            gridIcon.Visibility = Visibility.Collapsed;
        }

        private void homeGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            hometb.Foreground = Brushes.WhiteSmoke;
            homeimg.Foreground = Brushes.WhiteSmoke;
        }

        private void homeGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            hometb.Foreground = Brushes.WhiteSmoke;
            homeimg.Foreground = Brushes.WhiteSmoke;
        }

        private void homeGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void cntrlProgram_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cntrlProgram.IsExpanded = true;
        }

        private void cntrProgram_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cntrlProgram.IsExpanded = false;
        }

        private void cpNavigator_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Navigator n = new Navigator();
            PageFrame.Content = n.Content;
            this.Title = "Control Program Navigator";
        }
    }
}
