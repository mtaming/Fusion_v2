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
using Fusion_v2.LandingPages;

namespace Fusion_v2.LandingPages
{
    /// <summary>
    /// Interaction logic for CtrlPgrmLandingPage.xaml
    /// </summary>
    public partial class CtrlPgrmLandingPage : MetroWindow
    {
        public CtrlPgrmLandingPage()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Light.Orange");
        }
        bool MenuClosed = false;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MenuClosed)
            {
                Storyboard openMenu = (Storyboard)button.FindResource("OpenMenu");
                openMenu.Begin();
                button.Content = FindResource("close");
            }
            else
            {
                Storyboard closeMenu = (Storyboard)button.FindResource("CloseMenu");
                closeMenu.Begin();
                button.Content = FindResource("open");
            }
            MenuClosed = !MenuClosed;
        }

        private void cntrlProgram_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cntrlProgram.IsExpanded = true;
        }

        private void cntrlProgram_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cntrlProgram.IsExpanded = false;
        }

        private void cpNavigator_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Navigator2 n = new Navigator2();
            PageFrame.Content = n.Content;
            this.Title = "Control Program Navigator";
            title.Text = "Navigator";
        }

        private void homeGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
            title.Text = "";
        }
    }
}
