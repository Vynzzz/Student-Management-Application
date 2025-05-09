using System;
using System.Collections.Generic;
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
    /// Interaction logic for PersonMenu.xaml
    /// </summary>
    public partial class PersonMenu : Page
    {
        public PersonMenu()
        {
            InitializeComponent();
        }

        private void AddPersonBttn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = (MainWindow)Window.GetWindow(this);

            objMainWindow.BigFrame.Content = new AddPersonPage();
        }

        private void EditPersonBttn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = (MainWindow)Window.GetWindow(this);

            objMainWindow.BigFrame.Content = new EditPersonPage();
        }

        private void DeletePersonBttn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = (MainWindow)Window.GetWindow(this);

            objMainWindow.BigFrame.Content = new DeletePersonPage();
        }
    }
}
