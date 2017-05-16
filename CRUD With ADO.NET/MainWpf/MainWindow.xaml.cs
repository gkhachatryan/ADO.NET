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

        private void Get_By_IdBt_Click(object sender, RoutedEventArgs e)
        {
            string text = GetIDTxBox.Text;

            if(!string.IsNullOrEmpty(text) && text.All(char.IsDigit))
            {
                Person person = crud.GetByID(int.Parse(text));

                if (person !=null)
                {
                    MyGrid.ItemsSource = null;

                    personlist.Clear();

                    personlist.Add(person);

                    MyGrid.ItemsSource = personlist;
                }

                else
                {
                    MessageBox.Show("No person with Id" + text);
                }
            }
        }

        private void UpdateBt_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person(personlist[MyGrid.SelectedIndex].Id, FNameTxBox.Text, LNametxtBox.Text, int.Parse(PhonetxBox.Text));

            crud.Update(person);

            MessageBox.Show("Person with Id " + personlist[MyGrid.SelectedIndex].Id + " updated");

            MyGrid.ItemsSource = null;

            personlist = crud.GetAllPersons();

            MyGrid.ItemsSource = personlist;
        }


        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            if( MyGrid.SelectedItem != null)
            {
                crud.Delete(personlist[MyGrid.SelectedIndex].Id);

                MyGrid.ItemsSource = null;

                personlist = crud.GetAllPersons();

                MyGrid.ItemsSource = personlist;
            }
           
            else
            {
                MessageBox.Show("No person with Id " + personlist[MyGrid.SelectedIndex].Id);
            }
        }

        private void AddNewBt_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person( FNameTxBox.Text, LNametxtBox.Text, int.Parse(PhonetxBox.Text));

            crud.Add(person);

             MessageBox.Show("New Person added");

             MyGrid.ItemsSource = null;

             personlist = crud.GetAllPersons();

             MyGrid.ItemsSource = personlist;

        }


    }
}
