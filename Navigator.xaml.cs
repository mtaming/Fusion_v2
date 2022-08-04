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
        public string filePath = "";
        public int maxNCID = 0;
        public int maxCpMgAssoId = 0;
        public int maxcount = 0;

        public int mid = 0;
        public int cusid = 0;
        public string cusname = "";
        public Navigator()
        {
            InitializeComponent();
            //loadDataQuery();
            //worker = new BackgroundWorker();
            //worker.DoWork += worker_DoWork;
            //worker.ProgressChanged += worker_ProgressChanged;
            //worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            //worker.WorkerReportsProgress = true;
            //worker.WorkerSupportsCancellation = true;

            //ProgressBar1.Maximum = 100;
            //worker.RunWorkerAsync();
            dgProgramFiles.IsEnabled = false;
           
            FillComboBoxCntrlPgrmGrp(cmbBoxCntrlPgrm);
            FillComboBoxAssocCust(cmbBoxAssocCust);

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

            //dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            dgProgramFiles.Focus();

            refID.ItemsSource = referenceID().DefaultView;
            reqID.ItemsSource = requestID().DefaultView;

            //MessageBox.Show(Properties.Settings.Default.dgLastSelected.ToString());
            //LoadTextBoxesData();
            btnSendToMach.IsEnabled = true;
            btnRefresh.IsEnabled = true;
            btnCreateNew.IsEnabled = true;
            btnRemove.IsEnabled = true;
            btnEdit.IsEnabled = true;
        }


        //background worker
        //void worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    BackgroundWorker worker = sender as BackgroundWorker;
        //    for (int i = 1; i <= 10;  i++)
        //    {
        //        if (worker.CancellationPending)
        //        {
        //            e.Cancel = true;
        //            break;
        //        }
        //        else
        //        {
        //            System.Threading.Thread.Sleep(100);
        //            worker.ReportProgress(i);
        //        }
        //    }
        //}
        //void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    double percent = (e.ProgressPercentage * 10) / 100;

        //    ProgressBar1.Value = Math.Round(percent);

        //    //MessageBox.Show(e.ProgressPercentage.ToString());

        //}
        //void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    ProgressBar1.Visibility = Visibility.Hidden;
        //    Loading.Visibility = Visibility.Hidden;
        //    cbRemReqId.IsChecked = true;
        //    cbRefId.IsChecked = true;
        //    cbCpg.IsChecked = true;
        //    cbAssCus.IsChecked = true;
        //    cbFileNm.IsChecked = true;
        //    cbDesc.IsChecked = true;
        //    cbFilter.Items.Add("Control Program Files");
        //    cbFilter.Items.Add("Reference ID");
        //    cbFilter.Items.Add("Remote Request ID");
            
        //    cbFilter.SelectedIndex = 0;
        //    dgProgramFiles.ItemsSource = contProgram().DefaultView;
        //    dgProgramFiles.IsEnabled = true;
        //    dgProgramFiles.SelectedIndex = 0;

        //    //dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
        //    dgProgramFiles.Focus();

        //    refID.ItemsSource = referenceID().DefaultView;
        //    reqID.ItemsSource = requestID().DefaultView;

        //    //MessageBox.Show(Properties.Settings.Default.dgLastSelected.ToString());
        //    //LoadTextBoxesData();
        //    btnSendToMach.IsEnabled = true;
        //    btnRefresh.IsEnabled = true;
        //    btnCreateNew.IsEnabled = true;
        //    btnRemove.IsEnabled = true;
        //    btnEdit.IsEnabled = true;
        //}
        //end background worker
        
        private DataTable contProgram()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * FROM NCPROG ORDER BY id";
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
                String query = "SELECT * FROM NCPROG ORDER BY id";
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
                String query = "SELECT * FROM NCPROG ORDER BY id";
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
                    dgProgramFiles.SelectedIndex = dgSelRow;
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
                lstBoxAssocCus.Items.Clear();
                string id = row_selected.Row["id"].ToString();
                DataGrid dataGrid = sender as DataGrid;
                dgSelRow = int.Parse(dataGrid.SelectedIndex.ToString());
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);
                Properties.Settings.Default.dgLastSelected = dgSelRow;
                Properties.Settings.Default.Save();

                txtFilename.Text = "";
                txtBoxPath.Text = "";
                txtBoxCntrllPgrmGrp.Text = "";
                txtBoxRefID.Text = "";
                txtBoxRemReqId.Text = "";
                txtBoxRev.Text = "";
                txtBoxLastModified.Text = "";
                txtBoxFileSize.Text = "";
                txtBoxNotes.Text = "";
                txtBoxDesc.Text = "";
                txtTopView.Text = "";
                txtBotView.Text = "";
                lstBoxAssocCus.Items.Clear();

                if (row_selected != null)
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                        sqlCon.Open();
                        String query = "SELECT * FROM NCPROG INNER JOIN Machine_Groups ON NCPROG.fkMachGroupId=Machine_Groups.machine_group_id INNER JOIN CtrlProgCustMGAssoc ON NCPROG.UniqueReference=CtrlProgCustMGAssoc.urid WHERE NCPROG.id = " + id + " ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtFilename.Text = dt.Rows[0]["filename"].ToString();
                            txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                            string filename = txtBoxPath.Text;
                            if (!File.Exists(filename))
                            {
                                //MessageBox.Show("Program specified by pointer does not exist.\nPlease select an operation.");
                                gridNoPgrmPointer.Visibility = Visibility.Visible;
                                NoPgrmPointerCancel.Focus();
                                txtTopView.Text = "";
                                txtBotView.Text = "";
                            }

                            txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                            txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                            txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                            txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                            string filePath = dt.Rows[0]["programPointer"].ToString();
                            DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                            txtBoxLastModified.Text = modification.ToString();
                            txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                            lstBoxAssocCus.Items.Add(dt.Rows[0]["custName"].ToString());
                            mid = int.Parse(dt.Rows[0]["machine_group_id"].ToString());
                            cusid = int.Parse(dt.Rows[0]["custid"].ToString());

                            byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                            txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                            txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                            txtBotView.ScrollToEnd();

                            txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                            txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();

                        }
                        da.Dispose();
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
                lstBoxAssocCus.Items.Clear();
                string id = row_selected.Row[0].ToString();
                DataGrid dataGrid = sender as DataGrid;
                dgSelRow = int.Parse(dataGrid.SelectedIndex.ToString());
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);

                txtFilename.Text = "";
                txtBoxPath.Text = "";
                txtBoxCntrllPgrmGrp.Text = "";
                txtBoxRefID.Text = "";
                txtBoxRemReqId.Text = "";
                txtBoxRev.Text = "";
                txtBoxLastModified.Text = "";
                txtBoxFileSize.Text = "";
                txtBoxNotes.Text = "";
                txtBoxDesc.Text = "";
                txtTopView.Text = "";
                txtBotView.Text = "";
                
                if (row_selected != null)
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                        sqlCon.Open();
                        String query = "SELECT * FROM NCPROG INNER JOIN Machine_Groups ON NCPROG.fkMachGroupId=Machine_Groups.machine_group_id INNER JOIN CtrlProgCustMGAssoc ON NCPROG.UniqueReference=CtrlProgCustMGAssoc.urid WHERE NCPROG.id = " + id + " ORDER BY filename ASC ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtFilename.Text = dt.Rows[0]["filename"].ToString();
                            txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                            string filename = txtBoxPath.Text;
                            if (!File.Exists(filename))
                            {
                                //MessageBox.Show("Program specified by pointer does not exist.\nPlease select an operation.");
                                gridNoPgrmPointer.Visibility = Visibility.Visible;
                                NoPgrmPointerCancel.Focus();
                                txtTopView.Text = "";
                                txtBotView.Text = "";
                            }
                            txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                            txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                            txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                            txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                            string filePath = dt.Rows[0]["programPointer"].ToString();
                            DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                            txtBoxLastModified.Text = modification.ToString();
                            txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                            lstBoxAssocCus.Items.Add(dt.Rows[0]["custName"]);
                            mid = int.Parse(dt.Rows[0]["machine_group_id"].ToString());
                            cusid = int.Parse(dt.Rows[0]["custid"].ToString());

                            byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                            txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                            txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                            txtBotView.ScrollToEnd();

                            txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                            txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();
                        }
                        da.Dispose();
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
                lstBoxAssocCus.Items.Clear();
                string id = row_selected.Row[0].ToString();
                DataGrid dataGrid = sender as DataGrid;
                dgSelRow = int.Parse(dataGrid.SelectedIndex.ToString());
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);

                txtFilename.Text = "";
                txtBoxPath.Text = "";
                txtBoxCntrllPgrmGrp.Text = "";
                txtBoxRefID.Text = "";
                txtBoxRemReqId.Text = "";
                txtBoxRev.Text = "";
                txtBoxLastModified.Text = "";
                txtBoxFileSize.Text = "";
                txtBoxNotes.Text = "";
                txtBoxDesc.Text = "";
                txtTopView.Text = "";
                txtBotView.Text = "";
               
                if (row_selected != null)
                {
                    try
                    {
                        SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                        sqlCon.Open();
                        String query = "SELECT * FROM NCPROG INNER JOIN Machine_Groups ON NCPROG.fkMachGroupId=Machine_Groups.machine_group_id INNER JOIN CtrlProgCustMGAssoc ON NCPROG.UniqueReference=CtrlProgCustMGAssoc.urid WHERE NCPROG.id = " + id + " ORDER BY filename ASC ";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            txtFilename.Text = dt.Rows[0]["filename"].ToString();
                            txtBoxPath.Text = dt.Rows[0]["programPointer"].ToString();
                            string filename = txtBoxPath.Text;
                            if (!File.Exists(filename))
                            {
                                //MessageBox.Show("Program specified by pointer does not exist.\nPlease select an operation.");
                                gridNoPgrmPointer.Visibility = Visibility.Visible;
                                NoPgrmPointerCancel.Focus();
                                txtTopView.Text = "";
                                txtBotView.Text = "";
                            }
                            txtBoxCntrllPgrmGrp.Text = dt.Rows[0]["machine_group_name"].ToString();

                            txtBoxRefID.Text = dt.Rows[0]["UniqueReference"].ToString();
                            txtBoxRemReqId.Text = dt.Rows[0]["remoteCallId"].ToString();
                            txtBoxRev.Text = dt.Rows[0]["revision_date"].ToString();

                            string filePath = dt.Rows[0]["programPointer"].ToString();
                            DateTime modification = File.GetLastWriteTime(filePath); //last modification date of actual file
                            txtBoxLastModified.Text = modification.ToString();
                            txtBoxFileSize.Text = new FileInfo(filePath).Length.ToString() + " " + "Bytes";

                            lstBoxAssocCus.Items.Add(dt.Rows[0]["custName"].ToString());
                            mid = int.Parse(dt.Rows[0]["machine_group_id"].ToString());
                            cusid = int.Parse(dt.Rows[0]["custid"].ToString());

                            byte[] test = File.ReadAllBytes(filePath).Skip(0).Take(512).ToArray();
                            txtTopView.Text = Encoding.UTF8.GetString(test) + "\n\n**This is only a quick view of the top of the file**\n**Double click to edit file**";


                            txtBotView.Text = "**This is only a quick view of the bottom of the file**\n**Double click to edit file**\n\n" + BottomViewOfFile(filePath, 512);
                            txtBotView.ScrollToEnd();

                            txtBoxNotes.Text = dt.Rows[0]["notes"].ToString();
                            txtBoxDesc.Text = dt.Rows[0]["desc"].ToString();
                        }
                        da.Dispose();
                        sqlCon.Close();

                    }
                    catch (Exception ex) { ex.ToString(); }
                }
            }
        }

        private void NoPgrmPointerCancel_Click(object sender, RoutedEventArgs e)
        {
            gridNoPgrmPointer.Visibility = Visibility.Collapsed;
        }

        private void NoPgrmPointerRemove_Click(object sender, RoutedEventArgs e)
        {
            gridNoPgrmPointer.Visibility = Visibility.Collapsed;
            removeSelectedCP();
        }

        private void NoPgrmPointerEdit_Click(object sender, RoutedEventArgs e)
        {
            gridNoPgrmPointer.Visibility = Visibility.Collapsed;
            editOpen();
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
            lstBoxAssocCus.Items.Clear();
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
                    dgProgramFiles.ItemsSource = contProgram().DefaultView;
                    dgProgramFiles.SelectedIndex = 0;
                    dgProgramFiles.Focus();
                    cntrlPgrmCancel.Visibility = Visibility.Hidden;
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
            //LoadTextBoxesData();
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
                    dgProgramFiles.ItemsSource = contProgram().DefaultView;
                    dgProgramFiles.SelectedIndex = 0;
                    dgProgramFiles.Focus();
                    assocCustCancel.Visibility = Visibility.Hidden;

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
            //LoadTextBoxesData();
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
            //LoadTextBoxesData();
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
            //LoadTextBoxesData();
            dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            refID.ScrollIntoView(refID.SelectedItem);
            reqID.ScrollIntoView(reqID.SelectedItem);
            dgSelRow = 0;
            btnRefresh.IsEnabled = true;
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
        private void cancelMach_Click(object sender, RoutedEventArgs e)
        {
            gridMach.Visibility = Visibility.Collapsed;
        }

        private void ctxMenu_SendToMach_Click(object sender, RoutedEventArgs e)
        {
            gridMach.Visibility = Visibility.Visible;
        }
        private void deleteSuccess()
        {
            if (dgSelRow != 0)
            {
                dgProgramFiles.ItemsSource = contProgram().DefaultView;
                dgProgramFiles.IsEnabled = true;
                dgProgramFiles.SelectedIndex = dgSelRow - 1;
                dgProgramFiles.Focus();
                refID.ItemsSource = referenceID().DefaultView;
                refID.IsEnabled = true;
                refID.SelectedIndex = dgSelRow - 1;
                refID.Focus();
                reqID.ItemsSource = requestID().DefaultView;
                reqID.IsEnabled = true;
                reqID.SelectedIndex = dgSelRow - 1;
                reqID.Focus();
                dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
                refID.ScrollIntoView(refID.SelectedItem);
                reqID.ScrollIntoView(reqID.SelectedItem);
            }
            else
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
            }
            //LoadTextBoxesData();
        }
        private void removeSelectedCP()
        {
            //string id_to_del = txtBoxRefID.Text;
            if (MessageBox.Show("Removing <" + txtFilename.Text + "> from Control Program \n\n Do you want to continue?", "Fusion PDO - Control Program Navigator", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "DELETE FROM NCPROG WHERE UniqueReference = '" + txtBoxRefID.Text + "';  DELETE FROM CtrlProgCustMGAssoc WHERE urid  = '" + txtBoxRefID.Text + "'";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                
                MessageBox.Show(" '" + this.txtFilename.Text + "' was successfully deleted.", "FUSION PDO - Control Program Navigator", MessageBoxButton.OK, MessageBoxImage.Information);
                sqlCon.Close();

                if (txtSearch.Text != "")
                {
                    SearchFunc();
                }
                else
                {
                    deleteSuccess();
                }
              
            }else{}
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            removeSelectedCP();
        }

        private void ctxMenuRemove_Click(object sender, RoutedEventArgs e)
        {
           
            if (txtSearch.Text != "")
            {
                removeSelectedCP();
                SearchFunc();
            }
            else
            {
                removeSelectedCP();
            }
        }

        //START CREATE NEW FUNCTIONS7
        private void createNew_Click(object sender, RoutedEventArgs e)
        {
            addNewGrid.Visibility = Visibility.Visible;
            rbStackPanel.IsEnabled = false;
            rbAdd_current.IsEnabled = false;
            rbAdd_autoAscend.IsChecked = true;
            FillComboBoxCntrlPgrmGrp(cbCPAdd);
            FillComboBoxAssocCust(cbCustAdd);
            AddCtrlPgrmSave.IsEnabled = false;
            tbEntireFileAdd.Visibility = Visibility.Collapsed;
            string maxRefID = "";
            string tmpMaxRefID = "";
            string tmpMaxRCID = "";
            string maxRCID = "";
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            String query = "SELECT MAX(UniqueReference) as UniqueReference, MAX(try_cast(remoteCallId as int)) as remoteCallId FROM NCPROG";

            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            var dr = sqlCmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string UnqRef = dr["UniqueReference"].ToString();
                    string maxCallId = dr["remoteCallId"].ToString();
                    tmpMaxRefID = UnqRef;
                    int UnqRefParse = int.Parse(tmpMaxRefID);
                    maxRefID = (UnqRefParse + 1).ToString();

                    while (maxRefID.Length < 7)
                    {
                        maxRefID = "0" + maxRefID;
                    }


                    tmpMaxRCID = maxCallId;
                    int maxRCIDParse = int.Parse(tmpMaxRCID);
                    maxRCID = (maxRCIDParse + 1).ToString();

                }
            }
            sqlCon.Close();
            dr.Close();

            sqlCon.Open();
            String query2 = "SELECT MAX(id) as id FROM NCPROG";
            SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
            var dr2 = sqlCmd2.ExecuteReader();
            dr2.Read();
            maxNCID = int.Parse(dr2["id"].ToString());
            sqlCon.Close();
            dr2.Close();

            sqlCon.Open();
            String query3 = "SELECT MAX(id) as cid FROM CtrlProgCustMGAssoc";
            SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
            var dr3 = sqlCmd3.ExecuteReader();
            dr3.Read();
            maxCpMgAssoId = int.Parse(dr3["cid"].ToString());
            sqlCon.Close();
            dr3.Close();

            sqlCon.Open();
            String query4 = "SELECT COUNT(*) FROM NCPROG";
            SqlCommand sqlCmd4 = new SqlCommand(query4, sqlCon);
            var countNav = sqlCmd4.ExecuteScalar();

            maxcount = int.Parse(countNav.ToString());
            sqlCon.Close();

            txtAddRefID.Text = maxRefID.ToString();
            txtAddmReqID.Text = maxRCID.ToString();
            filePath = txtAddPgrmPointer.Text;

        }

        private void AddCtrPrgrmClose_Click(object sender, RoutedEventArgs e)
        {
            if (txtAddPgrmPointer.Text != "") { removeID();  }
            addNewGrid.Visibility = Visibility.Collapsed;
            txtAddmReqID.Text = null;
            txtAddRefID.Text = null;
            txtAddPgrmPointer.Text = null;
            txtAddTopView.Text = null;
            txtAddBotView.Text = null;
            txtRevAdd.Text = null;
            txtNotesAdd.Text = null;
            
        }

        private void AddCtrlPgrmCancel_Click(object sender, RoutedEventArgs e)
        {
            addNewGrid.Visibility = Visibility.Collapsed;
            txtAddmReqID.Text = null;
            txtAddRefID.Text = null;
            txtAddPgrmPointer.Text = null;
            txtAddTopView.Text = null;
            txtAddBotView.Text = null;
            txtRevAdd.Text = null;
            txtNotesAdd.Text = null;
            
        }

        private void addPgrmPointer_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            while (openFileDialog.ShowDialog() == true)
            {
                txtAddPgrmPointer.Text = openFileDialog.FileName;
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT COUNT(*) FROM NCPROG WHERE programPointer = '" + txtAddPgrmPointer.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                int count = (int)sqlCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Program Pointer is already associated to a control program.\nPlease select another Program Pointer.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtAddPgrmPointer.Text = "";
                    continue;
                }
                else
                {
                    AddCtrlPgrmSave.IsEnabled = true;
                    rbStackPanel.IsEnabled = true;

                    string fileSize = new FileInfo(openFileDialog.FileName).Length.ToString();
                    int parseFileSize = int.Parse(fileSize);

                    if (parseFileSize < 1000)
                    {
                        txtAddTopView.Text = File.ReadAllText(openFileDialog.FileName);
                        tbEntireFileAdd.Visibility = Visibility.Visible;
                        txtAddBotView.IsEnabled = false;
                    }
                    else
                    {
                        byte[] lineCont = new byte[500];
                        BinaryReader bread = new BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read));
                        bread.BaseStream.Seek(0, SeekOrigin.Begin);
                        bread.Read(lineCont, 0, 500);
                        bread.Close();

                        byte[] lineCont2 = new byte[500];
                        BinaryReader bread2 = new BinaryReader(new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read));
                        bread2.BaseStream.Seek(-500, SeekOrigin.End);
                        bread2.Read(lineCont2, 0, 500);
                        bread2.Close();

                        tbEntireFileAdd.Visibility = Visibility.Hidden;
                        txtAddBotView.IsEnabled = true;

                        txtAddTopView.Text = Encoding.UTF8.GetString(lineCont);
                        txtAddBotView.Text = Encoding.UTF8.GetString(lineCont2);
                        txtAddBotView.ScrollToEnd();
                    }

                    break;
                }
            }
        }
        private void btnAdd_insertID_Click(object sender, RoutedEventArgs e)
        {
            string strFile = txtAddPgrmPointer.Text.ToUpper();
            int insertAtLineNumber = 1;

            string textToInsert = "(REFID = " + txtAddRefID.Text + " DNCID = " + txtAddmReqID.Text + ")";
            if (strFile == "")
            {
                MessageBox.Show("No program pointer selected.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (txtAddmReqID.Text == "")
            {
                MessageBox.Show("Please supply a valid Remote Request ID.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEditReqID.Focus();
            }
            else
            {
                ArrayList lines = new ArrayList();
                StreamReader sr = new StreamReader(strFile);

                string line;
                while ((line = sr.ReadLine()) != null) lines.Add(line);
                sr.Close();

                if (lines.Count > insertAtLineNumber) lines.Insert(insertAtLineNumber, textToInsert);

                if (!File.ReadAllText(strFile).Contains(textToInsert))
                {
                    StreamWriter sw = new StreamWriter(strFile);
                    foreach (string newLine in lines) sw.WriteLine(newLine);
                    sw.Close();
                }

                FileInfo fi = new FileInfo(strFile);
                FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                byte[] fileBytes = new byte[500];
                int numBytesToRead = (int)fileBytes.Length;

                int numBytesRead = 0;

                while (numBytesToRead > 0)
                {
                    int n = fs.Read(fileBytes, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }

                string filestring = Encoding.UTF8.GetString(fileBytes);
                fs.Close();
                txtAddTopView.Text = filestring;
            }
        }

        private void AddCtrlPgrmSave_Click(object sender, RoutedEventArgs e) // BUTTON ADD SAVE FUNCTION
        {
            if (txtAddPgrmPointer.Text != "")
            {
                string rcid = txtAddmReqID.Text;
                string unqRef = txtAddRefID.Text;
                string pgrmPtr = txtAddPgrmPointer.Text;
                string desc = txtDescAdd.Text;
                string notes = txtNotesAdd.Text;
                string rev = txtRevAdd.Text;
                string filenm = Path.GetFileName(txtAddPgrmPointer.Text);

                string fileCont = txtAddTopView.Text;

                int cpg_id = int.Parse(cbCPAdd.SelectedValue.ToString());
                string cpg_name = cbCPAdd.Text;

                int cusId = int.Parse(cbCustAdd.SelectedValue.ToString());
                string custNm = cbCustAdd.Text;

                int ncid = maxNCID + 1;
                int mid = maxCpMgAssoId + 1;

                SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
                sqlCon.Open();

                String query = "INSERT INTO NCPROG(id, UniqueReference, remoteCallId, programPointer, descr, notes, revision, revision_date, NCFile, fkMachGroupId,  filename) VALUES " + "( '" + ncid + "', '" + unqRef + "', '" + rcid + "', '" + pgrmPtr + "', '" + desc + "', '" + notes + "', '" + rev + "', '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "', '" + pgrmPtr + "', '" + cpg_id + "', '" + filenm + "'  )";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();


                sqlCon.Open();
                String query2 = "INSERT INTO CtrlProgCustMGAssoc(id, custid, urid, mgid, custName) VALUES " + "( '" + mid + "', '" + cusId + "', '" + unqRef + "', '" + cpg_id + "', '" + custNm + "' )";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.ExecuteNonQuery();
                sqlCon.Close();

                File.WriteAllText(filenm, fileCont);

                MessageBox.Show(" '" + pgrmPtr + "' was successfully saved.", "Fusion PDO - Control Program Navigator", MessageBoxButton.OK, MessageBoxImage.Information);

                dgProgramFiles.ItemsSource = contProgram().DefaultView;
                dgProgramFiles.IsEnabled = true;
                dgProgramFiles.SelectedIndex = maxcount;
                dgProgramFiles.Focus();
                refID.ItemsSource = referenceID().DefaultView;
                refID.IsEnabled = true;
                refID.SelectedIndex = maxcount;
                refID.Focus();
                reqID.ItemsSource = requestID().DefaultView;
                reqID.IsEnabled = true;
                reqID.SelectedIndex = maxcount;
                reqID.Focus();
                dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
                refID.ScrollIntoView(refID.SelectedItem);
                reqID.ScrollIntoView(reqID.SelectedItem);
                addNewGrid.Visibility = Visibility.Collapsed;
                addNewGrid.Visibility = Visibility.Collapsed;
                txtAddmReqID.Text = null;
                txtAddRefID.Text = null;
                txtAddPgrmPointer.Text = null;
                txtAddTopView.Text = null;
                txtAddBotView.Text = null;
                txtRevAdd.Text = null;
                txtNotesAdd.Text = null;
            }
            else
            {
                MessageBox.Show("Please select a program pointer.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAdd_removeID_Click(object sender, RoutedEventArgs e)
        {
            string strFile = txtAddPgrmPointer.Text;
            if (strFile == "")
            {
                MessageBox.Show("No program pointer selected.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                removeID();
            }
        }

        void removeID()
        {
            string strFile = txtAddPgrmPointer.Text;
            var file = new List<string>(System.IO.File.ReadAllLines(strFile));
            string textToInsert = "(REFID = " + txtAddRefID.Text + " DNCID = " + txtAddmReqID.Text + ")";
            if (file.Contains(textToInsert))
            {
                file.RemoveAt(1);
                File.WriteAllLines(txtAddPgrmPointer.Text, file.ToArray());
            }
            else
            {
                File.WriteAllLines(txtAddPgrmPointer.Text, file.ToArray());
            }
            txtAddTopView.Text = File.ReadAllText(strFile);
        }

        private void rbAdd_autoAscend_Checked(object sender, RoutedEventArgs e)
        {
            string maxRefID = "";
            string tmpMaxRefID = "";
            string maxRCID = "";
            string tmpMaxRCID = "";
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            String query = "SELECT MAX(UniqueReference) as UniqueReference, MAX(try_cast(remoteCallId as int)) as remoteCallId FROM NCPROG";

            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            var dr = sqlCmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string UnqRef = dr["UniqueReference"].ToString();
                    string maxCallId = dr["remoteCallId"].ToString();
                    tmpMaxRefID = UnqRef;
                    int UnqRefParse = int.Parse(tmpMaxRefID);
                    maxRefID = (UnqRefParse + 1).ToString();

                    while (maxRefID.Length < 7)
                    {
                        maxRefID = "0" + maxRefID;
                    }


                    tmpMaxRCID = maxCallId;
                    int maxRCIDParse = int.Parse(tmpMaxRCID);
                    maxRCID = (maxRCIDParse +1).ToString();
                    
                }
            }
            sqlCon.Close();
            dr.Close();

            txtAddmReqID.Text = maxRefID;
            txtAddmReqID.Text = maxRCID.ToString() ;
        }
        private void rbAdd_flWoExt_Click(object sender, RoutedEventArgs e)
        {
            string strFile = txtAddPgrmPointer.Text;
            txtAddmReqID.Text = Path.GetFileNameWithoutExtension(strFile).ToUpper();
            AddCtrlPgrmSave.IsEnabled = true;
            txtAddmReqID.IsEnabled = false;
        }

        private void rbAdd_flWtExt_Click(object sender, RoutedEventArgs e)
        {
            string strFile = txtAddPgrmPointer.Text;
            txtAddmReqID.Text = Path.GetFileName(strFile).ToUpper();
            AddCtrlPgrmSave.IsEnabled = true;
            txtAddmReqID.IsEnabled = false;
        }

        private void rbAdd_userDefined_Click(object sender, RoutedEventArgs e)
        {
            txtAddmReqID.Text = "";
            txtAddmReqID.IsEnabled = true;
            txtAddmReqID.Focus();
            AddCtrlPgrmSave.IsEnabled = false;
        }

        private void txtAddmReqID_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ = txtAddmReqID.Text.Trim().Length > 0 ? AddCtrlPgrmSave.IsEnabled = true : AddCtrlPgrmSave.IsEnabled = false;
        }

        private void rbAdd_flWtNum_Checked(object sender, RoutedEventArgs e)
        {
            string strFile = txtAddPgrmPointer.Text;
            bool isDigitPresent = strFile.Any(c => char.IsDigit(c));

            if (isDigitPresent == true)
            {
                string newFile = Path.GetFileNameWithoutExtension(strFile).ToUpper();
                string file = newFile;
                txtAddmReqID.Text = GetNumbers(file);
            }
            else
            {
                MessageBox.Show("Selected REQID creation rule is not valid for this Program Pointer , please select a different Creation Rule or Program Pointer", "Control Program", MessageBoxButton.OK, MessageBoxImage.Information);
                txtAddmReqID.Text = "";
                AddCtrlPgrmSave.IsEnabled = false;
            }
        }

        // QUALIFIER CHAR "O" UNTIL NON-NUMERIC
        private void rbAdd_flWtNumAft_Checked(object sender, RoutedEventArgs e)
        {
            string[] lines = File.ReadAllLines(txtAddPgrmPointer.Text);
            string extText = "";
            foreach (string line in lines)
            {
                if (line.Contains("O") || line.Contains("o"))
                {
                    string text = line.Substring(0, 1);
                    if (text.Contains("O") || text.Contains("o"))
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (char.IsDigit(line[i]))
                            {
                                extText += line[i];
                            }
                        }
                        txtAddmReqID.Text = extText;
                    }
                    else
                    {
                        MessageBox.Show("Selected REQID creation rule is not valid for this Program Pointer , please select a different Creation Rule or Program Pointer", "Control Program", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtAddmReqID.Text = "";
                        AddCtrlPgrmSave.IsEnabled = false;
                    }
                    break;
                }
            }

        }

        private void rbAdd_autoAvail_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstAvailNum = "";
                List<int> myList = new List<int>();
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT TOP 1 T1.remoteCallId + 1 AS firstAvailNum FROM NCPROG T1 LEFT JOIN NCPROG T2 ON T2.remoteCallId = T1.remoteCallId + 1 WHERE T2.remoteCallId IS NULL ORDER BY T1.remoteCallId DESC";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                var dr = sqlCmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string rcid = dr["firstAvailNum"].ToString();
                        firstAvailNum = rcid;

                    }
                }
                sqlCon.Close();
                dr.Close();

                txtAddmReqID.Text = firstAvailNum;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void AddNotes_Click(object sender, RoutedEventArgs e)
        {
            txtNotesAdd.IsEnabled = true;
            if (txtNotesAdd.Text == "")
            {
                string text_to_append = "***************************\nUser: " + Properties.Settings.Default.loginUname + "\n" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\n\n\n";
                txtNotesAdd.AppendText(text_to_append.ToString());
                //txtNotesAdd.Focus();
            }
            else { }
        }


        //START EDIT FUNCTIONS

        private void btnEditOpen_Click(object sender, RoutedEventArgs e)
        {
            editOpen();
        }

        private void editOpen()
        {
            FillComboBoxCntrlPgrmGrp(cbCPEdit);
            FillComboBoxAssocCust(cbCustEdit);

            int indxCPG = mid;
            int indxCus = cusid;
            cbCPEdit.SelectedIndex = indxCPG - 1;
            cbCustEdit.SelectedIndex = indxCus - 1;

            editGrid.Visibility = Visibility.Visible;
            txtEditRefID.Text = txtBoxRefID.Text;
            txtEditPgrmPointer.Text = txtBoxPath.Text;
            rbEdit_current.IsChecked = true;
            txtEditReqID.Text = txtBoxRemReqId.Text;
            txtNotesEdit.Text = txtBoxNotes.Text;

            //mid = int.Parse(cbCPEdit.SelectedValue.ToString());
            //cusid = int.Parse(cbCustEdit.SelectedValue.ToString());
            cusname = cbCPEdit.Text;
            EditCtrlPgrmSave.IsEnabled = true;
            readFile();
        }

        void readFile()
        {
            if (File.Exists(txtEditPgrmPointer.Text ))
            {
                string fileSize = new FileInfo(txtEditPgrmPointer.Text).Length.ToString();
                int parseFileSize = int.Parse(fileSize);

                if (parseFileSize < 1000)
                {
                    txtEditTopView.Text = File.ReadAllText(txtEditPgrmPointer.Text);
                    tbEntireFileEdit.Visibility = Visibility.Visible;
                    txtEditBotView.IsEnabled = false;
                }
                else
                {
                    byte[] lineCont = new byte[500];
                    BinaryReader bread = new BinaryReader(new FileStream(txtEditPgrmPointer.Text, FileMode.Open, FileAccess.Read));
                    bread.BaseStream.Seek(0, SeekOrigin.Begin);
                    bread.Read(lineCont, 0, 500);
                    bread.Close();
                    txtEditTopView.Text = Encoding.UTF8.GetString(lineCont);

                    byte[] lineCont2 = new byte[500];
                    BinaryReader bread2 = new BinaryReader(new FileStream(txtEditPgrmPointer.Text, FileMode.Open, FileAccess.Read));
                    bread2.BaseStream.Seek(-500, SeekOrigin.End);
                    bread2.Read(lineCont2, 0, 500);
                    bread2.Close();

                    
                    txtEditBotView.Text = Encoding.UTF8.GetString(lineCont2);
                    txtEditBotView.ScrollToEnd();

                    tbEntireFileEdit.Visibility = Visibility.Hidden;
                    txtEditBotView.IsEnabled = true;

                }

            }
            else
            {
                //MessageBox.Show("File does not exist.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
                //editGrid.Visibility = Visibility.Collapsed;
                txtEditTopView.Text = "";
            }
        }

        private void editCtrPrgrmClose_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                editGrid.Visibility = Visibility.Collapsed;
                dgProgramFiles.ItemsSource = contProgram().DefaultView;
                dgProgramFiles.IsEnabled = true;
                dgProgramFiles.SelectedIndex = dgSelRow;
                dgProgramFiles.Focus();
                txtEditRefID.Text = null;
                txtEditReqID.Text = null;
                txtEditPgrmPointer.Text = null;
                txtEditTopView.Text = null;
                txtEditBotView.Text = null;
                txtRevEdit.Text = null;
                txtNotesEdit.Text = null;
                txtDescEdit.Text = null;
                dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            }
            else
            {
                editGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void editCtrlPgrmCancel_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                editGrid.Visibility = Visibility.Collapsed;
                dgProgramFiles.ItemsSource = contProgram().DefaultView;
                dgProgramFiles.IsEnabled = true;
                dgProgramFiles.SelectedIndex = dgSelRow;
                dgProgramFiles.Focus();
                txtEditRefID.Text = null;
                txtEditReqID.Text = null;
                txtEditPgrmPointer.Text = null;
                txtEditTopView.Text = null;
                txtEditBotView.Text = null;
                txtRevEdit.Text = null;
                txtNotesEdit.Text = null;
                txtDescEdit.Text = null;
                dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);
            }
            else
            {
                editGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void editPrgrmPointerBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            while (openFileDialog.ShowDialog() == true)
            {
                txtEditPgrmPointer.Text = openFileDialog.FileName;
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT COUNT(*) FROM NCPROG WHERE programPointer = '" + txtEditPgrmPointer.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                int count = (int)sqlCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Program Pointer is already associated to a control program.\nPlease select another Program Pointer.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtEditPgrmPointer.Text = "";
                    continue;
                }
                else
                {
                    txtEditTopView.Text = File.ReadAllText(openFileDialog.FileName);
                    //rbStackPanel.IsEnabled = true;
                    break;
                }
            }
        }

        private void EditCtrlPgrmSave_Click(object sender, RoutedEventArgs e) // BUTTON EDIT SAVE FUNCTION
        {
            if (File.Exists(txtEditPgrmPointer.Text))
            {
                string rcid = txtBoxRemReqId.Text;
                string unqRef = txtBoxRefID.Text;
                string pgrmPtr = txtEditPgrmPointer.Text;
                string desc = txtDescEdit.Text;
                string notes = txtNotesEdit.Text;
                string rev = txtRevEdit.Text;
                string filenm = Path.GetFileName(txtEditPgrmPointer.Text);
                mid = int.Parse(cbCPEdit.SelectedValue.ToString());
                cusid = int.Parse(cbCustEdit.SelectedValue.ToString());
                cusname = cbCustEdit.Text;
                int m = mid;
                int cus = cusid;
                string cm = cusname;

                string newRcid = txtEditReqID.Text;

                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query2 = "UPDATE NCPROG SET UniqueReference = '" + unqRef + "', remoteCallId = '" + newRcid + "', programPointer = '" + pgrmPtr + "',  descr = '" + desc + "', notes = '" + notes + "', revision = '" + rev + "', revision_date = '" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "', NCFile = '" + pgrmPtr + "', fkMachGroupId = '" + m + "', filename = '" + filenm + "' WHERE UniqueReference = '" + unqRef + "' ";
                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);
                sqlCmd2.ExecuteNonQuery();
                sqlCon.Close();

                sqlCon.Open();
                String query3 = "UPDATE CtrlProgCustMGAssoc SET custid = '" + cus + "',  mgid = '" + m + "', custName = '" + cm + "' WHERE urid = '" + unqRef + "' ";
                SqlCommand sqlCmd3 = new SqlCommand(query3, sqlCon);
                sqlCmd3.ExecuteNonQuery();
                sqlCon.Close();

                MessageBox.Show(" '" + pgrmPtr.ToString() + "' was successfully updated. '", "Fusion PDO - Control Program Navigator", MessageBoxButton.OK, MessageBoxImage.Information);

                dgProgramFiles.ItemsSource = contProgram().DefaultView;
                dgProgramFiles.IsEnabled = true;
                dgProgramFiles.SelectedIndex = dgSelRow;
                dgProgramFiles.Focus();

                dgProgramFiles.ScrollIntoView(dgProgramFiles.SelectedItem);

                editGrid.Visibility = Visibility.Collapsed;

                txtEditRefID.Text = null;
                txtEditReqID.Text = null;
                txtEditPgrmPointer.Text = null;
                txtEditTopView.Text = null;
                txtEditBotView.Text = null;
                txtRevEdit.Text = null;
                txtNotesEdit.Text = null;
                txtDescEdit.Text = null;
            }
            else
            {
                MessageBox.Show("Program specified by pointer does not exist.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void rbEdit_current_Checked(object sender, RoutedEventArgs e)
        {
            txtEditReqID.Text = txtBoxRemReqId.Text;
            txtEditReqID.IsEnabled = false;
            EditCtrlPgrmSave.IsEnabled = true;
        }

        private void rbEdit_userDefined_Checked(object sender, RoutedEventArgs e)
        {
            txtEditReqID.Text = "";
            txtEditReqID.IsEnabled = true;
            txtEditReqID.Focus();
            EditCtrlPgrmSave.IsEnabled = false;
        }

        private void txtEditRefID_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ = txtEditReqID.Text.Trim().Length > 0 ? EditCtrlPgrmSave.IsEnabled = true : EditCtrlPgrmSave.IsEnabled = false;
        }

        private void rbEdit_flWoExt_Checked(object sender, RoutedEventArgs e)
        {
            string strFile = txtEditPgrmPointer.Text;
            txtEditReqID.Text = Path.GetFileNameWithoutExtension(strFile).ToUpper();
            EditCtrlPgrmSave.IsEnabled = true;
            txtEditReqID.IsEnabled = false;
        }

        private void rbEdit_flWtExt_Checked(object sender, RoutedEventArgs e)
        {
            string strFile = txtEditPgrmPointer.Text;
            txtEditReqID.Text = Path.GetFileName(strFile).ToUpper();
            EditCtrlPgrmSave.IsEnabled = true;
            txtEditReqID.IsEnabled = false;
        }

        private void rbEdit_autoAscend_Checked(object sender, RoutedEventArgs e)
        {
            string maxRefID = "";
            string tmpMaxRefID = "";
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            String query = "SELECT MAX(UniqueReference) as UniqueReference FROM NCPROG";

            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            var dr = sqlCmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string UnqRef = dr["UniqueReference"].ToString();
                    tmpMaxRefID = UnqRef;
                    int UnqRefParse = int.Parse(tmpMaxRefID);
                    maxRefID = (UnqRefParse + 1).ToString();

                    while (maxRefID.Length < 7)
                    {
                        maxRefID = "0" + maxRefID;
                    }
                }
            }
            sqlCon.Close();
            dr.Close();

            txtEditReqID.Text = maxRefID;
            txtEditReqID.IsEnabled = false;
            EditCtrlPgrmSave.IsEnabled = true;
        }

        private string GetNumbers(String InputString)
        {
            String Result = "";
            string Numbers = "0123456789";
            int i = 0;

            for (i = 0; i < InputString.Length; i++)
            {
                if (Numbers.Contains(InputString.ElementAt(i)))
                {
                    Result += InputString.ElementAt(i);
                }
            }
            return Result;
        }

        private void rbEdit_flWtNum_Checked(object sender, RoutedEventArgs e)
        {
            string strFile = txtEditPgrmPointer.Text;
            bool isDigitPresent = strFile.Any(c => char.IsDigit(c));

            if (isDigitPresent == true)
            {
                string newFile = Path.GetFileNameWithoutExtension(strFile).ToUpper();
                string file = newFile;
                txtEditReqID.Text = GetNumbers(file);
            }
            else
            {
                MessageBox.Show("Selected REQID creation rule is not valid for this Program Pointer , please select a different Creation Rule or Program Pointer", "Control Program", MessageBoxButton.OK, MessageBoxImage.Information);
                txtEditReqID.Text = "";
                EditCtrlPgrmSave.IsEnabled = false;
            }
            
        }
        private void btnEdit_insertID_Click(object sender, RoutedEventArgs e)
        {
            string strFile = txtEditPgrmPointer.Text;
            int insertAtLineNumber = 1;
            string textToInsert = "(REFID = " + txtEditRefID.Text + " DNCID = " + txtEditReqID.Text + ")";

            if (strFile == "")
            {
                MessageBox.Show("No program pointer selected.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (txtEditReqID.Text == "")
            {
                MessageBox.Show("Please supply a valid Remote Request ID.", "Control Program", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEditReqID.Focus();
            }
            else
            {
                ArrayList lines = new ArrayList();
                StreamReader sr = new StreamReader(strFile);

                string line;
                while ((line = sr.ReadLine()) != null) lines.Add(line);
                sr.Close();

                if (lines.Count > insertAtLineNumber) lines.Insert(insertAtLineNumber, textToInsert);

                if (!File.ReadAllText(strFile).Contains(textToInsert))
                {
                    StreamWriter sw = new StreamWriter(strFile);
                    foreach (string newLine in lines) sw.WriteLine(newLine);
                    sw.Close();
                }

                FileInfo fi = new FileInfo(strFile);
                FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

                byte[] fileBytes = new byte[500];
                int numBytesToRead = (int)fileBytes.Length;

                int numBytesRead = 0;

                while (numBytesToRead > 0)
                {
                    int n = fs.Read(fileBytes, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }

                string filestring = Encoding.UTF8.GetString(fileBytes);
                fs.Close();
                txtEditTopView.Text = filestring;
            }
        }

        private void rbEdit_autoAvail_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstAvailNum = "";
                List<int> myList = new List<int>();
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT TOP 1 T1.remoteCallId + 1 AS firstAvailNum FROM NCPROG T1 LEFT JOIN NCPROG T2 ON T2.remoteCallId = T1.remoteCallId + 1 WHERE T2.remoteCallId IS NULL ORDER BY T1.remoteCallId DESC";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                var dr = sqlCmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string rcid = dr["firstAvailNum"].ToString();
                        firstAvailNum = rcid;
                    }
                }
                sqlCon.Close();
                dr.Close();

                txtEditReqID.Text = firstAvailNum;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void rbEdit_flWtNumAft_Checked(object sender, RoutedEventArgs e)
        {
            string[] lines = File.ReadAllLines(txtEditPgrmPointer.Text.ToUpper());
            string extText = "";
            foreach (string line in lines)
            {
                if (line.Contains("O") || line.Contains("o"))
                {
                    string text = line.Substring(0, 1);
                    if (text.Contains("O") || text.Contains("o"))
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (Char.IsDigit(line[i]))
                            {
                                extText += line[i];
                            }
                        }
                        txtEditReqID.Text = extText;
                    }
                    else
                    {
                        MessageBox.Show("Selected REQID creation rule is not valid for this Program Pointer , please select a different Creation Rule or Program Pointer", "Control Program", MessageBoxButton.OK, MessageBoxImage.Information);
                        txtEditReqID.Text = "";
                        EditCtrlPgrmSave.IsEnabled = false;
                    }
                    break;
                }

            }
        }
    }
}
