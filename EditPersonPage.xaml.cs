using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace CPE106_FOPI01_RAYNES_MOD3_EXAM
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : Page
    {
        public EditPersonPage()
        {
            InitializeComponent();
        }

        private void CheckBttn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPersonID.Text))
            {
                MessageBox.Show("Please fill out Student ID field!");
                return;
            }


            string connectionStr = "Data Source = BEEPBOOPMACHINE\\SQL2022_SCHOOL; Initial Catalog =  StudentMaintenance; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spViewPerson", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@personID_toView", SqlDbType.Int).Value = Convert.ToInt32(TBPersonID.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            dt.Clear();

            adapter.Fill(dt);
            checkDtGrid.DataContext = dt;
            conn.Close();
        }

        private void AddEntryBttn_Click(object sender, RoutedEventArgs e)
        {
            //Field Checks
            if (string.IsNullOrEmpty(TBPersonID.Text))
            {
                MessageBox.Show("Missing Person ID Field!");
                return;
            }
            int PersonID = Convert.ToInt32(TBPersonID.Text);
            if (string.IsNullOrEmpty(TBFirstName.Text))
            {
                MessageBox.Show("Missing First Name Field!");
                return;
            }

            if (string.IsNullOrEmpty(TBLastName.Text))
            {
                MessageBox.Show("Missing Last Name Field!");
                return;
            }

            string connectionStr = "Data Source = BEEPBOOPMACHINE\\SQL2022_SCHOOL; Initial Catalog =  StudentMaintenance; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();

            SqlCommand sql_cmnd = new SqlCommand("spEditPerson", conn);
            sql_cmnd.CommandType = CommandType.StoredProcedure;
            sql_cmnd.Parameters.AddWithValue("@personID_toEdit", SqlDbType.Int).Value = PersonID;
            sql_cmnd.Parameters.AddWithValue("@inpLastName", SqlDbType.NVarChar).Value = TBLastName.Text;


            sql_cmnd.Parameters.AddWithValue("@inpGivenName", SqlDbType.NVarChar).Value = TBFirstName.Text;


            sql_cmnd.Parameters.AddWithValue("@inpMiddleName", SqlDbType.NVarChar).Value = TBMiddleName.Text;

            try { sql_cmnd.ExecuteNonQuery(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            conn.Close();

            hiddenTextBlock.Text = "Successfully edited entry!";
        }
    }
}
