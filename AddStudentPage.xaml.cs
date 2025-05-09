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

namespace CPE106_FOPI01_RAYNES_MOD3_EXAM
{
    /// <summary>
    /// Interaction logic for AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        public AddStudentPage()
        {
            InitializeComponent();
        }

        private void AddEntryBttn_Click(object sender, RoutedEventArgs e)
        {
            //Field Checks
            if (string.IsNullOrEmpty(TBStudentNum.Text))
            {
                MessageBox.Show("Missing Student Number Field!");
                return;
            }

            if (string.IsNullOrEmpty(TBYear.Text))
            {
                MessageBox.Show("Missing Year Field!");
                return;
            }

            if (string.IsNullOrEmpty(TBProgramID.Text))
            {
                MessageBox.Show("Missing Program ID Field!");
                return;
            }
            
            if (string.IsNullOrEmpty(TBPersonID.Text))
            {
                MessageBox.Show("Missing Person ID Field!");
                return;
            }
            int PersonID = Convert.ToInt32(TBPersonID.Text);
            

            string connectionStr = "Data Source = BEEPBOOPMACHINE\\SQL2022_SCHOOL; Initial Catalog =  StudentMaintenance; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();

            SqlCommand sql_cmnd = new SqlCommand("spAddStudent", conn);
            sql_cmnd.CommandType = CommandType.StoredProcedure;
            sql_cmnd.Parameters.AddWithValue("@personID_toAddTo", SqlDbType.Int).Value = PersonID;
            sql_cmnd.Parameters.AddWithValue("@inpStudentNum", SqlDbType.NChar).Value = TBStudentNum.Text;
            sql_cmnd.Parameters.AddWithValue("@inpProgramID", SqlDbType.SmallInt).Value = Convert.ToInt16(TBProgramID.Text);
            sql_cmnd.Parameters.AddWithValue("@inpYear", SqlDbType.TinyInt).Value = Convert.ToByte(TBYear.Text);

            sql_cmnd.ExecuteNonQuery();

            conn.Close();
       
            hiddenTextBlock.Text = "Successfully added entry!";
      
        }
    }
}
