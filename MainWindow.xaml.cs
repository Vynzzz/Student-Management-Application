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

namespace CPE106_FOPI01_RAYNES_MOD3_EXAM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext(
            Properties.Settings.Default.StudentMaintenanceConnectionString);
        public MainWindow()
        {
            InitializeComponent();

        }

        private void PersonClick(object sender, RoutedEventArgs e)
        {
            SmallFrame.Content = new PersonMenu();
            BigFrame.Content = null;
        }

        private void StudentMenuBttn_Click(object sender, RoutedEventArgs e)
        {
            SmallFrame.Content = new StudentMenu();
            BigFrame.Content = null;
        }

        private void AllRecordsBttn_Click(object sender, RoutedEventArgs e)
        {
            BigFrame.Content = new ViewAllRecords();
            SmallFrame.Content = null;
        }

        private void ExitBttn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void SpecificRecordBttn_Click(object sender, RoutedEventArgs e)
        {
            SmallFrame.Content = null;
            BigFrame.Content = new ViewSpecificRecordPage();
        }
    }
}
