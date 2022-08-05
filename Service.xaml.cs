using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Interaction logic for Service.xaml
    /// </summary>
    public partial class Service : Page
    {
        public Service()
        {
            InitializeComponent();
            LoadData();
        }

        public class ftpuserlistsett
        {
            public int ftpuserid { get; set; }
            public string ftpusername { get; set; }
            public string ftpuserpass { get; set; }
            public string ftpuserdir { get; set; }
            public string ftpuseraccs { get; set; }
        }
        List<ftpuserlistsett> ftpuserdata = new List<ftpuserlistsett>();

        public string DecryptProcess(string strToDecrypt)
        {
            string res = string.Empty;
            try
            {
                string result = "";
                string dec = strToDecrypt;
                int i;

                for (i = 0; i < dec.Length - 1; i += 4)
                {
                    res = dec.Substring(i, 4);
                    result += Convert.ToChar(Convert.ToInt32(res, 16) / 114);
                }

                return result;
            }
            catch (Exception ex)
            { }
            return res;
        }

        //********************************** PROPERTIES **********************************\\
        private void LoadData()
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query2 = "SELECT * FROM WindowServiceConfiguration";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                var reader2 = sqlCmd2.ExecuteReader();

                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        string hostnm = reader2["HostName"].ToString();
                        string hostip = reader2["HostIPResolve"].ToString();
                        string logsfl = reader2["LogFilesPath"].ToString();
                        string workfl = reader2["WorkingFldr"].ToString();
                        string hostpt = reader2["HostPort"].ToString();
                        string orionp = reader2["OrionPort"].ToString();

                        servername.Text = hostnm;
                        serverip.Text = hostip;
                        logFilesFolder.Text = logsfl;
                        workingFolder.Text = workfl;
                        hostport.Text = hostpt;
                        orionport.Text = orionp;
                    }
                }

                reader2.Close();
                sqlCon.Close();
            }
            catch(Exception ex) { ex.ToString(); }

            //service version
            FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(@"C:\Program Files (x86)\Nexas America\Fusion Service\Fusion Communication Window Service.exe");
            serviceVersion.Text = myFileVersionInfo.FileVersion.ToString();
        }
        private void BtnOpenServices_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //********************************** FTP SERVER **********************************\\

        private void FTPUserLoad()
        {
            ftpuserdata = new List<ftpuserlistsett>();

            SqlConnection sqlCon1 = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon1.Open();
            String query = "SELECT * FROM FTPUsers";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon1);
            var reader = sqlCmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string usern = (string)reader["FTPUser"].ToString();
                    string userp = (string)reader["FTPPassword"].ToString();
                    string userdir = (string)reader["FTPDir"].ToString();
                    string useraccs = (string)reader["FTPuserAccess"].ToString();

                    ftpuserdata.Add(new ftpuserlistsett() { ftpuserid = id, ftpusername = usern, ftpuserpass = userp, ftpuserdir = userdir, ftpuseraccs = useraccs });
                }
            }
            ftpUsersDataGrid.ItemsSource = ftpuserdata;
            sqlCon1.Close();
        }
        private void BtnManageFTPUser_Click(object sender, RoutedEventArgs e)
        {
            FTPGrid.Visibility = Visibility.Visible;
            ftpUsersDataGrid.SelectedIndex = 0;
            FTPUserLoad();
        }

        private void BtnCloseFTP_Click(object sender, RoutedEventArgs e)
        {
            FTPGrid.Visibility = Visibility.Collapsed;
        }

        private void ftpUsersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                {
                    var usersel = ftpUsersDataGrid.SelectedItem as ftpuserlistsett;
                    string userchoicesel = usersel.ftpuserid.ToString();

                    SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                    sqlCon.Open();
                    String query = "SELECT id, FTPUser, FTPPassword, FTPDir, FTPuserAccess FROM FTPUsers WHERE id = '" + userchoicesel + "' ";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    SqlDataReader reader = sqlCmd.ExecuteReader();

                    reader.Read();
                    int id = int.Parse(reader["id"].ToString());
                    string fuser = reader["FTPUser"].ToString();
                    string fpass = reader["FTPPassword"].ToString();
                    string fdir = reader["FTPDir"].ToString();
                    string fusacc = reader["FTPuserAccess"].ToString();

                    createuserftp.Text = fuser;
                    createpassftp.Password = DecryptProcess(fpass);
                    createdirftp.Text = fdir;
                    userchoiceid.Text = id.ToString();

                    accessA.IsChecked = false;
                    accessR.IsChecked = false;
                    accessC.IsChecked = false;
                    accessX.IsChecked = false;
                    accessW.IsChecked = false;
                    accessD.IsChecked = false;

                    if (fusacc.Contains('A'))
                    {
                        accessA.IsChecked = true;
                        accessL.IsChecked = true;
                        accessR.IsChecked = true;
                        accessC.IsChecked = true;
                        accessX.IsChecked = true;
                        accessW.IsChecked = true;
                        accessD.IsChecked = true;
                    }
                    else
                    {
                        if (fusacc.Contains('L'))
                        {
                            accessL.IsChecked = true;
                        }

                        if (fusacc.Contains('X'))
                        {
                            accessX.IsChecked = true;
                        }

                        if (fusacc.Contains('C'))
                        {
                            accessC.IsChecked = true;
                        }

                        if (fusacc.Contains('R'))
                        {
                            accessR.IsChecked = true;
                        }

                        if (fusacc.Contains('W'))
                        {
                            accessW.IsChecked = true;
                        }

                        if (fusacc.Contains('D'))
                        {
                            accessD.IsChecked = true;
                        }
                    }
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }
    }
}
