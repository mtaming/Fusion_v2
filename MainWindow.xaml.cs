using System;
using System.Windows;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Data;
using System.Windows.Input;
using Microsoft.Win32;
using Fusion_v2;
using MahApps.Metro.Controls;
using ControlzEx.Theming;
using System.Windows.Controls;

namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Light.Orange");
            Style = (Style)FindResource(typeof(Window));
            getConnStringData();
            iniData();
            
        }

       
        private void getConnStringData()
        {
            try
            {

                string p = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string folder = Path.Combine(p, "Nexas America");
                string db_ini = Path.Combine(folder, "db.ini");

                if (db_ini.Trim() != "")
                {
                    Properties.Settings.Default.dbIniFile = db_ini;
                    Properties.Settings.Default.Save();

                }
                string[] lines = File.ReadAllLines(db_ini);
                string dncFile = string.Empty;


                Properties.Settings.Default.dbServer = lines[0];
                Properties.Settings.Default.dbDataBase = lines[1];
                Properties.Settings.Default.dbUser = lines[2];
                Properties.Settings.Default.dbPass = Decrypt(lines[3]);

                if (lines[0] != "" || lines[1] != "" || lines[2] != "" || lines[3] != "")
                {
                    Properties.Settings.Default.dbConnString = "Server =" + Properties.Settings.Default.dbServer + ";" + "Database=" + Properties.Settings.Default.dbDataBase + ";" + "User ID = " + Properties.Settings.Default.dbUser + ";" + "Password=" + Properties.Settings.Default.dbPass + ";";

                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            { ex.ToString(); }
        }

        internal void SwitchScreen(UserControl screen)
        {
            throw new NotImplementedException();
        }

        //decrypt
        public string Decrypt(string strToDecrypt)
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
            {
                ex.ToString();
            }
            return res;
        }

        //encrypt
        public string encryptProcess(string strToHash)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Obj = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytesToHash = System.Text.Encoding.ASCII.GetBytes(strToHash);

            bytesToHash = md5Obj.ComputeHash(bytesToHash);

            string strResult = "";

            foreach (byte b in bytesToHash)
                strResult += b.ToString("x2");

            return strResult;
        }

        //login function
        private void logInFunct()
        {
            SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);

            sqlCon.Open();
            String query = "SELECT COUNT(1) FROM Users WHERE USERNAME=@Username AND PASSWORD=@Password";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.CommandType = System.Data.CommandType.Text;

            sqlCmd.Parameters.AddWithValue("@Username", txtUserName.Text);
            sqlCmd.Parameters.AddWithValue("@Password", encryptProcess(txtPassword.Password));
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            if (count == 1)
            {
                MessageBox.Show("Login Successful", "Fusion Production Document Organizer", MessageBoxButton.OK, MessageBoxImage.Information);
                Home hp = new Home();
                hp.Show();
                System.Threading.Thread.Sleep(100);
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect username/password", "Fusion Production Document Organizer", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            sqlCon.Close();
        }

        //login save
        private void LogInSaveData()
        {
            if (chkRem.IsChecked == true)
            {
                Properties.Settings.Default.loginUname = txtUserName.Text;
                Properties.Settings.Default.loginPass = txtPassword.Password;
                Properties.Settings.Default.loginChkRem = "yes";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.loginUname = txtUserName.Text;
                Properties.Settings.Default.loginPass = "";
                Properties.Settings.Default.loginChkRem = "no";
                Properties.Settings.Default.Save();
            }
        }

        //initialize data on load
        private void iniData()
        {
            if (Properties.Settings.Default.dbUser != string.Empty)
            {
                if (Properties.Settings.Default.loginChkRem == "yes")
                {
                    txtUserName.Text = Properties.Settings.Default.loginUname;
                    txtPassword.Password = Properties.Settings.Default.loginPass;
                    chkRem.IsChecked = true;

                }
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            logInFunct();
            LogInSaveData();
        }

        
    }
}
