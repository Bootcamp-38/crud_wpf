using crud_wpf.Context;
using crud_wpf.Models;
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

namespace crud_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext myContext = new MyContext();
        public MainWindow()
        {
            InitializeComponent();
            //view data
            Table_Supplier.ItemsSource = myContext.Suppliers.ToList();
        }
        private void Table_Supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bt_input_Click(object sender, RoutedEventArgs e)
        {
            if (nama.Text == string.Empty)
            {
                MessageBox.Show("Data kosong");
                nama.Focus();
            }
            else
            {
                var input = new Supplier(nama.Text);
                myContext.Suppliers.Add(input);
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil masuk");
                Table_Supplier.ItemsSource = myContext.Suppliers.ToList();
            }
            

        }

        private void Bt_delete_Click(object sender, RoutedEventArgs e)
        {
            int id = (Table_Supplier.SelectedItem as Supplier).Id;
            var del = myContext.Suppliers.Where(n => n.Id == id).Single();
            myContext.Suppliers.Remove(del);
            myContext.SaveChanges();
            MessageBox.Show("Data Berhasil dihapus");
            Table_Supplier.ItemsSource = myContext.Suppliers.ToList();
        }

        private void Bt_update_Click(object sender, RoutedEventArgs e)
        {
            //int id = (Table_Supplier.SelectedItem as Supplier).Id;
            //Supplier updaate = (from n in myContext.Suppliers where n.Id==id)
        }
    }
}
