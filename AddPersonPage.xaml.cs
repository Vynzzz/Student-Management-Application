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
    /// Interaction logic for AddPersonPage.xaml
    /// </summary>
    public partial class AddPersonPage : Page
    {
        public AddPersonPage()
        {
            InitializeComponent();
        }

        private void AddEntryBttn_Click(object sender, RoutedEventArgs e)
        {
            //Field Checks
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

            SqlCommand sql_cmnd = new SqlCommand("spAddPerson", conn);
            sql_cmnd.CommandType = CommandType.StoredProcedure;
            sql_cmnd.Parameters.AddWithValue("@inpLastName", SqlDbType.NVarChar).Value = TBLastName.Text;
            sql_cmnd.Parameters.AddWithValue("@inpGivenName", SqlDbType.NVarChar).Value = TBFirstName.Text;
            sql_cmnd.Parameters.AddWithValue("@inpMiddleName", SqlDbType.NVarChar).Value = TBMiddleName.Text;

            try { sql_cmnd.ExecuteNonQuery();}
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
                return;
            }
            

            conn.Close();

            hiddenTextBlock.Text = "Successfully added entry!";
        }
    }
}
