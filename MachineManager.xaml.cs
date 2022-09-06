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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CheckBox = System.Windows.Controls.CheckBox;
using ComboBox = System.Windows.Controls.ComboBox;
using DragDropEffects = System.Windows.DragDropEffects;
using ListBox = System.Windows.Controls.ListBox;
using MessageBox = System.Windows.MessageBox;
using System.Net;
using System.Text.RegularExpressions;
using DataFormats = System.Windows.DataFormats;
using DataObject = System.Windows.DataObject;
using System.ComponentModel;
using System.Collections;
using System.Windows.Media.Animation;
using System.IO;

namespace Fusion_v2
{
    /// <summary>
    /// Interaction logic for MachineManager.xaml
    /// </summary>
    public partial class MachineManager : Page
    {
        public const int MACHLEVEL2 = 50;
        public const int MACHLEVEL3 = 80;

        public MachineManager()
        {
            InitializeComponent();
            LoadMachinesQuery();
            
        }

        #region TreeVIew
        private void GeneralGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Storyboard openMenu = (Storyboard)GeneralGrid.FindResource("OpenMenu");
            //openMenu.Begin();
            GenSetGrid.Visibility = Visibility.Visible;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.Khaki;
            gentb.Foreground = Brushes.Khaki;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }

        private void CommGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CommunicationsTvI.IsExpanded = true;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }

        private void FlashDNCGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Visible;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }

        //private void CbxFlashDNC_Checked(object sender, RoutedEventArgs e)
        //{
        //    FlashDNC.IsEnabled = true;
        //}

        //private void CbxFlashDNC_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    FlashDNC.IsEnabled = false;
        //}

        private void FocasGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Visible;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
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
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Visible;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;


            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }
        private void FolderWatchGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Visible;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }
        private void NPortGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Visible;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }
        private void FTPGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Visible;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.Khaki;
            commtb.Foreground = Brushes.Khaki;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }

        private void RemReqGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RemoteRequestTvI.IsExpanded = true;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.Khaki;
            remreqtb.Foreground = Brushes.Khaki;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }

        private void RemReqSetGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Visible;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.Khaki;
            remreqtb.Foreground = Brushes.Khaki;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }

        private void ParsingRulesGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Visible;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.Khaki;
            remreqtb.Foreground = Brushes.Khaki;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;

            rbShrtLookup.IsChecked = true;
        }


        private void OpMessGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ApplyToMach();
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Visible;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.Khaki;
            opmesstb.Foreground = Brushes.Khaki;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }

        private void PersonnelGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoadPersonnel();
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Visible;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.Khaki;
            persontb.Foreground = Brushes.Khaki;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
        }
        private void InFileGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GenSetGrid.Visibility = Visibility.Collapsed;
            //CommSetGrid.Visibility = Visibility.Collapsed;
            //FlashDNCSetGrid.Visibility = Visibility.Collapsed;
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            //RemRequestSetGrid.Visibility = Visibility.Collapsed;
            RemReqSettGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Visible;

            genIcon.Foreground = Brushes.White;
            gentb.Foreground = Brushes.White;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.Khaki;
            infiletb.Foreground = Brushes.Khaki;
        }

        #endregion

        // *** //

        #region Load Machines
        public class Machines
        {
            public int machId { get; set; }
            public string machName { get; set; }
        }

        IList<Machines> mach = new List<Machines>();

        public void LoadMachinesQuery()
        {
            cmbBxMach.ItemsSource = null;
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
                cmbBxMach.ItemsSource = mach;
                cmbBxMach.SelectedIndex = 0;
                cmbBxMach.Focus();
                BtnPrevMach.IsEnabled = false; 

                da.Dispose();
                ds.Dispose();
                sqlCon.Close();

                //MAX MACHINE ID
                sqlCon.Open();
                string maxMachQuery = "SELECT MAX(machine_id) as maxMachId FROM MACHINE";
                SqlCommand cmd2 = new SqlCommand(maxMachQuery, sqlCon);
                var dr2 = cmd2.ExecuteReader();
                dr2.Read();
                maxMachId.Text = dr2["maxMachId"].ToString();
                sqlCon.Close();
                dr2.Close();

            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        #endregion

        #region Machine SelectionChanged
        private void cmbBxMach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string machlvl = "";
            try
            {
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                {
                    var item = (ComboBox)sender;
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
                            string commOpt = dr["CommunicationOption"].ToString();

                            int MachId = int.Parse(dr["machine_id"].ToString());
                            selMachID.Text = MachId.ToString();
                            selMachLvl.Text = machine_level;
                            machlvl = machine_level;

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

                            //communication option
                            if (commOpt.Contains("None"))
                            {
                                FldrWtchTvI.IsEnabled = false;
                                FocasTvI.IsEnabled = false;
                                FtpTvI.IsEnabled = false;
                                NportTvI.IsEnabled = false;
                                SockTvI.IsEnabled = false;
                            }
                            if (commOpt.Contains("DncLink"))//folder watch
                            {
                                CbxFldrWtch.IsChecked = true;
                                CbxFldrWtch.IsEnabled = false;
                                FldrWtchTvI.IsEnabled = true;
                                FldrWtch.IsEnabled = false;

                            }
                            else
                            {
                                CbxFldrWtch.IsChecked = false;
                                CbxFldrWtch.IsEnabled = false;
                                FldrWtchTvI.IsEnabled = false;
                                FldrWtch.IsEnabled = false;
                            }
                            if (commOpt.Contains("Focas"))//focas
                            {
                                CbxFocas.IsChecked = true;
                                CbxFocas.IsEnabled = false;
                                FocasTvI.IsEnabled = true;
                                Focas.IsEnabled = false;
                            }
                            else
                            {
                                CbxFocas.IsChecked = false;
                                CbxFocas.IsEnabled = false;
                                FocasTvI.IsEnabled = false;
                                Focas.IsEnabled = false;
                            }
                            if (commOpt.Contains("Socket"))//socket
                            {
                                CbxSocket.IsChecked = true;
                                CbxSocket.IsEnabled = false;
                                SockTvI.IsEnabled = true;
                                Socket.IsEnabled = false;
                            }
                            else
                            {
                                CbxSocket.IsChecked = false;
                                CbxSocket.IsEnabled = false;
                                SockTvI.IsEnabled = false;
                                Socket.IsEnabled = false;
                            }


                            //General Controls
                            TxtBoxMachName.Text = machine_name;
                            txtCPG_id.Text = cpg_id.ToString(); //ID OF CONTROL PROGRAM GROUP
                            TxtBoxCtrlPgrmGrp.Text = ctrlPgrmGrp;
                            TxtBoxFacId.Text = facility_id;
                            TxtBoxNotes.Text = notes;

                            //Folder Watch
                            TxtBoxFldrWtchFldrDes.Text = dr["FolderWatch"].ToString() ;
                            string fldrWtchOpt = dr["FolderWatchOption"].ToString();
                            if (fldrWtchOpt == "optIncoming")
                            {
                                rbFldrWthcMvInFile.IsChecked = true;
                                rbFldrWtchDNC.IsChecked = false;
                                rbFldrWtchTCP.IsChecked = false;
                            }
                            else if (fldrWtchOpt == "optDNC")
                            {
                                rbFldrWthcMvInFile.IsChecked = false;
                                rbFldrWtchDNC.IsChecked = true;
                                rbFldrWtchTCP.IsChecked = false;
                            }
                            else if (fldrWtchOpt == "optTransfer")
                            {
                                rbFldrWthcMvInFile.IsChecked = false;
                                rbFldrWtchDNC.IsChecked = false;
                                rbFldrWtchTCP.IsChecked = true;
                            }

                            //Focas
                            TxtBxFocSttcAdd.Text = "";

                            //socket


                        }
                    }

                    dr.Close();
                    sqlCon.Close();

                    AvailableMachinePerLevel();
                }
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        public void AvailableMachinePerLevel()
        {
            string machlvl = selMachLvl.Text;
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            string machLvl = "SELECT COUNT(machineLevel) as machlvl FROM MACHINE WHERE machineLevel = '" + machlvl + "'";
            SqlCommand cmd3 = new SqlCommand(machLvl, sqlCon);
            var dr3 = cmd3.ExecuteReader();
            dr3.Read();
            string lvl = machlvl;
            if (lvl == "1")
            {
                lblAvMach.Content = "Unlimited";
                lblUsMach.Content = dr3["machlvl"].ToString();
            }
            else if (lvl == "2")
            {
                lblAvMach.Content = MACHLEVEL2 - int.Parse(dr3["machlvl"].ToString());
                lblUsMach.Content = dr3["machlvl"].ToString();
            }
            else
            {
                lblAvMach.Content = MACHLEVEL3 - int.Parse(dr3["machlvl"].ToString());
                lblUsMach.Content = dr3["machlvl"].ToString();
            }
            sqlCon.Close();
            dr3.Close();
        }
        private void BtnNextMach_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBxMach.SelectedIndex < cmbBxMach.Items.Count - 1)
            {
                cmbBxMach.SelectedIndex = cmbBxMach.SelectedIndex + 1;
                BtnPrevMach.IsEnabled = true;
            }
            else
            {
                BtnNextMach.IsEnabled = false;
            }
        }

        private void BtnPrevMach_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBxMach.SelectedIndex > 0)
            {
                cmbBxMach.SelectedIndex = cmbBxMach.SelectedIndex - 1;
                BtnNextMach.IsEnabled = true;
            }
            else
            {
                BtnPrevMach.IsEnabled = false;
            }
        }

        #endregion

        //Machine License Manager Functions
        #region Machine License Manager
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

        ListBox dragSource = null;

        private void LstBoxMachLvl1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //ListBox parent = (ListBox)sender;
            dragSource = LstBoxMachLvl1;
            object data = GetDataFromListBox(dragSource, e.GetPosition(LstBoxMachLvl1));

            if (data != null)
            {
                DragDrop.DoDragDrop(LstBoxMachLvl1, data, DragDropEffects.Move);
            }
        }
        private void LstBoxMachLvl2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dragSource = LstBoxMachLvl2;
            object data = GetDataFromListBox(dragSource, e.GetPosition(LstBoxMachLvl2));

            if (data != null)
            {
                DragDrop.DoDragDrop(LstBoxMachLvl2, data, DragDropEffects.Move);
            }
        }
        private void LstBoxMachLvl2_Drop(object sender, System.Windows.DragEventArgs e)
        {
            //ListBox parent = (ListBox)sender;
            //LstBoxMachLvl2.ItemsSource = null;
            //object data = e.Data.GetData(typeof(string));
            //((IList)LstBoxMachLvl1.ItemsSource).Remove(data);
            //LstBoxMachLvl1.Items.Add(data);
        }

        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);

                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }

                    if (element == source)
                    {
                        return null;
                    }
                }

                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }

            return null;
        }


        #endregion


        //add new machine
        #region Add, Edit, Delete, Cancel
        private void btnAddNewMach_Click(object sender, RoutedEventArgs e)
        {
            FocasSetGrid.Visibility = Visibility.Collapsed;
            SocketSetGrid.Visibility = Visibility.Collapsed;
            FolderWtchSetGrid.Visibility = Visibility.Collapsed;
            NportSetGrid.Visibility = Visibility.Collapsed;
            FTPSetGrid.Visibility = Visibility.Collapsed;
            RemReqSetGrid.Visibility = Visibility.Collapsed;
            ParRulesSetGrid.Visibility = Visibility.Collapsed;
            InFileSetGrid.Visibility = Visibility.Collapsed;
            OpMessageSetGrid.Visibility = Visibility.Collapsed;
            PersonnelSetGrid.Visibility = Visibility.Collapsed;
            GenSetGrid.Visibility = Visibility.Visible;
            GeneralTvI.IsSelected = true;
            genIcon.Foreground = Brushes.Khaki;
            gentb.Foreground = Brushes.Khaki;

            commIcon.Foreground = Brushes.White;
            commtb.Foreground = Brushes.White;

            remreqicon.Foreground = Brushes.White;
            remreqtb.Foreground = Brushes.White;

            opmessicon.Foreground = Brushes.White;
            opmesstb.Foreground = Brushes.White;

            personsicon.Foreground = Brushes.White;
            persontb.Foreground = Brushes.White;

            infileicon.Foreground = Brushes.White;
            infiletb.Foreground = Brushes.White;
            mchLstBrdr.IsEnabled = false;
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
            //MachListBox.IsEnabled = false;
            //GeneralTvI.IsSelected = true;
            //tabItemGeneral.Focus();
            TxtBoxMachName.Focus();
            CmbBoxCtrlPgrmGrp.Visibility = Visibility.Visible;
            TxtBoxCtrlPgrmGrp.Visibility = Visibility.Collapsed;
            FillComboBoxCntrlPgrmGrp(CmbBoxCtrlPgrmGrp);

            if (rbMachLvl1.IsChecked == true)
            {
                FldrWtchTvI.IsEnabled = true;
                FocasTvI.IsEnabled = false;
                SockTvI.IsEnabled = false;
                CbxFldrWtch.IsEnabled = true;
                CbxFldrWtch.IsChecked = false;
            }
            else if (rbMachLvl2.IsChecked == true)
            {
                FldrWtchTvI.IsEnabled = true;
                FocasTvI.IsEnabled = false;
                SockTvI.IsEnabled = false;
                CbxFldrWtch.IsEnabled = true;
                CbxFldrWtch.IsChecked = false;
            }
            else if (rbMachLvl3.IsChecked == true)
            {
                FldrWtchTvI.IsEnabled = true;
                FocasTvI.IsEnabled = true;
                SockTvI.IsEnabled = true;
                CbxFldrWtch.IsEnabled = true;
                CbxFldrWtch.IsChecked = false;
                CbxFocas.IsEnabled = true;
                CbxFocas.IsChecked = false;
                CbxSocket.IsEnabled = true;
                CbxSocket.IsChecked = false;
            }
        }

        private void btnSaveAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNewMachineQuery();
           
        }

        public void AddNewMachineQuery()
        {
            if (TxtBoxMachName.Text == "")
            {
                MessageBox.Show("Please fill out required fields.", "Fusion PDO - Machine Manager", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                TxtBoxMachName.Focus();
            }
            else
            {
                try
                {
                    //GENERAL CONTROLS
                    int newMachId = int.Parse(maxMachId.Text) + 1;
                    string newMachName = TxtBoxMachName.Text;
                    int newMachGrpId = int.Parse(CmbBoxCtrlPgrmGrp.SelectedValue.ToString());
                    string newFacId = TxtBoxFacId.Text;
                    string newMachNote = TxtBoxNotes.Text;
                    string tmpMachLicLvl = "";
                    if (rbMachLvl1.IsChecked == true)
                    {
                        tmpMachLicLvl = "1";
                    }
                    else if (rbMachLvl2.IsChecked == true)
                    {
                        tmpMachLicLvl = "2";
                    }
                    else if (rbMachLvl3.IsChecked == true)
                    {
                        tmpMachLicLvl = "3";
                    }
                    string newMachLicLvl = tmpMachLicLvl;

                    SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
                    sqlCon.Open();
                    string inMachQuery = "INSERT INTO MACHINE(machine_id, machine_name, note, AlternateID, machineLevel) VALUES('" + newMachId + "', '" + newMachName + "', '" + newMachNote + "', '" + newFacId + "', '" + newMachLicLvl + "'); INSERT INTO Machine_Group_Assoc(FK_machine_id, FK_machine_group_id) VALUES('" + newMachId + "', '" + newMachGrpId + "')";
                    SqlCommand cmd = new SqlCommand(inMachQuery, sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();

                    MessageBox.Show("New Machine successfully added.", "Fusion PDO - Machine Manager", MessageBoxButton.OK, MessageBoxImage.Information);

                    Cancel();
                }
                catch (Exception ex) { ex.Message.ToString(); }
            }
        }


        //Cancel Action - Add, Update
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Cancel();
        }
        
        public void Cancel()
        {
            mchLstBrdr.IsEnabled = true;
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
            //MachListBox.IsEnabled = true;
            CmbBoxCtrlPgrmGrp.Visibility = Visibility.Collapsed;
            TxtBoxCtrlPgrmGrp.Visibility = Visibility.Visible;

            LoadMachinesQuery();
        }


        //edit selected machine
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            mchLstBrdr.IsEnabled = false;
            rbMachLvl1.IsEnabled = true;
            rbMachLvl2.IsEnabled = true;
            rbMachLvl3.IsEnabled = true;
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
            //MachListBox.IsEnabled = false;
            TxtBoxMachName.Focus();
            TxtBoxMachName.SelectAll();
            CmbBoxCtrlPgrmGrp.Visibility = Visibility.Visible;
            TxtBoxCtrlPgrmGrp.Visibility = Visibility.Collapsed;
            FillComboBoxCntrlPgrmGrp(CmbBoxCtrlPgrmGrp);
            CmbBoxCtrlPgrmGrp.SelectedIndex = int.Parse(txtCPG_id.Text) - 1;

            if (CbxSocket.IsChecked == true)
            {
                CbxSocket.IsEnabled = true;
                Socket.IsEnabled = true;
            }
            if (CbxFldrWtch.IsChecked == true)
            {
                CbxFldrWtch.IsEnabled = true;
                FldrWtch.IsEnabled = true;
            }
            if (CbxFocas.IsChecked == true)
            {
                CbxFocas.IsEnabled = true;
                Focas.IsEnabled = true;
            }

        }

        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            SaveUpdateSelMach();
        }

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

        
        public void SaveUpdateSelMach()
        {
            if (TxtBoxMachName.Text == "")
            {
                MessageBox.Show("Please fill out required fields.", "Fusion PDO - Machine Manager", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                TxtBoxMachName.Focus();
            }
            else
            {
                try
                {
                    //GENERAL CONTROLS
                    string editMachName = TxtBoxMachName.Text;
                    int editMachGrpId = int.Parse(CmbBoxCtrlPgrmGrp.SelectedValue.ToString());
                    string editFacId = TxtBoxFacId.Text;
                    string editMachNote = TxtBoxNotes.Text;
                    string tmpMachLicLvl = "";
                    if (rbMachLvl1.IsChecked == true)
                    {
                        tmpMachLicLvl = "1";
                    }
                    else if (rbMachLvl2.IsChecked == true)
                    {
                        tmpMachLicLvl = "2";
                    }
                    else if (rbMachLvl3.IsChecked == true)
                    {
                        tmpMachLicLvl = "3";
                    }
                    string editMachLicLvl = tmpMachLicLvl;

                    SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
                    sqlCon.Open();
                    string inMachQuery = "UPDATE MACHINE SET machine_name = '"+ editMachName +"', note = '"+ editMachNote +"', AlternateID = '"+ editFacId +"', machineLevel = '"+ editMachLicLvl +"' WHERE machine_id = '"+ selMachID.Text +"'; UPDATE Machine_Group_Assoc SET FK_machine_group_id = '"+ editMachGrpId +"' WHERE FK_machine_id = '"+ selMachID.Text+ "'";
                    SqlCommand cmd = new SqlCommand(inMachQuery, sqlCon);
                    cmd.ExecuteNonQuery();
                    sqlCon.Close();

                    MessageBox.Show("Selected Machine successfully updated.", "Fusion PDO - Machine Manager", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cancel();
                }
                catch (Exception ex) { ex.Message.ToString(); }
            }
        }


        //delete selected machine

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete selected machine.", "Fusion PDO - Machine Manager", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlConnection sqlCon = new SqlConnection(Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                string del_query = "DELETE FROM MACHINE WHERE machine_id = '" + selMachID.Text + "'; DELETE FROM Machine_Group_Assoc WHERE FK_machine_id = '" + selMachID.Text + "' ";
                SqlCommand sqlCmd = new SqlCommand(del_query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                MessageBox.Show("Selected Machine successfully deleted.", "Fusion PDO - Machine Manager", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadMachinesQuery();
                //MachListBox.ScrollIntoView(MachListBox.SelectedItem);
            }
        }

        #endregion

        //general
        private void rbMachLvl1_Checked(object sender, RoutedEventArgs e)
        {
            FldrWtchTvI.IsEnabled = true;
            rbFldrWtchDNC.IsEnabled = false;
            rbFldrWtchTCP.IsEnabled = false;
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            string machLvl = "SELECT COUNT(machineLevel) as machlvl FROM MACHINE WHERE machineLevel = '1'";
            SqlCommand cmd3 = new SqlCommand(machLvl, sqlCon);
            var dr3 = cmd3.ExecuteReader();
            dr3.Read();
            lblAvMach.Content = "Unlimited";
            lblUsMach.Content = dr3["machlvl"].ToString();
            sqlCon.Close();
            dr3.Close();
            FldrWtchTvI.IsEnabled = true;
            CbxFldrWtch.IsEnabled = true;
            CbxFldrWtch.IsChecked = false;
        }

        private void rbMachLvl2_Checked(object sender, RoutedEventArgs e)
        {
            rbFldrWtchDNC.IsEnabled = false;
            rbFldrWtchTCP.IsEnabled = false;
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            string machLvl = "SELECT COUNT(machineLevel) as machlvl FROM MACHINE WHERE machineLevel = '2'";
            SqlCommand cmd3 = new SqlCommand(machLvl, sqlCon);
            var dr3 = cmd3.ExecuteReader();
            dr3.Read();
            lblAvMach.Content = MACHLEVEL2 - int.Parse(dr3["machlvl"].ToString());
            lblUsMach.Content = dr3["machlvl"].ToString();
            sqlCon.Close();
            dr3.Close();
            FldrWtchTvI.IsEnabled = true;
            CbxFldrWtch.IsEnabled = true;
            CbxFldrWtch.IsChecked = false;
        }
        private void rbMachLvl3_Checked(object sender, RoutedEventArgs e)
        {
            rbFldrWtchDNC.IsEnabled = true;
            rbFldrWtchTCP.IsEnabled = true;
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            string machLvl = "SELECT COUNT(machineLevel) as machlvl FROM MACHINE WHERE machineLevel = '3'";
            SqlCommand cmd3 = new SqlCommand(machLvl, sqlCon);
            var dr3 = cmd3.ExecuteReader();
            dr3.Read();
            lblAvMach.Content = MACHLEVEL3 - int.Parse(dr3["machlvl"].ToString());
            lblUsMach.Content = dr3["machlvl"].ToString();
            sqlCon.Close();
            dr3.Close();
            FldrWtchTvI.IsEnabled = true;
            FocasTvI.IsEnabled = true;
            SockTvI.IsEnabled = true;
            CbxFldrWtch.IsEnabled = true;
            CbxFldrWtch.IsChecked = false;
            CbxFocas.IsEnabled = true;
            CbxFocas.IsChecked = false;
            CbxSocket.IsEnabled = true;
            CbxSocket.IsChecked = false;
        }

        //socket settings function

        //private void sockStaticOpt_Checked(object sender, RoutedEventArgs e)
        //{
        //    NportChkBxs.IsEnabled = false;
        //    showDNCGrid.IsEnabled = false;
        //    showBarReqGrid.IsEnabled = false;
        //}
        //private void sockDynamicOpt_Checked(object sender, RoutedEventArgs e)
        //{
        //    NportChkBxs.IsEnabled = false;
        //    showDNCGrid.IsEnabled = false;
        //    showBarReqGrid.IsEnabled = false;
        //}
        //private void sockNportOpt_Checked(object sender, RoutedEventArgs e)
        //{
        //    NportChkBxs.IsEnabled = true;
        //    showDNCGrid.IsEnabled = true;
        //    showBarReqGrid.IsEnabled = true;
        //}

        //private void CbxDNC_Checked(object sender, RoutedEventArgs e)
        //{
        //    showDNCGrid.Visibility = Visibility.Visible;
        //}

        //private void CbxDNC_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    showDNCGrid.Visibility = Visibility.Collapsed;
        //}

        //private void CbxBarcodeRequest_Checked(object sender, RoutedEventArgs e)
        //{
        //    showBarReqGrid.Visibility = Visibility.Visible;
        //}

        //private void CbxBarcodeRequest_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    showBarReqGrid.Visibility = Visibility.Collapsed;
        //}

        private void CbxSocket_Checked(object sender, RoutedEventArgs e)
        {
            Socket.IsEnabled = true;
        }

        private void CbxSocket_Unchecked(object sender, RoutedEventArgs e)
        {
            Socket.IsEnabled = false;
            if (chkBxSockComOutFldrWtch.IsChecked == true)
            {
                chkBxSockComOutFldrWtch.IsChecked = false;
                SockTvI.Visibility = Visibility.Visible;
            }
            if (chkBxSockComOutFocas.IsChecked == true)
            {
                chkBxSockComOutFocas.IsChecked = false;
                FocasTvI.Visibility = Visibility.Visible;
            }
        }

        private void chkBxSockComOutFldrWtch_Checked(object sender, RoutedEventArgs e)
        {
            SockComOutFldrWtchStckPnl.Visibility = Visibility.Visible;
            FldrWtchTvI.IsEnabled = false;
        }

        private void chkBxSockComOutFldrWtch_Unchecked(object sender, RoutedEventArgs e)
        {
            SockComOutFldrWtchStckPnl.Visibility = Visibility.Collapsed;
            FldrWtchTvI.IsEnabled = true;
        }

        private void chkBxSockComOutFocas_Checked(object sender, RoutedEventArgs e)
        {
            SockComOutFocasStckPnl.Visibility = Visibility.Visible;
            FocasTvI.IsEnabled = false;
        }

        private void chkBxSockComOutFocas_Unchecked(object sender, RoutedEventArgs e)
        {
            SockComOutFocasStckPnl.Visibility = Visibility.Collapsed;
            FocasTvI.IsEnabled = true;
        }

        private void BtnGetIP_Click(object sender, RoutedEventArgs e)
        {
            // Getting host name
            string host = TxtBxDevNm.Text;

            // Getting ip address using host name
            IPHostEntry ip = Dns.GetHostByName(host);
            LblIp.Content = "IP: " + ip.AddressList[0].ToString();
            LblIp.Visibility = Visibility.Visible;
        }
        private void fldrWatchMoveToIFM_Click(object sender, RoutedEventArgs e)
        {
            SockDncStckPnl.Visibility = Visibility.Collapsed;
            SockTCPDckPnl.Visibility = Visibility.Collapsed;
            txtInfo.Text = "When a new file is detected in the selected Watch Folder, move it to the Fusion Incoming File Manager.";
        }

        private void fldrWatchDNCLink_Checked(object sender, RoutedEventArgs e)
        {
            SockDncStckPnl.Visibility = Visibility.Visible;
            SockTCPDckPnl.Visibility = Visibility.Collapsed;
            txtInfo.Text = "When a new file is detected in the selected Watch Folder. Fusion processes it using the Fusion DNC Link methods.For details, please see the help section on DNC Link and Mapped Drives.";
        }

        private void fldrWatchTCP_Checked(object sender, RoutedEventArgs e)
        {
            SockDncStckPnl.Visibility = Visibility.Collapsed;
            SockTCPDckPnl.Visibility = Visibility.Visible;
            txtInfo.Text = "When a new file is detected in the selected Watch Folder, move it via TCP client to the following Server Port and IP Address.";
        }

        private void SockFldrWtchHstNm_Click(object sender, RoutedEventArgs e)
        {
            SockHstNmFldrWtchStckPnl.Visibility = Visibility.Visible;
            SockIpAddFldrWtchStckPnl.Visibility = Visibility.Collapsed;
        }

        private void SockFldrWtchIP_Checked(object sender, RoutedEventArgs e)
        {
            SockHstNmFldrWtchStckPnl.Visibility = Visibility.Collapsed;
            SockIpAddFldrWtchStckPnl.Visibility = Visibility.Visible;
        }
        private void TxtBxSockPortFoc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void TxtBxSockSndDelFoc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }


        //Modify Filename and Extension - Operator Messages
        private void BtnModifyFnameExt_Click(object sender, RoutedEventArgs e)
        {
            //modifyFnameExtGrid.Visibility = Visibility.Visible;
        }

        private void BtnOkChangeFnameExt_Click(object sender, RoutedEventArgs e)
        {
            //modifyFnameExtGrid.Visibility = Visibility.Collapsed;
        }

        private void BtnUndoChangeFnameExt_Click(object sender, RoutedEventArgs e)
        {
            TxtBxDefMesExt.Text = "txt";
            TxtBoxRemReqLkUpNtFnd.Text = "LookUpFailed";
            TxtBoxRemReqFailed.Text = "InvalidRemoteRequest";
            TxtBoxRemReqFileLock.Text = "RequestFileLocked";
            TxtBoxRemReqFileNtFnd.Text = "RequestFileNotFound";
            TxtBoxRemReqOnHld.Text = "RequestFileOnHold";
            TxtBoxRemReqFldrNtFnd.Text = "RequestFolderNotFound";
        }


        //Flash DNC
        //private void CbxFlashDNCSendINI_Checked(object sender, RoutedEventArgs e)
        //{
        //    BtnBrowseINIFile.Visibility = Visibility.Visible;
        //    txtINIFname.Visibility = Visibility.Visible;
        //}

        //private void CbxFlashDNCSendINI_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    BtnBrowseINIFile.Visibility = Visibility.Collapsed;
        //    txtINIFname.Visibility = Visibility.Collapsed;
        //}

        //private void BtnBrowseINIFile_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Title = "Browse for INI file";
        //    ofd.Filter = "INI files (*.ini)|*.ini|All files (*.*)|*.*";

        //    if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //    {
        //        txtINIFname.Visibility = Visibility.Visible;
        //        txtINIFname.Text = ofd.FileName;
        //    }
        //}


        //Parsing Rules
        private void rbClsSingCmd_Checked(object sender, RoutedEventArgs e)
        {
            ClsSingCmdGrid.IsEnabled = true;
            ClsSingCmdGrid.Visibility = Visibility.Visible;
            ShrtCutLookupGrid.IsEnabled = false;
            ShrtCutLookupGrid.Visibility = Visibility.Collapsed;
            PartsOpLookUpGrid.IsEnabled = false;
            PartsOpLookUpGrid.Visibility = Visibility.Collapsed;
        }
        private void rbShrtLookup_Click(object sender, RoutedEventArgs e)
        {
            ClsSingCmdGrid.IsEnabled = false;
            ClsSingCmdGrid.Visibility = Visibility.Collapsed;
            ShrtCutLookupGrid.IsEnabled = true;
            ShrtCutLookupGrid.Visibility = Visibility.Visible;
            PartsOpLookUpGrid.IsEnabled = false;
            PartsOpLookUpGrid.Visibility = Visibility.Collapsed;
        }
        private void rbPartsOpLookup_Checked(object sender, RoutedEventArgs e)
        {
            ClsSingCmdGrid.IsEnabled = false;
            ClsSingCmdGrid.Visibility = Visibility.Collapsed;
            ShrtCutLookupGrid.IsEnabled = false;
            ShrtCutLookupGrid.Visibility = Visibility.Collapsed;
            PartsOpLookUpGrid.IsEnabled = true;
            PartsOpLookUpGrid.Visibility = Visibility.Visible;
        }
        private void TxtBxLineNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }
        private void rbFldrReq_Click(object sender, RoutedEventArgs e)
        {
            FldrReqStckPnl.Visibility = Visibility.Visible;
            TxtBxFlReqFlXt.Visibility = Visibility.Collapsed;
            TxtBxFldrReqFlXt.Visibility = Visibility.Visible;
            txtFldrReqWtrMrk.Visibility = Visibility.Visible;
            cbxEnTrans.IsEnabled = false;
            cbxEnTrans.IsChecked = false;
            ShowEnTrnsIcon.Visibility = Visibility.Collapsed;
            EnTransStckPnl.Visibility = Visibility.Collapsed;
        }

        private void rbFlReq_Click(object sender, RoutedEventArgs e)
        {
            FldrReqStckPnl.Visibility = Visibility.Collapsed;
            TxtBxFlReqFlXt.Visibility = Visibility.Visible;
            TxtBxFldrReqFlXt.Visibility = Visibility.Collapsed;
            txtFldrReqWtrMrk.Visibility = Visibility.Collapsed;
            cbxEnTrans.IsEnabled = true;
        }

        private void BtnCloseEnTrans_Click(object sender, RoutedEventArgs e)
        {
            EnTransStckPnl.Visibility = Visibility.Collapsed;
        }

        private void cbxEnTrans_Checked(object sender, RoutedEventArgs e)
        {
            ShowEnTrnsIcon.Visibility = Visibility.Visible;
            EnTransStckPnl.Visibility = Visibility.Visible;
        }

        private void cbxEnTrans_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowEnTrnsIcon.Visibility = Visibility.Collapsed;
            EnTransStckPnl.Visibility = Visibility.Collapsed;
        }
        private void ShowEnTrnsIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            EnTransStckPnl.Visibility = Visibility.Visible;
        }


        //Focas
        private void cbxFocasEnFldrWatch_Checked(object sender, RoutedEventArgs e)
        {
            BtnFocasFldrWtch.IsEnabled = true;
        }

        private void cbxFocasEnFldrWatch_Unchecked_1(object sender, RoutedEventArgs e)
        {
            BtnFocasFldrWtch.IsEnabled = false;
            TxtBoxFocasfldrWatch.Clear();
        }

        private void BtnFocasFldrWtch_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.Description = "Please select a folder destination. When a new file is detected in the selected Watch Folder, Fusion processes it using the Fusion DNC Link methods.";
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtBoxFocasfldrWatch.Text = diag.SelectedPath;
            }
        }
        private void TxtBxFocSttcAdd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }
        private void chkbxFOptHostname_Checked(object sender, RoutedEventArgs e)
        {
            TxtBxFocSttcAdd.PreviewTextInput -= TxtBxFocSttcAdd_PreviewTextInput;
            TxtBxFocSttcAdd.Clear();
        }

        private void chkbxFOptHostname_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtBxFocSttcAdd.PreviewTextInput += TxtBxFocSttcAdd_PreviewTextInput;
            TxtBxFocSttcAdd.Clear();
        }
        private void TxtBxFocPort_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void TxtBxFocSndDly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }


        //Folder Watch
        private void BtnFldrWtchFolderDes_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.Description = "Please select a folder destination.";
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtSelFldrDes.Text = diag.SelectedPath;
                string[] files = System.IO.Directory.GetFiles(diag.SelectedPath);
                string[] subdirectoryEntries = Directory.GetDirectories(diag.SelectedPath);
                if (files.Length != 0 || subdirectoryEntries.Length != 0)
                {
                    txtFolder.Text = txtSelFldrDes.Text;
                    FolderInfoGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    TxtBoxFldrWtchFldrDes.Text = diag.SelectedPath;
                }
            }
        }
        private void CbxFldrWtch_Checked(object sender, RoutedEventArgs e)
        {
            FldrWtch.IsEnabled = true;
        }

        private void CbxFldrWtch_Unchecked(object sender, RoutedEventArgs e)
        {
            FldrWtch.IsEnabled = false;
            if (chkBFldrWtchComOut.IsChecked == true)
            {
                chkBFldrWtchComOut.IsChecked = false;
                SockTvI.Visibility = Visibility.Visible;
            }
            if (cbxFldrWtchComOutFoc.IsChecked == true)
            {
                cbxFldrWtchComOutFoc.IsChecked = false;
                FocasTvI.Visibility = Visibility.Visible;
            }
            //TxtBoxFldrWtchFldrDes.Clear();
        }
        private void chkBFldrWtchComOut_Checked(object sender, RoutedEventArgs e)
        {
            FldrWtchComOutStckPnl.Visibility = Visibility.Visible;
            SockTvI.IsEnabled = false;
        }

        private void chkBFldrWtchComOut_Unchecked(object sender, RoutedEventArgs e)
        {
            FldrWtchComOutStckPnl.Visibility = Visibility.Collapsed;
            SockTvI.IsEnabled = true;
        }

        private void cbxFldrWtchComOutFoc_Checked(object sender, RoutedEventArgs e)
        {
            FldrWtchComOutFocasStckPnl.Visibility = Visibility.Visible;
            FocasTvI.IsEnabled = false;
        }

        private void cbxFldrWtchComOutFoc_Unchecked(object sender, RoutedEventArgs e)
        {
            FldrWtchComOutFocasStckPnl.Visibility = Visibility.Collapsed;
            FocasTvI.IsEnabled = true;
        }

        private void rbFldrWtchDNC_Checked(object sender, RoutedEventArgs e)
        {
            FldrWtchDNCLnkStckPnl.Visibility = Visibility.Visible;
            TcpTrnsfrStckPnl.Visibility = Visibility.Collapsed;
            txtInst.Text = "When a new file is detected in the selected Watch Folder. Fusion processes it using the Fusion DNC Link methods. For details, please see the help section on DNC Link and Mapped Drives.";
        }

        private void rbFldrWthcMvInFile_Click(object sender, RoutedEventArgs e)
        {
            FldrWtchDNCLnkStckPnl.Visibility = Visibility.Collapsed;
            TcpTrnsfrStckPnl.Visibility = Visibility.Collapsed;
            txtInst.Text = "When a new file is detected in the selected Watch Folder, move it to the Fusion Incoming File Manager.";
        }
        private void rbFldrWthcMvInFile_Checked(object sender, RoutedEventArgs e)
        {
            FldrWtchDNCLnkStckPnl.Visibility = Visibility.Collapsed;
            TcpTrnsfrStckPnl.Visibility = Visibility.Collapsed;
            txtInst.Text = "When a new file is detected in the selected Watch Folder, move it to the Fusion Incoming File Manager.";
        }
        private void rbFldrWtchTCP_Checked(object sender, RoutedEventArgs e)
        {
            FldrWtchDNCLnkStckPnl.Visibility = Visibility.Collapsed;
            TcpTrnsfrStckPnl.Visibility = Visibility.Visible;
            txtInst.Text = "When a new file is detected in the selected Watch Folder, move it via TCP client to the following Server Port and IP Address.";
        }

        private void cbxDNCUseDesFldr_Checked(object sender, RoutedEventArgs e)
        {
            TxtBxDesFldr.IsReadOnly = false;
            BtnBrwsDesFldr.IsEnabled = true;
        }
        
        private void cbxDNCUseDesFldr_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtBxDesFldr.IsReadOnly = true;
            TxtBxDesFldr.Clear();
            BtnBrwsDesFldr.IsEnabled = false;
        }

        private void rbHstNm_Click(object sender, RoutedEventArgs e)
        {
            FldrWtchHstNmStckPnl.Visibility = Visibility.Visible;
            FldrWtchIpAddStckPnl.Visibility = Visibility.Collapsed;
        }

        private void rbIpAdd_Click(object sender, RoutedEventArgs e)
        {
            FldrWtchHstNmStckPnl.Visibility = Visibility.Collapsed;
            FldrWtchIpAddStckPnl.Visibility = Visibility.Visible;
        }
        private void TxtBoxComOutFocFldrWtch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void TxtBxFldrWtchSndDelFoc_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }
        private void TxtBxPrtFW_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void TxtBxIpFW_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void TxtBoxIpAddIpFW_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }
        private void FldWIP1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void FldWIP2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void FldWIP3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void FldWIP4_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void ClrIp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FldWIP1.Clear();
            FldWIP2.Clear();
            FldWIP3.Clear();
            FldWIP4.Clear();
        }

        private void BtnBrwsDesFldr_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.Description = "Please select a destination folder for the folder watch processed file.";
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //TxtBxDesFldr.Text = diag.SelectedPath;
                
            }
        }
        private void BtnCancelFldrInfo_Click(object sender, RoutedEventArgs e)
        {
            FolderInfoGrid.Visibility = Visibility.Collapsed;
        }

        private void BtnOkFldrInfo_Click(object sender, RoutedEventArgs e)
        {
            if (rbNo.IsChecked == true)
            {
                FolderInfoGrid.Visibility = Visibility.Collapsed;
                MessageBox.Show("Please remove files and subfolders in your selected Folder.\nOpening specified folder ....", "Fusion PDO - Machine Manager", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(rbYes.IsChecked == true)
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(txtSelFldrDes.Text);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                FolderInfoGrid.Visibility = Visibility.Collapsed;
                MessageBox.Show("Successfully deleted all files and subfolders. You may now use this folder as your watch folder.", "Fusion PDO - Machine Manager", MessageBoxButton.OK, MessageBoxImage.Information);
                TxtBoxFldrWtchFldrDes.Text = txtSelFldrDes.Text;
            }
        }


        //Remote Request
        private void TxtBoxMxFlSze_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void TxtBxMxLnCnt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void TxtBxPerRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }
        private void CbxRedirInFile_Checked(object sender, RoutedEventArgs e)
        {
            IFMStackPanel.IsEnabled = true;
            //rbUseOgName.IsChecked = true;
        }

        private void CbxRedirInFile_Unchecked(object sender, RoutedEventArgs e)
        {
            IFMStackPanel.IsEnabled = false;
            //rbUseOgName.IsChecked = false;
        }
        private void cbxRemReqPgrmNm_Checked(object sender, RoutedEventArgs e)
        {
            TxtBxPgrmNm.IsEnabled = true;
        }

        private void cbxRemReqPgrmNm_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtBxPgrmNm.IsEnabled = false;
        }

        //IFM
        private void rbUseFileNm_Checked(object sender, RoutedEventArgs e)
        {
            CrInFileStckPnl.IsEnabled = false;
        }

        private void rbAssFileNm_Checked(object sender, RoutedEventArgs e)
        {
            CrInFileStckPnl.IsEnabled = false;
        }
        private void rbCrtInFile_Checked(object sender, RoutedEventArgs e)
        {
            CrInFileStckPnl.IsEnabled = true;
        }

        //nport
        private void CbxNport_Checked(object sender, RoutedEventArgs e)
        {
            Nport.IsEnabled = true;
        }

        private void CbxNport_Unchecked(object sender, RoutedEventArgs e)
        {
            Nport.IsEnabled = false;
        }
        private void rbDNC_Checked(object sender, RoutedEventArgs e)
        {
            DNCDckPnl.IsEnabled = true;
            BrCodeDckPnl.IsEnabled = false;
        }

        private void rbBrCode_Checked(object sender, RoutedEventArgs e)
        {
            DNCDckPnl.IsEnabled = false;
            BrCodeDckPnl.IsEnabled = true;
        }
        private void TxtBxDncPort_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        private void TxtBxBrCodeReq_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }
        private void TxtBxTrnsmtDly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }
        private void TxtBxNprtPort_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"[0-9]");
        }

        //ftp
        private void CbxFTP_Checked(object sender, RoutedEventArgs e)
        {
            FTP.IsEnabled = true;
        }

        private void CbxFTP_Unchecked(object sender, RoutedEventArgs e)
        {
            FTP.IsEnabled = false;
        }



        //APPLY TO MACHINE - Operator Messages
        //public class ApplyToMachine
        //{
        //    public int machId { get; set; }
        //    public string machName { get; set; }

        //    public bool isChecked { get; set; }

        //}
        public class ApplyToMachine : INotifyPropertyChanged
        {
            private string _machName;
            private int _machId;
            private bool _isChecked;

            public string machName
            {
                get { return _machName; }
                set { _machName = value; NotifyPropertyChanged(); }
            }

            public int machId
            {
                get { return _machId; }
                set { _machId = value; NotifyPropertyChanged(); }
            }

            public bool isChecked
            {
                get { return _isChecked; }
                set { _isChecked = value; NotifyPropertyChanged(); }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(string propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }

        }

        IList<ApplyToMachine> apptomach = new List<ApplyToMachine>();

        public void ApplyToMach()
        {
            ApplyToMachListBox.ItemsSource = null;
            apptomach = new List<ApplyToMachine>();
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                string mach_query = "SELECT * FROM MACHINE ORDER BY machine_name";
                SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "MACHINE");

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    apptomach.Add(new ApplyToMachine()
                    {
                        machId = int.Parse(dr["machine_id"].ToString()),
                        machName = dr["machine_name"].ToString(),
                        isChecked = false
                    });
                }

                ApplyToMachListBox.ItemsSource = apptomach;

                da.Dispose();
                ds.Dispose();
                sqlCon.Close();

            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        private void BtnApplyToMach_Click(object sender, RoutedEventArgs e)
        {
            //ApplyToMachGrid.Visibility = Visibility.Visible;
            ApplyToMach();
        }

        private void BtnOpMessCancelApplyToMach_Click(object sender, RoutedEventArgs e)
        {
            //ApplyToMachGrid.Visibility = Visibility.Collapsed;
        }
    
        private void cbxSelAll_Checked(object sender, RoutedEventArgs e)
        {
            cbxDeselAll.IsChecked = false;
            //ApplyToMachListBox.SelectAll();
            foreach (var a in apptomach)
            {
                a.isChecked = true;
                //MessageBox.Show(a.machId.ToString());
            }
            
        }

        private void cbxDeselAll_Checked(object sender, RoutedEventArgs e)
        {
            cbxSelAll.IsChecked = false;
            //ApplyToMachListBox.UnselectAll();
            foreach (var a in apptomach)
            {
                a.isChecked = false;
            }
        }

        //for testing only
        private void BtnOpMessApplyToMach_Click(object sender, RoutedEventArgs e)
        {
            string id = "";
            string machname = "";
            foreach (var a in apptomach)
            {
                if (a.isChecked == true)
                {
                    //MessageBox.Show(a.machId.ToString() + a.machName + a.isChecked);
                    id += a.machId.ToString();
                    machname += a.machName;
                }
            }
            MessageBox.Show(id + machname);
        }

        //DUPLICATE RENAME MACHINE

        private void btnDuplicate_Click(object sender, RoutedEventArgs e)
        {
            DupRenMachQuery();
        }
        private void BtnDupRenMachCancel_Click(object sender, RoutedEventArgs e)
        {
            DuplicateRenameGrid.Visibility = Visibility.Collapsed;
        }

        public void DupRenMachQuery()
        {
            DuplicateRenameGrid.Visibility = Visibility.Visible;
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                string mach_query = "SELECT * FROM MACHINE WHERE machine_id = '"+ selMachID.Text + "'";
                SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string selMachName = reader["machine_name"].ToString();
                        string selMachLvl = reader["machineLevel"].ToString();

                        lblDupRenMachName.Content = selMachName;
                        lblDupRenMachLvl.Content = selMachLvl;
                    }
                }
                reader.Close();
                sqlCon.Close();

            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        private void rbDupRenUseHstNm_Checked(object sender, RoutedEventArgs e)
        {
            HstNmStckPnl.Visibility = Visibility.Visible;
            StaticIpStckPnl.Visibility = Visibility.Collapsed;
        }

        private void rbDupRenUseSttcIp_Checked(object sender, RoutedEventArgs e)
        {
            HstNmStckPnl.Visibility = Visibility.Collapsed;
            StaticIpStckPnl.Visibility = Visibility.Visible;
        }//


        #region Personnel
        public class Personnel
        {
            public int pid { get; set; }
            public string pname { get; set; }
        }
        List<Personnel> prsnl = new List<Personnel>();

        public void LoadPersonnel()
        {
            LstBxPrsnl.ItemsSource = null;
            try
            {
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                string mach_query = "SELECT * FROM Users ORDER BY Username";
                SqlCommand cmd = new SqlCommand(mach_query, sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Users");

                prsnl = new List<Personnel>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    prsnl.Add(new Personnel()
                    {
                        pid = int.Parse(dr["ID"].ToString()),
                        pname = dr["Username"].ToString()
                    });
                }
                LstBxPrsnl.ItemsSource = prsnl;

                da.Dispose();
                ds.Dispose();
                sqlCon.Close();
            }
            catch(Exception ex) { ex.Message.ToString(); }
        }
        //private void CheckBox_Click(object sender, RoutedEventArgs e)
        //{

        //}
        private void BtnSavePrsnl_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < LstBxPrsnl.Items.Count; i++)
            {
                MessageBox.Show(LstBxPrsnl.Items[i].ToString());

            }
        }





        #endregion

        
    }
}
