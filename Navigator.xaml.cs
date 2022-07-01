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

namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for Navigator.xaml
    /// </summary>
    public partial class Navigator : Page
    {
        BackgroundWorker worker;
        public string selCbFilterCPG = "";
        public string selCbFilterAC = "";
        public string tempselCbFilterCPG = "";
        public string tempselCbFilterAC = "";
        public int dgSelRow = 0;   
        public Navigator()
        {
            InitializeComponent();
            //loadDataQuery();
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            ProgressBar1.Minimum = 1;
            ProgressBar1.Maximum = 100;
            worker.RunWorkerAsync();
            dgProgramFiles.IsEnabled = false;
            dgProgramFiles.SelectedIndex = 0;
            
        }

        //background worker
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= 10; ++i)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(300);
                    worker.ReportProgress(i * 10);
                }
            }
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double percent = (e.ProgressPercentage * 100) / 50;

            ProgressBar1.Value = Math.Round(percent, 0);

        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar1.Visibility = Visibility.Hidden;
            Loading.Visibility = Visibility.Hidden;
            cbRemReqId.IsChecked = true;
            cbRefId.IsChecked = true;
            cbCpg.IsChecked = true;
            cbAssCus.IsChecked = true;
            cbFileNm.IsChecked = true;
            cbDesc.IsChecked = true;
            cbFilter.Items.Add("Control Program Files");
            cbFilter.Items.Add("Reference ID");
            cbFilter.Items.Add("Remote Request ID");
            cbFilter.SelectedIndex = 0;
            dgProgramFiles.ItemsSource = contProgram().DefaultView;
            dgProgramFiles.IsEnabled = true;
            dgProgramFiles.SelectedIndex = 0;
            dgProgramFiles.Focus();
            LoadTextBoxesData();
            FillComboBoxCntrlPgrmGrp(cmbBoxCntrlPgrm);
            FillComboBoxAssocCust(cmbBoxAssocCust);
        }
        //end background worker
        
        private DataTable contProgram()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * FROM NCPROG";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                dt.Load(reader);
                reader.Close();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        private DataTable referenceID()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * FROM NCPROG";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                dt.Load(reader);
                reader.Close();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        private DataTable requestID()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * FROM NCPROG";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                dt.Load(reader);
                reader.Close();
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        private void cbFIilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string cmb = cbFilter.SelectedItem.ToString();
            
            if (cmb == "Reference ID")
            {
                if (txtSearch.Text == "" && selCbFilterCPG != tempselCbFilterCPG && selCbFilterAC != tempselCbFilterAC)
                {
                    refID.ItemsSource = referenceID().DefaultView;
                    refID.SelectedIndex = dgSelRow;
                    refID.Visibility = Visibility.Visible;
                    dgProgramFiles.Visibility = Visibility.Collapsed;
                    reqID.Visibility = Visibility.Collapsed;
                }
                else
                {
                    refID.Visibility = Visibility.Visible;
                    refID.SelectedIndex = dgSelRow;
                    dgProgramFiles.SelectedIndex = dgSelRow;
                    reqID.SelectedIndex = dgSelRow;
                    refID.ScrollIntoView(refID.SelectedItem);
                    refID.UpdateLayout();
                    dgProgramFiles.Visibility = Visibility.Collapsed;
                    reqID.Visibility = Visibility.Collapsed;
                }
            }
            else if (cmb == "Control Program Files")
            {
                if (txtSearch.Text == "" &&  selCbFilterCPG != tempselCbFilterCPG && selCbFilterAC != tempselCbFilterAC)
                {
                    dgProgramFiles.ItemsSource = contProgram().DefaultView;
                    dgProgramFiles.SelectedIndex = 0;
                    dgProgramFiles.Visibility = Visibility.Visible;
                    refID.Visibility = Visibility.Collapsed;
                    reqID.Visibility = Visibility.Collapsed;
                }
                else
                {
                    dgProgramFiles.Visibility = Visibility.Visible;
                    refID.SelectedIndex = dgSelRow;
                    dgProgramFiles.SelectedIndex = dgSelRow;
                    reqID.SelectedIndex = dgSelRow;
                    dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
                    dgProgramFiles.UpdateLayout();
                    refID.Visibility = Visibility.Collapsed;
                    reqID.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                if (txtSearch.Text == "" && selCbFilterCPG != tempselCbFilterCPG && selCbFilterAC != tempselCbFilterAC)
                {
                    reqID.ItemsSource = requestID().DefaultView;
                    reqID.SelectedIndex = 0;
                    reqID.Visibility = Visibility.Visible;
                    dgProgramFiles.Visibility = Visibility.Collapsed;
                    refID.Visibility = Visibility.Collapsed;
                }
                else
                {
                    reqID.Visibility = Visibility.Visible;
                    refID.SelectedIndex = dgSelRow;
                    dgProgramFiles.SelectedIndex = dgSelRow;
                    reqID.SelectedIndex = dgSelRow;
                    reqID.ScrollIntoView(reqID.SelectedItem);
                    reqID.UpdateLayout();
                    dgProgramFiles.Visibility = Visibility.Collapsed;
                    refID.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void LoadTextBoxesData()
        {
            string id = contProgram().Rows[0]["id"].ToString();
            string customerId = "";
            lstBoxAssocCus.Items.Clear();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * from[NCPROG] INNER JOIN[Machine_Groups] ON NCPROG.fkMachGroupId = machine_group_id WHERE NCPROG.id = " + id + "  ORDER BY filename ASC";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFilename.Text = reader["filename"].ToString();
                    txtBoxPath.Text = reader["programPointer"].ToString();
                    txtBoxCntrllPgrmGrp.Text = reader["machine_group_name"].ToString();

                    txtBoxRefID.Text = reader["UniqueReference"].ToString();
                    txtBoxRemReqId.Text = reader["remoteCallId"].ToString();
                    txtBoxRev.Text = reader["revision_date"].ToString();

                    string filePath = reader["programPointer"].ToString();
                    DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                    txtBoxLastModified.Text = modification.ToString();
                    txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                    string custId = reader["fkCustId"].ToString();

                    customerId = custId;
                    if (custId == "")
                    {
                        customerId = "1";
                    }

                    byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                    txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";

                    txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                    txtBotView.ScrollToEnd();

                }
                reader.Close();
                sqlCon.Close();

                sqlCon.Open();
                String query2 = "SELECT * FROM CUSTOMERS  WHERE customer_id = '" + customerId + "' ";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                SqlDataReader dr2 = sqlCmd2.ExecuteReader();

                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        //string cusid = dr2["customer_id"].ToString();
                        int cusid = int.Parse(dr2["customer_id"].ToString());
                        string cusnm = dr2["customer_name"].ToString();

                        if (customerId == cusid.ToString())
                        {
                            lstBoxAssocCus.Items.Add(cusnm);
                        }
                    }
                }
                dr2.Close();
                sqlCon.Close();

            }
            catch (Exception e) { e.ToString(); }
        }
        public static string BottomViewOfFile(string filename, int numChars)
        {
            var fileInfo = new FileInfo(filename);

            using (var stream = File.OpenRead(filename))
            {
                if (fileInfo.Length > numChars)
                {
                    stream.Seek(fileInfo.Length - numChars, SeekOrigin.Begin);
                    using (var textReader = new StreamReader(stream))
                    {
                        return textReader.ReadToEnd();
                    }
                }
                else
                {
                    //stream.Seek(fileInfo.Length, SeekOrigin.Begin);
                    using (var textReader = new StreamReader(stream))
                    {
                        return textReader.ReadToEnd();
                    }
                }


            }
        }

        private void dgProgramFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start("notepad.exe", txtBoxPath.Text);
        }

        private void dgProgramFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                DataRowView row_selected = e.AddedItems[0] as DataRowView;
                DataTable dt = new DataTable();
                string customerId = "";
                string id = row_selected.Row[0].ToString();
                DataGrid dataGrid = sender as DataGrid;
                dgSelRow = int.Parse(dataGrid.SelectedIndex.ToString());
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);
                if (row_selected != null)
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                        sqlCon.Open();
                        String query = "SELECT * from[NCPROG] INNER JOIN[Machine_Groups] ON NCPROG.fkMachGroupId = machine_group_id WHERE NCPROG.id = " + id + "  ORDER BY filename ASC";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtFilename.Text = dt.Rows[0]["filename"].ToString();
                            txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                            txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                            txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                            txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                            txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                            string filePath = dt.Rows[0]["programPointer"].ToString();
                            DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                            txtBoxLastModified.Text = modification.ToString();
                            txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                            string custId = dt.Rows[0]["fkCustId"].ToString();
                            string r = dt.Rows[0]["UniqueReference"].ToString();
                            //refer = r;
                            customerId = custId;
                            if (custId == "")
                            {
                                customerId = "1";
                            }

                            byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                            txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                            txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                            txtBotView.ScrollToEnd();

                            txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                            txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();
                        }
                        da.Dispose();
                        sqlCon.Close();

                        lstBoxAssocCus.Items.Clear();
                        sqlCon.Open();
                        String query2 = "SELECT * from CUSTOMERS WHERE customer_id = '" + customerId + "' ";
                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                        SqlDataReader dr2 = sqlCmd2.ExecuteReader();

                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                //string cusid = dr2["customer_id"].ToString();
                                int cusid = int.Parse(dr2["customer_id"].ToString());
                                string cusnm = dr2["customer_name"].ToString();

                                if (customerId == cusid.ToString())
                                {
                                    lstBoxAssocCus.Items.Add(cusnm);
                                }
                            }
                        }
                        dr2.Close();
                        sqlCon.Close();
                    }
                    catch (Exception ex) { ex.ToString(); }
                }
            }
        }
       
        private void refId_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start("notepad.exe", txtBoxPath.Text);
        }

        private void refID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                DataRowView row_selected = e.AddedItems[0] as DataRowView;
                DataTable dt = new DataTable();
                string customerId = "";
                string id = row_selected.Row[0].ToString();
                DataGrid dataGrid = sender as DataGrid;
                dgSelRow = int.Parse(dataGrid.SelectedIndex.ToString());
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);
                if (row_selected != null)
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                        sqlCon.Open();
                        String query = "SELECT * from[NCPROG] INNER JOIN[Machine_Groups] ON NCPROG.fkMachGroupId = machine_group_id WHERE NCPROG.id = " + id + "  ORDER BY filename ASC";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtFilename.Text = dt.Rows[0]["filename"].ToString();
                            txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                            txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                            txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                            txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                            txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                            string filePath = dt.Rows[0]["programPointer"].ToString();
                            DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                            txtBoxLastModified.Text = modification.ToString();
                            txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                            string custId = dt.Rows[0]["fkCustId"].ToString();
                            string r = dt.Rows[0]["UniqueReference"].ToString();
                            //refer = r;
                            customerId = custId;
                            if (custId == "")
                            {
                                customerId = "1";
                            }

                            byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                            txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                            txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                            txtBotView.ScrollToEnd();

                            txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                            txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();
                        }
                        da.Dispose();
                        sqlCon.Close();

                        lstBoxAssocCus.Items.Clear();
                        sqlCon.Open();
                        String query2 = "SELECT * from CUSTOMERS WHERE customer_id = '" + customerId + "' ";
                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                        SqlDataReader dr2 = sqlCmd2.ExecuteReader();

                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                //string cusid = dr2["customer_id"].ToString();
                                int cusid = int.Parse(dr2["customer_id"].ToString());
                                string cusnm = dr2["customer_name"].ToString();

                                if (customerId == cusid.ToString())
                                {
                                    lstBoxAssocCus.Items.Add(cusnm);
                                }
                            }
                        }
                        dr2.Close();
                        sqlCon.Close();
                    }
                    catch (Exception ex) { ex.ToString(); }
                }
            }
        }

        private void reqId_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start("notepad.exe", txtBoxPath.Text);
        }

        private void reqID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                DataRowView row_selected = e.AddedItems[0] as DataRowView;
                DataTable dt = new DataTable();
                string customerId = "";
                string id = row_selected.Row[0].ToString();
                DataGrid dataGrid = sender as DataGrid;
                dgSelRow = int.Parse(dataGrid.SelectedIndex.ToString());
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);
                if (row_selected != null)
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                        sqlCon.Open();
                        String query = "SELECT * from[NCPROG] INNER JOIN[Machine_Groups] ON NCPROG.fkMachGroupId = machine_group_id WHERE NCPROG.id = " + id + "  ORDER BY filename ASC";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtFilename.Text = dt.Rows[0]["filename"].ToString();
                            txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                            txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                            txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                            txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                            txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                            string filePath = dt.Rows[0]["programPointer"].ToString();
                            DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                            txtBoxLastModified.Text = modification.ToString();
                            txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                            string custId = dt.Rows[0]["fkCustId"].ToString();
                            string r = dt.Rows[0]["UniqueReference"].ToString();
                            //refer = r;
                            customerId = custId;
                            if (custId == "")
                            {
                                customerId = "1";
                            }

                            byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                            txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                            txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                            txtBotView.ScrollToEnd();

                            txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                            txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();
                        }
                        da.Dispose();
                        sqlCon.Close();

                        lstBoxAssocCus.Items.Clear();
                        sqlCon.Open();
                        String query2 = "SELECT * from CUSTOMERS WHERE customer_id = '" + customerId + "' ";
                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                        SqlDataReader dr2 = sqlCmd2.ExecuteReader();

                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                //string cusid = dr2["customer_id"].ToString();
                                int cusid = int.Parse(dr2["customer_id"].ToString());
                                string cusnm = dr2["customer_name"].ToString();

                                if (customerId == cusid.ToString())
                                {
                                    lstBoxAssocCus.Items.Add(cusnm);
                                }
                            }
                        }
                        dr2.Close();
                        sqlCon.Close();
                    }
                    catch (Exception ex) { ex.ToString(); }
                }
            }
        }

        private void cntrlPgrmOpen_Click(object sender, RoutedEventArgs e)
        {
            cntrlPgrmFilter.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Visible;
            assocCustCancel.Visibility = Visibility.Hidden;
        }

        private void assocCustOpen_Click(object sender, RoutedEventArgs e)
        {
            assocCustFilter.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Visible;
            cntrlPgrmCancel.Visibility = Visibility.Hidden;
        }

        private void cntrlPgrmClose_Click(object sender, RoutedEventArgs e)
        {
            cntrlPgrmFilter.Visibility = Visibility.Collapsed;
            gridSearch.Visibility = Visibility.Collapsed;
        }

        private void assocCustClose_Click(object sender, RoutedEventArgs e)
        {
            assocCustFilter.Visibility = Visibility.Collapsed;
            gridSearch.Visibility = Visibility.Collapsed;
        }

        public void FillComboBoxCntrlPgrmGrp(ComboBox comBoxName)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * from Machine_Groups";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();

                da.Fill(ds);
                comBoxName.ItemsSource = ds.Tables[0].DefaultView;
                comBoxName.DisplayMemberPath = ds.Tables[0].Columns["machine_group_name"].ToString();
                comBoxName.SelectedValuePath = ds.Tables[0].Columns["machine_group_id"].ToString();
                //comboBoxName.Text = ds.Tables[0].Columns[1].ToStrin g();
                comBoxName.SelectedIndex = 0;
                da.Dispose();
                sqlCon.Close();
            }
            catch (Exception ex) { ex.ToString(); }
        }
        
        public void FillComboBoxAssocCust(ComboBox comBoxName)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * from CUSTOMERS";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                DataSet ds = new DataSet();

                da.Fill(ds);
                comBoxName.ItemsSource = ds.Tables[0].DefaultView;
                comBoxName.DisplayMemberPath = ds.Tables[0].Columns["customer_name"].ToString();
                comBoxName.SelectedValuePath = ds.Tables[0].Columns["customer_id"].ToString();
                //comboBoxName.Text = ds.Tables[0].Columns[1].ToStrin g();
                comBoxName.SelectedIndex = 0;
                da.Dispose();
                sqlCon.Close();
            }
            catch (Exception ex) { ex.ToString(); }
        }

        private void cntrlPgrmSelect_Click(object sender, RoutedEventArgs e)
        {
            cntrlPgrmFilter.Visibility = Visibility.Collapsed;
            cntrlPgrmCancel.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Collapsed;
            dgProgramFiles.ItemsSource = null;
            refID.ItemsSource = null;
            reqID.ItemsSource = null;
            string mach_id = cmbBoxCntrlPgrm.SelectedValue.ToString();
            string mach_name = cmbBoxCntrlPgrm.Text;
            selCbFilterCPG = cmbBoxCntrlPgrm.SelectedValue.ToString();
            tempselCbFilterCPG = selCbFilterCPG;
            DataTable dt = new DataTable();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * from [NCPROG] INNER JOIN [Machine_Groups] ON NCPROG.fkMachGroupId=machine_group_id  WHERE fkMachGroupId = " + mach_id + " ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dgProgramFiles.ItemsSource = dt.DefaultView;
                    refID.ItemsSource = dt.DefaultView;
                    reqID.ItemsSource = dt.DefaultView;
                    dgProgramFiles.SelectedIndex = 0;
                    refID.SelectedIndex = 0;
                    reqID.SelectedIndex = 0;

                    txtFilename.Text = dt.Rows[0]["filename"].ToString();
                    txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                    txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                    txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                    txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                    txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                    string filePath = dt.Rows[0]["programPointer"].ToString();
                    DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                    txtBoxLastModified.Text = modification.ToString();
                    txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                    //txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                    //txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();

                    byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                    txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                    txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                    txtBotView.ScrollToEnd();

                    txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                    txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();

                    da.Dispose();
                    sqlCon.Close();

                    
                }
                else
                {
                    MessageBox.Show("No Control Program found under " + mach_name + " group.", "Control Program Navigator", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }

        private void cntrlPgrmCancel_Click(object sender, RoutedEventArgs e)
        {
            cntrlPgrmCancel.Visibility = Visibility.Hidden;
            txtSearch.Text = "";
            btnSearchCancel.Visibility = Visibility.Hidden;
            dgProgramFiles.ItemsSource = contProgram().DefaultView;
            dgProgramFiles.IsEnabled = true;
            dgProgramFiles.SelectedIndex = 0;
            dgProgramFiles.Focus();
            refID.ItemsSource = referenceID().DefaultView;
            refID.IsEnabled = true;
            refID.SelectedIndex = 0;
            refID.Focus();
            reqID.ItemsSource = requestID().DefaultView;
            reqID.IsEnabled = true;
            reqID.SelectedIndex = 0;
            reqID.Focus();
            dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            refID.ScrollIntoView(refID.SelectedItem);
            reqID.ScrollIntoView(reqID.SelectedItem);
            dgSelRow = 0;
            LoadTextBoxesData();
            FillComboBoxCntrlPgrmGrp(cmbBoxCntrlPgrm);
        }

        private void assocCustSelect_Click(object sender, RoutedEventArgs e)
        {
            lstBoxAssocCus.Items.Clear();
            assocCustFilter.Visibility = Visibility.Collapsed;
            assocCustCancel.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Collapsed;
            dgProgramFiles.ItemsSource = null;
            refID.ItemsSource = null;
            reqID.ItemsSource = null;
            string assoc_id = cmbBoxAssocCust.SelectedValue.ToString();
            string assoc_name = cmbBoxAssocCust.Text;
            selCbFilterAC = cmbBoxAssocCust.SelectedValue.ToString();
            tempselCbFilterAC = selCbFilterAC;
            DataTable dt = new DataTable();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * from [NCPROG] INNER JOIN [Machine_Groups] ON NCPROG.fkMachGroupId=machine_group_id INNER JOIN [CtrlProgCustMGAssoc] ON NCPROG.UniqueReference=urid INNER JOIN [CUSTOMERS]  ON CtrlProgCustMGAssoc.custid=customer_id  WHERE customer_id = " + assoc_id + " ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dgProgramFiles.ItemsSource = dt.DefaultView;
                    refID.ItemsSource = dt.DefaultView;
                    reqID.ItemsSource = dt.DefaultView;
                    dgProgramFiles.SelectedIndex = 0;
                    refID.SelectedIndex = 0;
                    reqID.SelectedIndex = 0;

                    txtFilename.Text = dt.Rows[0]["filename"].ToString();
                    txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                    txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                    txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                    txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                    txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                    string filePath = dt.Rows[0]["programPointer"].ToString();
                    DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                    txtBoxLastModified.Text = modification.ToString();
                    txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                    lstBoxAssocCus.Items.Add(dt.Rows[0]["custName"]);
                    //txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                    //txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();

                    byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                    txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                    txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                    txtBotView.ScrollToEnd();

                    txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                    txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();

                    da.Dispose();
                    sqlCon.Close();


                }
                else
                {
                    MessageBox.Show("No Control Program found under " + assoc_name + " group.", "Control Program Navigator", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }

        private void assocCustCancel_Click(object sender, RoutedEventArgs e)
        {
            assocCustCancel.Visibility = Visibility.Hidden;
            txtSearch.Text = "";
            btnSearchCancel.Visibility = Visibility.Hidden;
            dgProgramFiles.ItemsSource = contProgram().DefaultView;
            dgProgramFiles.IsEnabled = true;
            dgProgramFiles.SelectedIndex = 0;
            dgProgramFiles.Focus();
            refID.ItemsSource = referenceID().DefaultView;
            refID.IsEnabled = true;
            refID.SelectedIndex = 0;
            refID.Focus();
            reqID.ItemsSource = requestID().DefaultView;
            reqID.IsEnabled = true;
            reqID.SelectedIndex = 0;
            reqID.Focus();
            dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            refID.ScrollIntoView(refID.SelectedItem);
            reqID.ScrollIntoView(reqID.SelectedItem);
            dgSelRow = 0;
            LoadTextBoxesData();
            FillComboBoxAssocCust(cmbBoxAssocCust);
        }

        private void SearchFunc()
        {
            string search_value = txtSearch.Text;
            string search_query = "SELECT * from [NCPROG] INNER JOIN [Machine_Groups] ON NCPROG.fkMachGroupId=machine_group_id  WHERE NCPROG.id LIKE '%" + search_value + "%' ";
            if (cbRemReqId.IsChecked == true) { search_query += "OR remoteCallId LIKE '%" + search_value + "%' "; } else { search_query += ""; }
            if (cbRefId.IsChecked == true) { search_query += "OR UniqueReference LIKE '%" + search_value + "%' "; } else { search_query += ""; }
            if (cbCpg.IsChecked == true) { search_query += "OR machine_group_name LIKE '%" + search_value + "%' "; } else { search_query += ""; }
            if (cbFileNm.IsChecked == true) { search_query += "OR filename LIKE '%" + search_value + "%' "; } else { search_query += ""; }
            if (cbDesc.IsChecked == true) { search_query += "OR descr LIKE '%" + search_value + "%' "; } else { search_query += ""; }

            if (cbRemReqId.IsChecked == false && cbRefId.IsChecked == false && cbCpg.IsChecked == false && cbFileNm.IsChecked == false && cbAssCus.IsChecked == false && cbDesc.IsChecked == false) { txtSearch.IsEnabled = false;  } else { txtSearch.IsEnabled = true; }

            DataTable dt = new DataTable();

            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(search_query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dgProgramFiles.ItemsSource = dt.DefaultView;
                    refID.ItemsSource = dt.DefaultView;
                    reqID.ItemsSource = dt.DefaultView;
                    dgProgramFiles.SelectedIndex = 0;
                    refID.SelectedIndex = 0;
                    reqID.SelectedIndex = 0;
                    dgProgramFiles.Focus();
                    refID.Focus();
                    reqID.Focus();

                    txtFilename.Text = dt.Rows[0]["filename"].ToString();
                    txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                    txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                    txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                    txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                    txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                    string filePath = dt.Rows[0]["programPointer"].ToString();
                    DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                    txtBoxLastModified.Text = modification.ToString();
                    txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                    byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                    txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                    txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                    txtBotView.ScrollToEnd();

                    txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                    txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();

                    da.Dispose();
                    sqlCon.Close();
                }
                else
                {
                    MessageBox.Show("No Control Program found matching the search criteria.", "Control Program Navigator", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string search_value = txtSearch.Text;
            if (search_value == "")
            {
                MessageBox.Show("Please input necessary search term first.", "Control Program Navigator", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                btnSearchCancel.Visibility = Visibility.Visible;
                SearchFunc();
            }
        }

        private void btnSearchCancel_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
            btnSearchCancel.Visibility = Visibility.Hidden;
            LoadTextBoxesData();
            dgProgramFiles.ItemsSource = contProgram().DefaultView;
            refID.ItemsSource = referenceID().DefaultView;
            reqID.ItemsSource = requestID().DefaultView;
            dgProgramFiles.SelectedIndex = 0;
            refID.SelectedIndex = 0;
            reqID.SelectedIndex = 0;
            dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            refID.ScrollIntoView(refID.SelectedItem);
            reqID.ScrollIntoView(reqID.SelectedItem); ;
        }

        private void ctxMenu_EditFile_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", txtBoxPath.Text);
        }

        private void txtTopView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start("notepad.exe", txtBoxPath.Text);
        }

        private void txtBotView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Process.Start("notepad.exe", txtBoxPath.Text);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.Sleep(200);
            dgProgramFiles.ItemsSource = contProgram().DefaultView;
            dgProgramFiles.IsEnabled = true;
            dgProgramFiles.SelectedIndex = 0;
            dgProgramFiles.Focus();
            refID.ItemsSource = referenceID().DefaultView;
            refID.IsEnabled = true;
            refID.SelectedIndex = 0;
            refID.Focus();
            reqID.ItemsSource = requestID().DefaultView;
            reqID.IsEnabled = true;
            reqID.SelectedIndex = 0;
            reqID.Focus();
            txtSearch.Text = "";
            LoadTextBoxesData();
            dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            refID.ScrollIntoView(refID.SelectedItem);
            reqID.ScrollIntoView(reqID.SelectedItem);
            dgSelRow = 0;
            btnRefresh.IsEnabled = true;
        }

        private static Key lastKey;
        private static int lastFoundIndex = 0;
        private void dgProgramFiles_KeyDown(object sender, KeyEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            if ((dataGrid.Items.Count == 0) && !(e.Key >= Key.A && e.Key <= Key.Z))
            {
                return;
            }

            if ((lastKey != e.Key) || (lastFoundIndex == dataGrid.Items.Count - 1))
            {
                lastFoundIndex = 0;
            }

            for (int i = lastFoundIndex; i < dataGrid.Items.Count; i++)
            {
                if (dataGrid.SelectedIndex == i)
                {
                    continue;
                }
                
                DataRowView row = dataGrid.SelectedItem as DataRowView;
                //string myCellValue = rowView.Row[0].ToString();
                string filename = row["id"].ToString();
                if (filename.StartsWith(e.Key.ToString(), true, CultureInfo.CurrentCulture))
                {
                    dataGrid.ScrollIntoView(filename);
                    dataGrid.SelectedItem = filename;

                    lastFoundIndex = i;

                    break;
                }
            }

            lastKey = e.Key;
        }

        private void cbRemReqId_Checked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbRemReqId_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbRefId_Checked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbRefId_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbCpg_Checked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbCpg_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbAssCus_Checked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbAssCus_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbFileNm_Checked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbFileNm_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbDesc_Checked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void cbDesc_Unchecked(object sender, RoutedEventArgs e)
        {
            SearchFunc();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearchCancel.Visibility = Visibility.Visible;
                SearchFunc();
            }
        }

        private void btnSendToMach_Click(object sender, RoutedEventArgs e)
        {
            gridMach.Visibility = Visibility.Visible;

        }
        private void sendToMachClose_Click(object sender, RoutedEventArgs e)
        {
            gridMach.Visibility = Visibility.Collapsed;
        }

        private void ctxMenu_SendToMach_Click(object sender, RoutedEventArgs e)
        {
            gridMach.Visibility = Visibility.Visible;
        }
        private void Load()
        {
            dgProgramFiles.ItemsSource = contProgram().DefaultView;
            dgProgramFiles.IsEnabled = true;
            dgProgramFiles.SelectedIndex = 0;
            dgProgramFiles.Focus();
            refID.ItemsSource = referenceID().DefaultView;
            refID.IsEnabled = true;
            refID.SelectedIndex = 0;
            refID.Focus();
            reqID.ItemsSource = requestID().DefaultView;
            reqID.IsEnabled = true;
            reqID.SelectedIndex = 0;
            reqID.Focus();
            dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            refID.ScrollIntoView(refID.SelectedItem);
            reqID.ScrollIntoView(reqID.SelectedItem);
            LoadTextBoxesData();
        }
        private void removeSelectedCP()
        {
            if (MessageBox.Show("Removing <" + txtFilename.Text + "> from Control Program \n\n Do you want to continue?", "Fusion PDO - Control Program Navigator", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "DELETE from NCPROG WHERE UniqueReference = '" + txtBoxRefID.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();

                MessageBox.Show(" '" + this.txtFilename.Text + "' was successfully deleted.", "FUSION PDO - Control Program Navigator", MessageBoxButton.OK, MessageBoxImage.Information);
                sqlCon.Close();
                Load();
            }
            else
            {
                Load();
            }
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            removeSelectedCP();
        }

        private void ctxMenuRemove_Click(object sender, RoutedEventArgs e)
        {
            removeSelectedCP();
        }

        private void btnEditOpen_Click(object sender, RoutedEventArgs e)
        {
            editGrid.Visibility = Visibility.Visible;
            txtRemReqIdEdit.Text = txtBoxRemReqId.Text;
            txtRefIdEdit.Text = txtBoxRefID.Text;
            txtPgrmPointerEdit.Text = txtBoxPath.Text;
            txtTopEdit.Text = txtTopView.Text;
            txtBotEdit.Text = txtBotView.Text;
            txtBotEdit.ScrollToEnd();
        }

        private void editCtrPrgrmClose_Click(object sender, RoutedEventArgs e)
        {
            editGrid.Visibility = Visibility.Collapsed;
            
        }

        private void editPrgrmPointerBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                txtPgrmPointerEdit.Text = openFileDialog.FileName;
            }
        }

    }
}
