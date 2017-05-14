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

namespace MainWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PersonsCRUD crud;

        List<Person> personlist;

        public MainWindow()
        {
            InitializeComponent();

            crud = new PersonsCRUD();

            personlist = new List<Person>();
        }

        private void Get_All_PersonBt_Click(object sender, RoutedEventArgs e)
        {
            MyGrid.ItemsSource = null;

            personlist = crud.GetAllPersons();
            MyGrid.ItemsSource = personlist;
        }
    }
}
