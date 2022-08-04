using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using DataGrid = System.Windows.Controls.DataGrid;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Collections;
using System.Windows.Documents;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Windows.Media;
using System.ComponentModel.DataAnnotations;

namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for SetupUsers.xaml
    /// </summary>
    public partial class SetupUsers : Page
    {
        public SetupUsers()
        {
            InitializeComponent();

            UserQuery();
        }

        //decrypt function
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

        ///
        //encrypt function
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
        ///

        public class userslist
        {
            public int userid { get; set; }
            public string username { get; set; }
            public string userlvl { get; set; }
            public string useremail { get; set; }
        }

        List<userslist> userdata = new List<userslist>();

        private void UserQuery()
        {
            try
            {
                UserDataGrid.ItemsSource = null;
                userdata = new List<userslist>();

                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);

                sqlCon.Open();
                String query = "SELECT * FROM Users ORDER BY ID DESC";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                var reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["ID"].ToString());
                        string uname = (string)reader["Username"].ToString();
                        int ulvl = int.Parse(reader["fkUserLevel"].ToString());
                        string email = (string)reader["Email"].ToString();

                        string userlvlstr;

                        if (ulvl == 1)
                        {
                            userlvlstr = "Administrator";
                        }
                        else
                        {
                            userlvlstr = "User";
                        }

                        userdata.Add(new userslist() { userid = id, username = uname, userlvl = userlvlstr, useremail = email });

                    }
                }
                UserDataGrid.ItemsSource = userdata;
                UserDataGrid.SelectedIndex = 0;

                reader.Close();
                sqlCon.Close();
            }
            catch (Exception ex){ ex.ToString(); }
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                {
                    SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                    sqlCon.Open();

                    var user = UserDataGrid.SelectedItem as userslist;
                    string userid = user.userid.ToString();

                    String query = "SELECT * FROM Users WHERE ID = '" + userid + "' ";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    SqlDataReader dr = sqlCmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int user_id = int.Parse(dr["ID"].ToString());
                            string uname = dr["Username"].ToString();
                            string pword = dr["Password"].ToString();
                            int ulvl = int.Parse(dr["fkUserLevel"].ToString());
                            string email = dr["Email"].ToString();

                            string encpas = DecryptProcess(pword);

                            userhiddenid.Text = userid;
                            userhiddenuname.Text = uname;
                            userhiddenpass.Text = encpas;
                            userhiddenlvl.Text = ulvl.ToString();
                            userhiddenemail.Text = email;
                        }
                    }
                    dr.Close();
                    sqlCon.Close();
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }

        //public static bool isValidEmail(string email)
        //{
        //    Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(w){2,3})+)$", RegexOptions.IgnoreCase);
        //    return emailRegex.IsMatch(email);
        //}

        // **************************************************** ADD USER FUNCTIONS **************************************************** //

        private void createUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserGrid.Visibility = Visibility.Visible;
        }

        private void closeadduserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserGrid.Visibility = Visibility.Collapsed;
            ClearAddData();
        }
        private void usernametxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string username = usernametxt.Text;
            if (username == "")
            {
                usernameMessage.Text = "Username cannot be blank.";
                usernameMessage.Visibility = Visibility.Visible;
                unameErrIcon.Visibility = Visibility.Visible;
                UserSucIcon.Visibility = Visibility.Collapsed;
                BtnAddUser.IsEnabled = false;
            }
            else if (username.Length < 5)
            {
                usernameMessage.Text = "Username should not be less than 5 characters.";
                usernameMessage.Visibility = Visibility.Visible;
                unameErrIcon.Visibility = Visibility.Visible;
                UserSucIcon.Visibility = Visibility.Collapsed;
                BtnAddUser.IsEnabled = false;
            }
            else
            {
                usernameMessage.Text = "";
                usernameMessage.Visibility = Visibility.Collapsed;
                unameErrIcon.Visibility = Visibility.Collapsed;
                UserSucIcon.Visibility = Visibility.Visible;
                BtnAddUser.IsEnabled = true;
            }

            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            String query = "SELECT * FROM Users";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            var reader = sqlCmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string uname = reader["Username"].ToString();
                    if (uname == username)
                    {
                        usernameMessage.Text = "Username already taken. Choose another.";
                        usernameMessage.Visibility = Visibility.Visible;
                        unameErrIcon.Visibility = Visibility.Visible;
                        UserSucIcon.Visibility = Visibility.Collapsed;
                        BtnAddUser.IsEnabled = false;
                    }
                }
            }
            reader.Close();
            sqlCon.Close();
        }

        private void passwordtxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = passwordtxt.Password;
            if (password.Length < 5)
            {
                PassMessage.Text = "Password should not be less than 5 characters.";
                PassMessage.Visibility = Visibility.Visible;
                passErrIcon.Visibility = Visibility.Visible;
                PassSucIcon.Visibility = Visibility.Collapsed;
            }
            else
            {
                PassMessage.Text = "";
                PassMessage.Visibility = Visibility.Collapsed;
                passErrIcon.Visibility = Visibility.Collapsed;
                PassSucIcon.Visibility = Visibility.Visible;
            }
        }

        private void ConPasswordTxt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = passwordtxt.Password;
            string conpassword = ConPasswordTxt.Password;

            if (conpassword == password)
            {
                ConPassMessage.Text = "Passwords match!";
                ConPassMessage.Visibility = Visibility.Visible;
                ConPassErrIcon.Visibility = Visibility.Collapsed;
                ConPassSucIcon.Visibility = Visibility.Visible;
                BtnAddUser.IsEnabled = true;
            }
            else
            {
                ConPassMessage.Text = "Passwords do not match!";
                ConPassMessage.Visibility = Visibility.Visible;
                ConPassErrIcon.Visibility = Visibility.Visible;
                ConPassSucIcon.Visibility = Visibility.Collapsed;
                BtnAddUser.IsEnabled = false;
            }
        }
        private void addUser()
        {
            int levelchoice;
            if (lvlcombo.Text == "User")
            {
                levelchoice = 2;
            }
            else
            {
                levelchoice = 1;
            }

            string encPass = encryptProcess(passwordtxt.Password);
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            String query = "INSERT INTO Users (Username, Password, fkUserLevel, Email) VALUES ('" + usernametxt.Text + "', '" + encPass + "', '" + levelchoice + "', '" + emailtxt.Text + "')";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.ExecuteNonQuery();

            MessageBox.Show("'" + usernametxt.Text + "' was successfully added to the database.", "User Manager", MessageBoxButton.OK, MessageBoxImage.Information);
            sqlCon.Close();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string email = emailtxt.Text;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(email);

            if (!isValidEmail && email != "")
            {
                MessageBox.Show("Please enter a valid email address.", "User Manager", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                AddUserGrid.Visibility = Visibility.Collapsed;
                addUser();
                UserQuery();
                ClearAddData();
            }
        }

        private void ClearAddData()
        {
            usernameMessage.Text = "";
            usernameMessage.Visibility = Visibility.Collapsed;
            unameErrIcon.Visibility = Visibility.Collapsed;
            UserSucIcon.Visibility = Visibility.Collapsed;
            BtnAddUser.IsEnabled = false;

            PassMessage.Text = "";
            PassMessage.Visibility = Visibility.Collapsed;
            passErrIcon.Visibility = Visibility.Collapsed;
            PassSucIcon.Visibility = Visibility.Collapsed;

            ConPassMessage.Text = "";
            ConPassMessage.Visibility = Visibility.Collapsed;
            ConPassErrIcon.Visibility = Visibility.Collapsed;
            ConPassSucIcon.Visibility = Visibility.Collapsed;

            usernametxt.Clear();
            passwordtxt.Clear();
            ConPasswordTxt.Clear();
            emailtxt.Clear();
            lvlcombo.Text = "";

            cbCtrlPgrmAddEditRem.IsChecked = false;
            cbAllowCtrlPgrmEditing.IsChecked = false;
            cbAllowCPSearching.IsChecked = false;
            cbRemReqId.IsChecked = false;
            cbRefId.IsChecked = false;
            cbCtrlPgrmGroup.IsChecked = false;
            cbAssocCust.IsChecked = false;
            cbFilename.IsChecked = false;
            cbDesc.IsChecked = false;
        }

        private void cbCtrlPgrmAddEditRem_Checked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you also want to allow permission for 'Control Program Editing' ?\n\n We recommend to enable this when permission for Control Programs is allowed.", "User Manager", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                cbAllowCtrlPgrmEditing.IsChecked = true;
            }
        }

        private void cbAllowCPSearching_Checked(object sender, RoutedEventArgs e)
        {
            cbRemReqId.IsEnabled = true;
            cbRefId.IsEnabled = true;
            cbCtrlPgrmGroup.IsEnabled = true;
            cbAssocCust.IsEnabled = true;
            cbFilename.IsEnabled = true;
            cbDesc.IsEnabled = true;

            cbRemReqId.IsChecked = true;
            cbRefId.IsChecked = true;
            cbCtrlPgrmGroup.IsChecked = true;
            cbAssocCust.IsChecked = true;
            cbFilename.IsChecked = true;
            cbDesc.IsChecked = true;
        }

        private void cbAllowCPSearching_Unchecked(object sender, RoutedEventArgs e)
        {
            cbRemReqId.IsEnabled = false;
            cbRefId.IsEnabled = false;
            cbCtrlPgrmGroup.IsEnabled = false;
            cbAssocCust.IsEnabled = false;
            cbFilename.IsEnabled = false;
            cbDesc.IsEnabled = false;

            cbRemReqId.IsChecked = false;
            cbRefId.IsChecked = false;
            cbCtrlPgrmGroup.IsChecked = false;
            cbAssocCust.IsChecked = false;
            cbFilename.IsChecked = false;
            cbDesc.IsChecked = false;
        }

        private void cbIFM_Checked(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you also want to allow permission for 'Incoming File Editing' ?\n\n We recommend to enable this when permission for Control Programs is allowed.", "User Manager", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                cbAllowIFEdit.IsChecked = true;
            }
        }

        private void cbPartOpCus_Checked(object sender, RoutedEventArgs e)
        {
            cbLockUnlockPer.IsEnabled = true;
        }

        private void cbPartOpCus_Unchecked(object sender, RoutedEventArgs e)
        {
            cbLockUnlockPer.IsEnabled = false;
        }

        // **************************************************** EDIT USER FUNCTIONS **************************************************** //
        private void editUserBtn_Click(object sender, RoutedEventArgs e)
        {
            string editUname = userhiddenuname.Text.ToString();
            EditUserGrid.Visibility = Visibility.Visible;
            lblEditUname.Content = "( " + editUname + " )";
            currentuserpassword.Focus();
            editemail.Text = userhiddenemail.Text;
            if (userhiddenlvl.Text == "1")
            {
                editlevel.Text = "Administrator";
            }
            else
            {
                editlevel.Text = "User";
            }

            string permissions = "";
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            String query = "SELECT Permissions1 FROM Users WHERE ID = '" + userhiddenid.Text + "' ";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            var dr = sqlCmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    permissions = dr["Permissions1"].ToString();
                    if (permissions.Contains("1"))
                    {
                        CbCtrlPgrmAddEditRem_Edit.IsChecked = true;
                    }
                    if (permissions.Contains("B"))
                    {
                        cbAllowCPSearch_Edit.IsChecked = true;

                    }
                }
            }
            dr.Close();
            sqlCon.Close();
        }

        private void closeedituserBtn_Click(object sender, RoutedEventArgs e)
        {
            EditUserGrid.Visibility = Visibility.Collapsed;
            CbCtrlPgrmAddEditRem_Edit.IsChecked = false;
            cbAllowCPSearch_Edit.IsChecked = false;
            //cbAllowCPSearching.IsChecked = false;
            //cbRemReqId.IsChecked = false;
            //cbRefId.IsChecked = false;
            //cbCtrlPgrmGroup.IsChecked = false;
            //cbAssocCust.IsChecked = false;
            //cbFilename.IsChecked = false;
            //cbDesc.IsChecked = false;
        }
        private void EditUserQuery()
        {
            
            //MessageBox.Show("Update successful.");
            int levelchoice;
            if (editlevel.Text == "User")
            {
                levelchoice = 2;
            }
            else
            {
                levelchoice = 1;
            }

          
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "UPDATE Users SET fkUserLevel = '" + levelchoice + "', Email = '" + editemail.Text + "' " +  " WHERE ID = '" + userhiddenid.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();

                MessageBox.Show("'" + userhiddenuname.Text + "' was successfully updated.", "User Manager", MessageBoxButton.OK, MessageBoxImage.Information);
                sqlCon.Close();
            
        }

        private void BtnUserUpdate_Click(object sender, RoutedEventArgs e)
        {
            string email = editemail.Text;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",RegexOptions.CultureInvariant |RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(email);

            if (!isValidEmail && email != "")
            {
                MessageBox.Show("Please enter a valid email address.", "User Manager", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                EditUserGrid.Visibility = Visibility.Collapsed;
                EditUserQuery();
                UserQuery();
            }
        }

        private void currentuserpassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string currPass = userhiddenpass.Text;
            MessageBox.Show(currPass);
            if (currPass == userhiddenpass.Text)
            {
                neweditpassword.IsEnabled = true;
                editconpassword.IsEnabled = true;
            }
        }

        // **************************************************** DELETE USER FUNCTIONS **************************************************** //
        private void BtnDelUser_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete '" + userhiddenuname.Text + "' ?", "User Manager", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "DELETE from Users WHERE ID = '" + userhiddenid.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();

                MessageBox.Show(" '" + userhiddenuname.Text + "' was deleted", "User Manager", MessageBoxButton.OK, MessageBoxImage.Information);
                sqlCon.Close();

                UserQuery();
            }
        }

        
    }
}
