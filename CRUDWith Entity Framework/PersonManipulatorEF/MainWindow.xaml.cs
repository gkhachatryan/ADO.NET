using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading;
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
            RefreshPersonsList();
        }

        private async void Get_By_IdBt_Click(object sender, RoutedEventArgs e)
        {
            string text = GetIDTxBox.Text;
           
            if (!string.IsNullOrEmpty(text) && text.All(char.IsDigit))
            {
              
                int id = int.Parse(text);
              
                personlist = null;
               
                personlist = await crud.People.Where(p => p.Id == id).ToListAsync();
              
                MyGrid.ItemsSource = personlist;
               
                if (personlist.Count == 0)
                {
                    MessageBox.Show("No person with Id" + text);
                }
            }
        }

        private async void AddNewBt_Click(object sender, RoutedEventArgs e)
        {
            crud.People.Add(new Person
            {
                FName = FNameTxBox.Text,
               
                LName = LNametxtBox.Text,
               
                Phone = int.Parse(PhonetxBox.Text)
            });

            try
            {
                await crud.SaveChangesAsync();
              
                MessageBox.Show("New Person added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RefreshPersonsList();
        }

        private void UpdateBt_Click(object sender, RoutedEventArgs e)
        {
            if (MyGrid.SelectedItems.Count != 1) return;

            var id = personlist[MyGrid.SelectedIndex].Id;
           
            var person = crud.People.Find(id);

            if (person == null) return;

            person.FName = FNameTxBox.Text;
           
            person.LName = LNametxtBox.Text;
           
            person.Phone = int.Parse(PhonetxBox.Text);

            crud.People.AddOrUpdate(person);
           
            crud.SaveChanges();

            RefreshPersonsList();
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            if (MyGrid.SelectedItems.Count != 1) return;

            var id = personlist[MyGrid.SelectedIndex].Id;
           
            var person = crud.People.Find(id);

            crud.People.Remove(person);

            crud.SaveChanges();
           
            RefreshPersonsList();

        }

        private async void RefreshPersonsList()
        {
            MyGrid.ItemsSource = null;
           
            personlist = await crud.People.ToListAsync();
           
            MyGrid.ItemsSource = personlist;
        }
    }
}
