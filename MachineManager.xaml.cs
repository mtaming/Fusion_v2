using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for MachineManager.xaml
    /// </summary>
    public partial class MachineManager : Page
    {
        public MachineManager()
        {
            InitializeComponent();
            LoadMachinesQuery();
        }

        private void GeneralGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Visible;
            FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.Khaki;
            gentb.Foreground = Brushes.Khaki;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;
        }

        private void CommGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CommunicationsTvI.IsExpanded = true;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;
        }

        private void FlashDNCGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FlashDNCSetGrid.Visibility = Visibility.Visible;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            GenSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;
        }

        private void CbxFlashDNC_Checked(object sender, RoutedEventArgs e)
        {
            FlashDNC.IsEnabled = true;
        }

        private void CbxFlashDNC_Unchecked(object sender, RoutedEventArgs e)
        {
            FlashDNC.IsEnabled = false;
        }

        private void FocasGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocasSetGrid.Visibility = Visibility.Visible;
            FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            GenSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;
        }

        private void CbxFocas_Checked(object sender, RoutedEventArgs e)
        {
            Focas.IsEnabled = true;
        }

        private void CbxFocas_Unchecked(object sender, RoutedEventArgs e)
        {
            Focas.IsEnabled = false;
        }

        private void SocketGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SocketSetGrid.Visibility = Visibility.Visible;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            GenSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;
        }

        private void CbxSocket_Checked(object sender, RoutedEventArgs e)
        {
            Socket.IsEnabled = true;
        }

        private void CbxSocket_Unchecked(object sender, RoutedEventArgs e)
        {
            Socket.IsEnabled = false;
        }

        private void FolderWatchGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FolderWtchSetGrid.Visibility = Visibility.Visible;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            GenSetGrid.Visibility = Visibility.Collapsed;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;
        }

        private void CbxFldrWtch_Checked(object sender, RoutedEventArgs e)
        {
            FldrWtch.IsEnabled = true;
        }

        private void CbxFldrWtch_Unchecked(object sender, RoutedEventArgs e)
        {
            FldrWtch.IsEnabled = false;
        }

        private void RemReqGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RemoteRequestTvI.IsExpanded = true;

            remreqicon.Foreground = Brushes.Khaki;
            remreqtb.Foreground = Brushes.Khaki;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;
        }


        // *** //

        public class Machines
        {
            public int machId { get; set; }
            public string machName { get; set; }
        }

        IList<Machines> mach = new List<Machines>();

        public void LoadMachinesQuery()
        {
            MachListBox.ItemsSource = null;
            mach = new List<Machines>();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                string mach_query = "SELECT * FROM MACHINE ORDER BY machine_name";
                SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "MACHINE");

                Machines m = new Machines();
                mach = new List<Machines>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    mach.Add(new Machines()
                    {
                        machId = int.Parse(dr["machine_id"].ToString()),
                        machName = dr["machine_name"].ToString()
                    }); ;
                }
                MachListBox.ItemsSource = mach;
                MachListBox.SelectedIndex = 0;

                da.Dispose();
                ds.Dispose();
                sqlCon.Close();

            }
            catch (Exception ex) { ex.Message.ToString(); }
        }
        private void MachListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                {
                    var item = (ListBox)sender;
                    var sel_mach = (Machines)item.SelectedItem;
                    int id = sel_mach.machId;

                    SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                    sqlCon.Open();
                    string mach_query = "SELECT * FROM MACHINE INNER JOIN Machine_Group_Assoc ON MACHINE.machine_id=Machine_Group_Assoc.FK_machine_id INNER JOIN Machine_Groups ON Machine_Groups.machine_group_id=Machine_Group_Assoc.FK_machine_group_id WHERE MACHINE.machine_id = '" + id + "'";
                    SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string machine_level = dr["machineLevel"].ToString();
                            string machine_name = dr["machine_name"].ToString();
                            int cpg_id = int.Parse(dr["machine_group_id"].ToString());
                            string ctrlPgrmGrp = dr["machine_group_name"].ToString();
                            string facility_id = dr["AlternateID"].ToString();
                            string notes = dr["note"].ToString();

                            int MachId = int.Parse(dr["machine_id"].ToString());
                            selID.Text = MachId.ToString();

                            //Fill controls
                            if (machine_level == "1")
                            {
                                rbMachLvl1.IsEnabled = true;
                                rbMachLvl2.IsEnabled = false;
                                rbMachLvl3.IsEnabled = false;
                                rbMachLvl1.IsChecked = true;
                            }
                            else if (machine_level == "2")
                            {
                                rbMachLvl1.IsEnabled = false;
                                rbMachLvl2.IsEnabled = true;
                                rbMachLvl3.IsEnabled = false;
                                rbMachLvl2.IsChecked = true;
                            }
                            else if (machine_level == "3")
                            {
                                rbMachLvl1.IsEnabled = false;
                                rbMachLvl2.IsEnabled = false;
                                rbMachLvl3.IsEnabled = true;
                                rbMachLvl3.IsChecked = true;
                            }
                            else
                            {
                                rbMachLvl1.IsEnabled = false;
                                rbMachLvl2.IsEnabled = false;
                                rbMachLvl3.IsEnabled = false;
                            }//machine level

                            TxtBoxMachName.Text = machine_name;
                            txtCPG_id.Text = cpg_id.ToString(); //ID OF CONTROL PROGRAM GROUP
                            TxtBoxCtrlPgrmGrp.Text = ctrlPgrmGrp;
                            TxtBoxFacId.Text = facility_id;
                            TxtBoxNotes.Text = notes;
                        }
                    }

                    dr.Close();
                    sqlCon.Close();
                }
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        //Machine License Manager Functions

        private void btnOpenMachLicMngr_Click(object sender, RoutedEventArgs e)
        {
            MachLicenseManagerGrid.Visibility = Visibility.Visible;
            MachineLicenseLevels();
        }

        private void BtnCloseMachLicenseMngr_Click(object sender, RoutedEventArgs e)
        {
            MachLicenseManagerGrid.Visibility = Visibility.Collapsed;
        }

        public class MachLevel1
        {
            public int MachLvl1_ID { get; set; }
            public string MachLvl1_Name { get; set; }
            public string MachLvl1_Level { get; set; }
        }

        public class MachLevel2
        {
            public int MachLvl2_ID { get; set; }
            public string MachLvl2_Name { get; set; }
            public string MachLvl2_Level { get; set; }
        }
        public class MachLevel3
        {
            public int MachLvl3_ID { get; set; }
            public string MachLvl3_Name { get; set; }
            public string MachLvl3_Level { get; set; }
        }

        IList<MachLevel1> machLvl1 = new List<MachLevel1>();
        IList<MachLevel2> machLvl2 = new List<MachLevel2>();
        IList<MachLevel3> machLvl3 = new List<MachLevel3>();

        public void MachineLicenseLevels()
        {
            LstBoxMachLvl1.ItemsSource = null;
            LstBoxMachLvl2.ItemsSource = null;
            LstBoxMachLvl3.ItemsSource = null;
            machLvl1 = new List<MachLevel1>();
            machLvl2 = new List<MachLevel2>();
            machLvl3 = new List<MachLevel3>();

            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                string mach_query = "SELECT * FROM MACHINE ORDER BY machine_name";
                SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int mach_id = int.Parse(dr["machine_id"].ToString());
                        string mach_name = dr["machine_name"].ToString();
                        string mach_level = dr["machineLevel"].ToString();

                        if (mach_level == "1")
                        {
                            machLvl1.Add(new MachLevel1()
                            {
                                MachLvl1_ID = mach_id,
                                MachLvl1_Name = mach_name,
                                MachLvl1_Level = mach_level
                            });
                        }
                        else if (mach_level == "2")
                        {
                            machLvl2.Add(new MachLevel2()
                            {
                                MachLvl2_ID = mach_id,
                                MachLvl2_Name = mach_name,
                                MachLvl2_Level = mach_level
                            });
                        }
                        else
                        {
                            machLvl3.Add(new MachLevel3()
                            {
                                MachLvl3_ID = mach_id,
                                MachLvl3_Name = mach_name,
                                MachLvl3_Level = mach_level
                            });
                        }
                    }
                }
                LstBoxMachLvl1.ItemsSource = machLvl1;
                LstBoxMachLvl2.ItemsSource = machLvl2;
                LstBoxMachLvl3.ItemsSource = machLvl3;


                sqlCon.Close();
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        //public void MachLevel2Query()
        //{
        //    LstBoxMachLvl2.ItemsSource = null;
        //    machLvl2 = new List<MachLevel2>();

        //    try
        //    {
        //        SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
        //        sqlCon.Open();
        //        string mach_query = "SELECT * FROM MACHINE WHERE machineLevel = 2 ORDER BY machine_name";
        //        SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds, "MACHINE");

        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            machLvl2.Add(new MachLevel2()
        //            {
        //                MachLvl2_ID = int.Parse(dr["machine_id"].ToString()),
        //                MachLvl2_Name = dr["machine_name"].ToString(),
        //                MachLvl2_Level = dr["machineLevel"].ToString()
        //            });
        //        }
        //        LstBoxMachLvl2.ItemsSource = machLvl2;

        //        da.Dispose();
        //        ds.Dispose();
        //        sqlCon.Close();
        //    }
        //    catch (Exception ex) { ex.Message.ToString(); }
        //}

        //public void MachLevel3Query()
        //{
        //    LstBoxMachLvl3.ItemsSource = null;
        //    machLvl3 = new List<MachLevel3>();

        //    try
        //    {
        //        SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
        //        sqlCon.Open();
        //        string mach_query = "SELECT * FROM MACHINE WHERE machineLevel = 3 ORDER BY machine_name";
        //        SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds, "MACHINE");

        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            machLvl3.Add(new MachLevel3()
        //            {
        //                MachLvl3_ID = int.Parse(dr["machine_id"].ToString()),
        //                MachLvl3_Name = dr["machine_name"].ToString(),
        //                MachLvl3_Level = dr["machineLevel"].ToString()
        //            });
        //        }
        //        LstBoxMachLvl3.ItemsSource = machLvl3;

        //        da.Dispose();
        //        ds.Dispose();
        //        sqlCon.Close();
        //    }
        //    catch (Exception ex) { ex.Message.ToString(); }
        //}

        //ComboBox Control Program Group
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
                comBoxName.SelectedIndex = 0;
                da.Dispose();
                sqlCon.Close();
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }





        //add new machine
        private void btnAddNewMach_Click(object sender, RoutedEventArgs e)
        {
            rbMachLvl1.IsEnabled = true;
            rbMachLvl2.IsEnabled = true;
            rbMachLvl3.IsEnabled = true;
            rbMachLvl1.IsChecked = true;
            TxtBoxMachName.IsReadOnly = false;
            TxtBoxCtrlPgrmGrp.IsReadOnly = true;
            TxtBoxFacId.IsReadOnly = false;
            TxtBoxNotes.IsReadOnly = false;
            TxtBoxMachName.Text = "";
            TxtBoxCtrlPgrmGrp.Text = "";
            TxtBoxFacId.Text = "";
            TxtBoxNotes.Text = "";
            btnOpenMachLicMngr.IsEnabled = false;
            btnAddNewMach.Visibility = Visibility.Collapsed;
            btnSaveAdd.Visibility = Visibility.Visible;
            btnEdit.IsEnabled = false;
            btnDuplicate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnCancel.IsEnabled = true;
            MachListBox.IsEnabled = false;
            //tabItemGeneral.IsSelected = true;
            //tabItemGeneral.Focus();
            TxtBoxMachName.Focus();
            CmbBoxCtrlPgrmGrp.Visibility = Visibility.Visible;
            TxtBoxCtrlPgrmGrp.Visibility = Visibility.Collapsed;
            FillComboBoxCntrlPgrmGrp(CmbBoxCtrlPgrmGrp);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            rbMachLvl1.IsEnabled = false;
            rbMachLvl2.IsEnabled = false;
            rbMachLvl3.IsEnabled = false;
            rbMachLvl1.IsChecked = false;
            TxtBoxMachName.IsReadOnly = true;
            TxtBoxCtrlPgrmGrp.IsReadOnly = true;
            TxtBoxFacId.IsReadOnly = true;
            TxtBoxNotes.IsReadOnly = true;
            btnOpenMachLicMngr.IsEnabled = true;
            btnAddNewMach.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Visible;
            btnSaveAdd.Visibility = Visibility.Collapsed;
            btnSaveEdit.Visibility = Visibility.Collapsed;
            btnAddNewMach.IsEnabled = true;
            btnEdit.IsEnabled = true;
            btnDuplicate.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnCancel.IsEnabled = false;
            MachListBox.IsEnabled = true;
            CmbBoxCtrlPgrmGrp.Visibility = Visibility.Collapsed;
            TxtBoxCtrlPgrmGrp.Visibility = Visibility.Visible;
            LoadMachinesQuery();
        }


        //edit selected machine
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxMachName.IsReadOnly = false;
            TxtBoxCtrlPgrmGrp.IsReadOnly = true;
            TxtBoxFacId.IsReadOnly = false;
            TxtBoxNotes.IsReadOnly = false;
            btnOpenMachLicMngr.IsEnabled = false;
            btnAddNewMach.IsEnabled = false;
            btnEdit.Visibility = Visibility.Collapsed;
            btnSaveEdit.Visibility = Visibility.Visible;
            btnDuplicate.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnCancel.IsEnabled = true;
            MachListBox.IsEnabled = false;
            TxtBoxMachName.Focus();
            TxtBoxMachName.SelectAll();
            CmbBoxCtrlPgrmGrp.Visibility = Visibility.Visible;
            TxtBoxCtrlPgrmGrp.Visibility = Visibility.Collapsed;
            FillComboBoxCntrlPgrmGrp(CmbBoxCtrlPgrmGrp);
            CmbBoxCtrlPgrmGrp.SelectedIndex = int.Parse(txtCPG_id.Text) - 1;
        }


        //delete selected machine
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete selected machine.", "Fusion PDO - Machine Manager", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                string del_query = "DELETE FROM MACHINE WHERE machine_id = '" + selID.Text + "'; DELETE FROM Machine_Group_Assoc WHERE FK_machine_id = '" + selID.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(del_query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                MessageBox.Show("Selected Machine successfully deleted.", "Fusion PDO - Machine Manager", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadMachinesQuery();
                MachListBox.ScrollIntoView(MachListBox.SelectedItem);
            }
        }

       
    }
}
