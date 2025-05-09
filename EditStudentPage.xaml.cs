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
    /// Interaction logic for EditStudentPage.xaml
    /// </summary>
    public partial class EditStudentPage : Page
    {
        public EditStudentPage()
        {
            InitializeComponent();
        }

        private void CheckBttn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(TBStudentID.Text))
            {
                MessageBox.Show("Please fill out Student ID field!");
                return;
            }


            string connectionStr = "Data Source = BEEPBOOPMACHINE\\SQL2022_SCHOOL; Initial Catalog =  StudentMaintenance; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spViewStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@studentID_toView", SqlDbType.Int).Value = Convert.ToInt32(TBStudentID.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            dt.Clear();

            adapter.Fill(dt);
            checkDtGrid.DataContext = dt;
            conn.Close();

           
        }

        private void EditEntryBttn_Click(object sender, RoutedEventArgs e)
        {
            //Field Checks
            if (string.IsNullOrEmpty(TBStudentID.Text))
            {
                MessageBox.Show("Missing Student ID Field!");
                return;
            }
            int StudentID = Convert.ToInt32(TBStudentID.Text);
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

            string connectionStr = "Data Source = BEEPBOOPMACHINE\\SQL2022_SCHOOL; Initial Catalog =  StudentMaintenance; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionStr);
            conn.Open();

            SqlCommand sql_cmnd = new SqlCommand("spEditStudent", conn);
            sql_cmnd.CommandType = CommandType.StoredProcedure;
            sql_cmnd.Parameters.AddWithValue("@studentID_toEdit", SqlDbType.Int).Value = StudentID;
            sql_cmnd.Parameters.AddWithValue("@inpStudentNum", SqlDbType.NChar).Value = TBStudentNum.Text;
            sql_cmnd.Parameters.AddWithValue("@inpProgramID", SqlDbType.SmallInt).Value = Convert.ToInt16(TBProgramID.Text);
            sql_cmnd.Parameters.AddWithValue("@inpYear", SqlDbType.TinyInt).Value = Convert.ToByte(TBYear.Text);

            try { sql_cmnd.ExecuteNonQuery(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); return; }

            conn.Close();

            hiddenTextBlock.Text = "Successfully edited entry!";
        }
    }
}
