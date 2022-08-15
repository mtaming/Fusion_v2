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
    /// Interaction logic for CustManager.xaml
    /// </summary>
    public partial class CustManager : Page
    {
        public CustManager()
        {
            InitializeComponent();
            custQuery();
        }

        public int dgSel;
        public class Customers
        {
            public int custid { get; set; }
            public string custname { get; set; }
        }

        List<Customers> customersData = new List<Customers>();

        private void custQuery()
        {
            try
            {
                cusManDataGrid.ItemsSource = null;
                customersData = new List<Customers>();
                SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                sqlCon.Open();
                String query = "SELECT * FROM CUSTOMERS ORDER BY Customer_Name";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                var dr = sqlCmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = int.Parse(dr["Customer_ID"].ToString());
                    string oname = dr["Customer_Name"].ToString();
                    customersData.Add(new Customers() { custid = id, custname = oname });
                }
                dr.Close();
                cusManDataGrid.ItemsSource = customersData;
                cusManDataGrid.SelectedIndex = 0;

                String query1 = "SELECT MAX(customer_id) FROM CUSTOMERS";
                SqlCommand sqlCmd1 = new SqlCommand(query1, sqlCon);
                int max = (int)sqlCmd1.ExecuteScalar();
                cusManMaxId.Content = max;

                sqlCon.Close();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void cusManDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            try
            {
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                {
                    var cuslist = cusManDataGrid.SelectedItem as Customers;
                    string id = cuslist.custid.ToString();
                    dgSel = int.Parse(id.ToString());

                    String query = "SELECT customer_id, customer_name, note FROM CUSTOMERS WHERE customer_id = '" + dgSel + "' ";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    SqlDataReader dr = sqlCmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            int cid = int.Parse(dr["customer_id"].ToString());
                            string nm = dr["customer_name"].ToString();
                            string note = dr["note"].ToString();

                            cusManHiddenId.Content = cid;
                            cusManHiddenNm.Content = nm;
                            cusManHiddenNte.Content = note;

                            cusManName.Text = nm;
                            cusManNote.Text = note;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            sqlCon.Close();
        }

        private void BtnAddCust_Click(object sender, RoutedEventArgs e)
        {
            addCustomerDock.Visibility = Visibility.Visible;
            EditCustomerDock.Visibility = Visibility.Hidden;
            cusManName.IsReadOnly = false;
            cusManName.Focus();
            //cusManNote.IsReadOnly = false;
            cusManName.Text = "";
            cusManNote.Text = "";


        }

        private void BtnCancelAdd_Click(object sender, RoutedEventArgs e)
        {
            custQuery();
            cusManName.IsReadOnly = true;
            cusManNote.IsReadOnly = true;
            addCustomerDock.Visibility = Visibility.Hidden;
        }

        private void cusManName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cusManName.Text == "")
            {
                cusManNote.IsReadOnly = true;
                BtnSaveAdd.IsEnabled = false;
            }
            else
            {
                cusManNote.IsReadOnly = false;
                BtnSaveAdd.IsEnabled = true;
            }
        }

        private void BtnSaveAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            String query = "INSERT INTO CUSTOMERS (customer_id, customer_name, note) values ('" + ((int)cusManMaxId.Content + 1) + "','" + cusManName.Text + "', '" + cusManNote.Text + "')";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            
            MessageBox.Show(" '" + cusManName.Text + "' was successfully added", "Customer Manager", MessageBoxButton.OK, MessageBoxImage.Information);

            custQuery();
            dgSel = (int)cusManMaxId.Content - 1;
            cusManDataGrid.SelectedIndex = dgSel;
            addCustomerDock.Visibility = Visibility.Hidden;
            BtnSaveAdd.IsEnabled = false;
            cusManName.IsReadOnly = true;
            cusManNote.IsReadOnly = true;
        }

        private void BtnDelCus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure that you want to delete '" + cusManHiddenNm.Content + "' ?", "Customer Manager", MessageBoxButton.YesNo, MessageBoxImage.Warning)==MessageBoxResult.Yes)
                {
                    SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
                    sqlCon.Open();
                    String query = "DELETE from CUSTOMERS WHERE customer_id = '" + cusManHiddenId.Content + "' ";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Selected customer successfully deleted.", "Customer Manager", MessageBoxButton.OK, MessageBoxImage.Information);
                    sqlCon.Close();

                    custQuery();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void BtnEditCus_Click(object sender, RoutedEventArgs e)
        {
            EditCustomerDock.Visibility = Visibility.Visible;
            addCustomerDock.Visibility = Visibility.Hidden;
            cusManName.Text = cusManHiddenNm.Content.ToString();
            cusManNote.Text = cusManHiddenNte.Content.ToString();
            cusManName.SelectAll();
            cusManName.IsReadOnly = false;
            cusManNote.IsReadOnly = false;
            cusManName.Focus();
            BtnSaveEdit.IsEnabled = true;
        }

        private void BtnCancelEdit_Click(object sender, RoutedEventArgs e)
        {
            custQuery();
            EditCustomerDock.Visibility = Visibility.Hidden;
            cusManName.IsReadOnly = true;
            cusManNote.IsReadOnly = true;
        }

        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@Properties.Settings.Default.dbConnString);
            sqlCon.Open();
            String query = "UPDATE CUSTOMERS SET customer_name = '" + cusManName.Text + "', note = '" + cusManNote.Text + "' WHERE customer_id = '" + cusManHiddenId.Content + "' ";
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.ExecuteNonQuery();

            custQuery();

            MessageBox.Show("Selected customer successfully updated.", "Customer Manager", MessageBoxButton.OK, MessageBoxImage.Information);

            EditCustomerDock.Visibility = Visibility.Hidden;
            BtnSaveEdit.IsEnabled = false;
            cusManName.IsReadOnly = true;
            cusManNote.IsReadOnly = true;
        }
    }
}
