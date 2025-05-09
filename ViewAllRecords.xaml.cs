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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPE106_FOPI01_RAYNES_MOD3_EXAM
{
    /// <summary>
    /// Interaction logic for ViewAllRecords.xaml
    /// </summary>
    public partial class ViewAllRecords : Page
    {
        DataClasses1DataContext dc = new DataClasses1DataContext(
            Properties.Settings.Default.StudentMaintenanceConnectionString);
        public ViewAllRecords()
        {
            InitializeComponent();

            string connectionStr = "Data Source = BEEPBOOPMACHINE\\SQL2022_SCHOOL; Initial Catalog =  StudentMaintenance; Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connectionStr);

            SqlCommand cmd  = new SqlCommand("EXEC spViewAllRecords;", conn);
            conn.Open();
            
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            dtGrid.DataContext = dt;

        }
    }
}
