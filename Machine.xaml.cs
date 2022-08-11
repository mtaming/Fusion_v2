using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for Machine.xaml
    /// </summary>
    public partial class Machine : Page
    {
        public Machine()
        {
            InitializeComponent();
            LoadMachinesQuery();
        }

        public void LoadMachinesQuery()
        {
            MachListBox.Items.Clear();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                string mach_query = "SELECT machine_name FROM MACHINE ORDER BY machine_name";
                SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string mach_name = reader["machine_name"].ToString();
                        MachListBox.Items.Add(mach_name);
                    }
                }
                MachListBox.SelectedIndex = 0;
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

       
        private void rbComNone_Click(object sender, RoutedEventArgs e)
        {
            FlashDNCGrid.Visibility = Visibility.Collapsed;
            FocasGrid.Visibility = Visibility.Collapsed;
            SocketGrid.Visibility = Visibility.Collapsed;
            FolderWatchGrid.Visibility = Visibility.Collapsed;
        }

        private void rbComFlashDNC_Checked(object sender, RoutedEventArgs e)
        {
            FlashDNCGrid.Visibility = Visibility.Visible;
            FocasGrid.Visibility = Visibility.Collapsed;
            SocketGrid.Visibility = Visibility.Collapsed;
            FolderWatchGrid.Visibility = Visibility.Collapsed;
        }

        private void rbComFocas_Checked(object sender, RoutedEventArgs e)
        {
            FlashDNCGrid.Visibility = Visibility.Collapsed;
            FocasGrid.Visibility = Visibility.Visible;
            SocketGrid.Visibility = Visibility.Collapsed;
            FolderWatchGrid.Visibility = Visibility.Collapsed;
        }

        private void rbComSocket_Checked(object sender, RoutedEventArgs e)
        {
            FlashDNCGrid.Visibility = Visibility.Collapsed;
            FocasGrid.Visibility = Visibility.Collapsed;
            SocketGrid.Visibility = Visibility.Visible;
            FolderWatchGrid.Visibility = Visibility.Collapsed;
        }

        private void rbComFolderWatch_Checked(object sender, RoutedEventArgs e)
        {
            FlashDNCGrid.Visibility = Visibility.Collapsed;
            FocasGrid.Visibility = Visibility.Collapsed;
            SocketGrid.Visibility = Visibility.Collapsed;
            FolderWatchGrid.Visibility = Visibility.Visible;
        }

        
    }
}
