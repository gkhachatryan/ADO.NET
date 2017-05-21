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

namespace PersonManipulatorEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities crud;

        List<Person> personlist;

        public MainWindow()
        {
            InitializeComponent();

            crud = new Entities();

            personlist = new List<Person>();
        }

        private void Get_All_PersonBt_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
