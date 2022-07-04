using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlzEx.Theming;
using MahApps.Metro.Controls;
using Fusion_v2.LandingPages;
namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : MetroWindow
    {
        public Home()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Light.Orange");
        }

        private void homePageLogout_Click(object sender, RoutedEventArgs e)
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

        private void toControlProgram_Click(object sender, RoutedEventArgs e)
        {
            //LandingPages.ControlProgramLandingPage cp = new LandingPages.ControlProgramLandingPage();
            LandingPages.CtrlPgrmLandingPage cp = new LandingPages.CtrlPgrmLandingPage();
            cp.Show();
            this.Close();
        }

        private void cpGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            cpGrid.Height = 200;
        }

        private void cpGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            cpGrid.Height = 190;
        }
    }
}
