using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for SetupApplication.xaml
    /// </summary>
    public partial class SetupApplication : Page
    {
        public SetupApplication()
        {
            InitializeComponent();

            usePAOApp.IsChecked = true;

            if (Properties.Settings.Default.defaultHome == "Navigator")
            {
                useCPNApp.IsChecked = true;
            }
            else if (Properties.Settings.Default.defaultHome == "IFM")
            {
                useIFMApp.IsChecked = true;
            }
            else
            {
                usePAOApp.IsChecked = true;
            }

            //gbFolderSettingsQuery();
        }

        private void restoreDefault_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Restore to Default Settings?", "Application Settings", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                Properties.Settings.Default.defaultHome = "";
                Properties.Settings.Default.Save();
                MessageBox.Show("Settings successfully restored to default", "Application Settings", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void saveLocApp_Click(object sender, RoutedEventArgs e)
        {

            if (usePAOApp.IsChecked == true)
            {
                Properties.Settings.Default.defaultHome = "";
                Properties.Settings.Default.Save();
            }
            else if (useCPNApp.IsChecked == true)
            {
                Properties.Settings.Default.defaultHome = "Navigator";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.defaultHome = "IFM";
                Properties.Settings.Default.Save();
            }
            MessageBox.Show("Settings successfully saved.", "Application Settings", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //FOLDER SETTINGS - GLOBAL
        //private void gbFolderSettingsQuery()
        //{
        //    SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
        //    sqlCon.Open();
        //    string query = "SELECT * FROM SETTINGS WHERE settings_name = 'NC Program Folder'";
        //    SqlCommand cmd = new SqlCommand(query, sqlCon);
        //    var dr = cmd.ExecuteReader();

        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            string val = dr["settings_value"].ToString();
        //            gbNCProgFolderTb.Text = val;
        //        }
        //    }

        //    dr.Close();
        //    sqlCon.Close();

        //    sqlCon.Open();
        //    String query1 = "SELECT * FROM SETTINGS WHERE settings_name = 'Incoming File Manager Folder' ";
        //    SqlCommand cmd1 = new SqlCommand(query1, sqlCon);
        //    dr = cmd1.ExecuteReader();

        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            string val1 = dr["settings_value"].ToString();
        //            gbIFMFolderTb.Text = val1;
        //        }
        //    }

        //    dr.Close();
        //    sqlCon.Close();
        //}

        //private void gbFolderBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    FolderBrowserDialog diag = new FolderBrowserDialog();
        //    diag.Description = "Please select NC Program Folder";
        //    if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        string folder = diag.SelectedPath;  //selected folder path
        //        gbNCProgFolderTb.Text = folder;
        //    }
        //}

        //private void gbIFMFolderBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    FolderBrowserDialog diag = new FolderBrowserDialog();
        //    diag.Description = "Please select Incoming File Manager Folder";
        //    if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        string folder = diag.SelectedPath;  //selected folder path
        //        gbIFMFolderTb.Text = folder;
        //    }
        //}

        //private void gbPrefSettingsQuery()
        //{
        //    SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
        //    sqlCon.Open();
        //    string query = "SELECT * FROM CtrlProgramRefence WHERE id = '1'";
        //    SqlCommand cmd = new SqlCommand(query, sqlCon);
        //    var dr = cmd.ExecuteReader();

        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            string ridLabel = dr["RIDLabel"].ToString();
        //            string rridLabel = dr["RRIDLabel"].ToString();

        //            gbPrefRIDTb.Text = ridLabel;
        //            gbPrefRRIDTb.Text = rridLabel;
        //        }
        //    }
        //}

        //private void gbFolderBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    FolderBrowserDialog diag = new FolderBrowserDialog();
        //    if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        string folder = diag.SelectedPath;  //selected folder path
        //        gbNCProgFolderTb.Text = folder;
        //    }
        //}

        //private void gbIFMFolderBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    FolderBrowserDialog diag = new FolderBrowserDialog();
        //    if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        string folder = diag.SelectedPath;  //selected folder path
        //        gbIFMFolderTb.Text = folder;
        //    }
        //}

        //private void gbResDefFolderBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    gbNCProgFolderTb.Text = "C:\\Program Files (x86)\\Nexas America\\Fusion Working Folder\\NC Programs";
        //    gbIFMFolderTb.Text = "C:\\Program Files (x86)\\Nexas America\\Fusion Working Folder\\Incoming File Manager Folder";

        //    MessageBox.Show("Please save changes after restoring default folders.", "Application Settings", MessageBoxButton.OK, MessageBoxImage.Information);
        //    gbResDefFolderBtn.IsEnabled = false;
        //}
    }
}
