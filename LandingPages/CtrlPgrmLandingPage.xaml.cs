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
using System.IO;
using System.Threading.Tasks;
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
            ThemeManager.Current.ChangeTheme(this, "Light.Blue");

            if (Properties.Settings.Default.defaultHome == "Navigator")
            {
                Navigator np = new Navigator();
                PageFrame.Content = np.Content;
                cpIcon.Foreground = Brushes.Khaki;
                ctrlPgrmTB.Foreground = Brushes.Khaki;
            }
            else if (Properties.Settings.Default.defaultHome == "IFM")
            {
                nav np = new nav();
                PageFrame.Content = np.Content;
            }
            else
            {
                PageFrame.Content = "";
            }

            //Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
        }

        //void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    if (MessageBox.Show("Are you sure you want to close fusion?", "Fusion Closing", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
        //    {
        //        e.Cancel = true;
        //    }
        //}

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

        private void cpNavigator_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Navigator n = new Navigator();
            PageFrame.Content = n.Content;
            title.Text = "Navigator";
        }

        private void ctrlPgrmLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Logout?", "Fusion Logout", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
                
            }
            catch (OutOfMemoryException)
            {

            }
        }

        
        private void ApplicationGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetupApplication sa = new SetupApplication();
            PageFrame.Content = sa.Content;
            title.Text = "Setup | Application";
        }
       private void setUpGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetupApplication sa = new SetupApplication();
            PageFrame.Content = sa.Content;
            title.Text = "Setup | Application";
            setUp.IsExpanded = true;
            cntrlProgram.IsExpanded = false;
            Process.IsExpanded = false;
            Reports.IsExpanded = false;
            Diagnostics.IsExpanded = false;

            setupIcon.Foreground = Brushes.Khaki;
            setUpTB.Foreground = Brushes.Khaki;

            macimg.Foreground = Brushes.White;
            cpIcon.Foreground = Brushes.White;
            ifmIcon.Foreground = Brushes.White;
            processIcon.Foreground = Brushes.White;
            readFDNCicon.Foreground = Brushes.White;
            sendBroIcon.Foreground = Brushes.White;
            repICon.Foreground = Brushes.White;
            DiagIcon.Foreground = Brushes.White;

            mactb.Foreground = Brushes.White;
            ctrlPgrmTB.Foreground = Brushes.White;
            ifmTb.Foreground = Brushes.White;
            cpProcess.Foreground = Brushes.White;
            TBrfDNC.Foreground = Brushes.White;
            sendBroTB.Foreground = Brushes.White;
            reportsTB.Foreground = Brushes.White;
            DiagTB.Foreground = Brushes.White;
        }

        private void machGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Machine m = new Machine();
            MachineManager m = new MachineManager();
            PageFrame.Content = m.Content;
            title.Text = "Machine";

            setUp.IsExpanded = false;
            cntrlProgram.IsExpanded = false;
            Process.IsExpanded = false;
            Reports.IsExpanded = false;
            Diagnostics.IsExpanded = false;

            setupIcon.Foreground = Brushes.White; 
            macimg.Foreground = Brushes.Khaki;
            cpIcon.Foreground = Brushes.White;
            ifmIcon.Foreground = Brushes.White;
            processIcon.Foreground = Brushes.White;
            readFDNCicon.Foreground = Brushes.White;
            sendBroIcon.Foreground = Brushes.White;
            repICon.Foreground = Brushes.White;
            DiagIcon.Foreground = Brushes.White;

            setUpTB.Foreground = Brushes.White;
            mactb.Foreground = Brushes.Khaki;
            ctrlPgrmTB.Foreground = Brushes.White;
            ifmTb.Foreground = Brushes.White;
            cpProcess.Foreground = Brushes.White;
            TBrfDNC.Foreground = Brushes.White;
            sendBroTB.Foreground = Brushes.White;
            reportsTB.Foreground = Brushes.White;
            DiagTB.Foreground = Brushes.White;
        }

        private void cpGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (cntrlProgram.IsSelected == true)
            {
                ctrlPgrmNav.IsSelected = true;
            }
            
            Navigator n = new Navigator();
            PageFrame.Content = n.Content;
            title.Text = "Control Programs | Navigator";

            setUp.IsExpanded = false;
            cntrlProgram.IsExpanded = true;
            Process.IsExpanded = false;
            Reports.IsExpanded = false;
            Diagnostics.IsExpanded = false;

            setupIcon.Foreground = Brushes.White;
            macimg.Foreground = Brushes.White;
            cpIcon.Foreground = Brushes.Khaki;
            ifmIcon.Foreground = Brushes.White;
            processIcon.Foreground = Brushes.White;
            readFDNCicon.Foreground = Brushes.White;
            sendBroIcon.Foreground = Brushes.White;
            repICon.Foreground = Brushes.White;
            DiagIcon.Foreground = Brushes.White;

            setUpTB.Foreground = Brushes.White;
            mactb.Foreground = Brushes.White;
            ctrlPgrmTB.Foreground = Brushes.Khaki;
            ifmTb.Foreground = Brushes.White;
            cpProcess.Foreground = Brushes.White;
            TBrfDNC.Foreground = Brushes.White;
            sendBroTB.Foreground = Brushes.White;
            reportsTB.Foreground = Brushes.White;
            DiagTB.Foreground = Brushes.White;
        }

        private void ifmGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            setUp.IsExpanded = false;
            cntrlProgram.IsExpanded = false;
            Process.IsExpanded = false;
            Reports.IsExpanded = false;
            Diagnostics.IsExpanded = false;

            setupIcon.Foreground = Brushes.White;
            macimg.Foreground = Brushes.White;
            cpIcon.Foreground = Brushes.White;
            ifmIcon.Foreground = Brushes.Khaki;
            processIcon.Foreground = Brushes.White;
            readFDNCicon.Foreground = Brushes.White;
            sendBroIcon.Foreground = Brushes.White;
            repICon.Foreground = Brushes.White;
            DiagIcon.Foreground = Brushes.White;

            setUpTB.Foreground = Brushes.White;
            mactb.Foreground = Brushes.White;
            ctrlPgrmTB.Foreground = Brushes.White;
            ifmTb.Foreground = Brushes.Khaki;
            cpProcess.Foreground = Brushes.White;
            TBrfDNC.Foreground = Brushes.White;
            sendBroTB.Foreground = Brushes.White;
            reportsTB.Foreground = Brushes.White;
            DiagTB.Foreground = Brushes.White;
        }

        private void processGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            setUp.IsExpanded = false;
            cntrlProgram.IsExpanded = false;
            Process.IsExpanded = true;
            Reports.IsExpanded = false;
            Diagnostics.IsExpanded = false;

            setupIcon.Foreground = Brushes.White;
            macimg.Foreground = Brushes.White;
            cpIcon.Foreground = Brushes.White;
            ifmIcon.Foreground = Brushes.White;
            processIcon.Foreground = Brushes.Khaki;
            readFDNCicon.Foreground = Brushes.White;
            sendBroIcon.Foreground = Brushes.White;
            repICon.Foreground = Brushes.White;
            DiagIcon.Foreground = Brushes.White;

            setUpTB.Foreground = Brushes.White;
            mactb.Foreground = Brushes.White;
            ctrlPgrmTB.Foreground = Brushes.White;
            ifmTb.Foreground = Brushes.White;
            cpProcess.Foreground = Brushes.Khaki;
            TBrfDNC.Foreground = Brushes.White;
            sendBroTB.Foreground = Brushes.White;
            reportsTB.Foreground = Brushes.White;
            DiagTB.Foreground = Brushes.White;
        }

        private void rfDNCGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            setUp.IsExpanded = false;
            cntrlProgram.IsExpanded = false;
            Process.IsExpanded = false;
            Reports.IsExpanded = false;
            Diagnostics.IsExpanded = false;

            setupIcon.Foreground = Brushes.White;
            macimg.Foreground = Brushes.White;
            cpIcon.Foreground = Brushes.White;
            ifmIcon.Foreground = Brushes.White;
            processIcon.Foreground = Brushes.White;
            readFDNCicon.Foreground = Brushes.Khaki;
            sendBroIcon.Foreground = Brushes.White;
            repICon.Foreground = Brushes.White;
            DiagIcon.Foreground = Brushes.White;

            setUpTB.Foreground = Brushes.White;
            mactb.Foreground = Brushes.White;
            ctrlPgrmTB.Foreground = Brushes.White;
            ifmTb.Foreground = Brushes.White;
            cpProcess.Foreground = Brushes.White;
            TBrfDNC.Foreground = Brushes.Khaki;
            sendBroTB.Foreground = Brushes.White;
            reportsTB.Foreground = Brushes.White;
            DiagTB.Foreground = Brushes.White;
        }

        private void sendBrowGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            setUp.IsExpanded = false;
            cntrlProgram.IsExpanded = false;
            Process.IsExpanded = false;
            Reports.IsExpanded = false;
            Diagnostics.IsExpanded = false;

            setupIcon.Foreground = Brushes.White;
            macimg.Foreground = Brushes.White;
            cpIcon.Foreground = Brushes.White;
            ifmIcon.Foreground = Brushes.White;
            processIcon.Foreground = Brushes.White;
            readFDNCicon.Foreground = Brushes.White;
            sendBroIcon.Foreground = Brushes.Khaki;
            repICon.Foreground = Brushes.White;
            DiagIcon.Foreground = Brushes.White;

            setUpTB.Foreground = Brushes.White;
            mactb.Foreground = Brushes.White;
            ctrlPgrmTB.Foreground = Brushes.White;
            ifmTb.Foreground = Brushes.White;
            cpProcess.Foreground = Brushes.White;
            TBrfDNC.Foreground = Brushes.White;
            sendBroTB.Foreground = Brushes.Khaki;
            reportsTB.Foreground = Brushes.White;
            DiagTB.Foreground = Brushes.White;
        }

        private void ReportsGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            setUp.IsExpanded = false;
            cntrlProgram.IsExpanded = false;
            Process.IsExpanded = false;
            Reports.IsExpanded = true;
            Diagnostics.IsExpanded = false;

            setupIcon.Foreground = Brushes.White;
            macimg.Foreground = Brushes.White;
            cpIcon.Foreground = Brushes.White;
            ifmIcon.Foreground = Brushes.White;
            processIcon.Foreground = Brushes.White;
            readFDNCicon.Foreground = Brushes.White;
            sendBroIcon.Foreground = Brushes.White;
            repICon.Foreground = Brushes.Khaki;
            DiagIcon.Foreground = Brushes.White;

            setUpTB.Foreground = Brushes.White;
            mactb.Foreground = Brushes.White;
            ctrlPgrmTB.Foreground = Brushes.White;
            ifmTb.Foreground = Brushes.White;
            cpProcess.Foreground = Brushes.White;
            TBrfDNC.Foreground = Brushes.White;
            sendBroTB.Foreground = Brushes.White;
            reportsTB.Foreground = Brushes.Khaki;
            DiagTB.Foreground = Brushes.White;
        }

        private void diagGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            setUp.IsExpanded = false;
            cntrlProgram.IsExpanded = false;
            Process.IsExpanded = false;
            Reports.IsExpanded = false;
            Diagnostics.IsExpanded = true;

            setupIcon.Foreground = Brushes.White;
            macimg.Foreground = Brushes.White;
            cpIcon.Foreground = Brushes.White;
            ifmIcon.Foreground = Brushes.White;
            processIcon.Foreground = Brushes.White;
            readFDNCicon.Foreground = Brushes.White;
            sendBroIcon.Foreground = Brushes.White;
            repICon.Foreground = Brushes.White;
            DiagIcon.Foreground = Brushes.Khaki;

            setUpTB.Foreground = Brushes.White;
            mactb.Foreground = Brushes.White;
            ctrlPgrmTB.Foreground = Brushes.White;
            ifmTb.Foreground = Brushes.White;
            cpProcess.Foreground = Brushes.White;
            TBrfDNC.Foreground = Brushes.White;
            sendBroTB.Foreground = Brushes.White;
            reportsTB.Foreground = Brushes.White;
            DiagTB.Foreground = Brushes.Khaki;
        }

        private void ServiceGrid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Service sv = new Service();
            PageFrame.Content = sv.Content;
            title.Text = "Setup | Service";
        }

        private void dncEvents_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetupDNCEvents dnc = new SetupDNCEvents();
            PageFrame.Content = dnc.Content;
            title.Text = "Setup | DNC Events";
        }

        private void Users_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetupUsers user = new SetupUsers();
            PageFrame.Content = user.Content;
            title.Text = "Setup | Users";
        }

        private void setUpLicence_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetupLicense license = new SetupLicense();
            PageFrame.Content = license.Content;
            title.Text = "Setup | License";
        }

        private void processCusMngr_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CustManager cusmngr = new CustManager();
            PageFrame.Content = cusmngr.Content;
            title.Text = "Process | Customer Manager";
        }
    }
}
