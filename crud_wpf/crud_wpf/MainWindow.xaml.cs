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
            bt_delete.IsEnabled = false;
            bt_update.IsEnabled = false;

        }
        private void Table_Supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = Table_Supplier.SelectedItem;
            string ID = (Table_Supplier.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            id.Text = ID;
            string NM = (Table_Supplier.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            nama.Text = NM;
            bt_delete.IsEnabled = true;
            bt_update.IsEnabled = true;
            //bt_input.IsEnabled = false;

            


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
            if (nama.Text == string.Empty || id.Text == string.Empty)
            {
                MessageBox.Show("data kosong");
            }
            else
            {
                int Id = (Table_Supplier.SelectedItem as Supplier).Id;
                var del = myContext.Suppliers.Where(n => n.Id == Id).Single();
                myContext.Suppliers.Remove(del);
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil dihapus");
                Table_Supplier.ItemsSource = myContext.Suppliers.ToList();
                id.Clear();
                nama.Clear();
                bt_delete.IsEnabled = false;
            }
            

        }

        private void Bt_update_Click(object sender, RoutedEventArgs e)
        {
            if (nama.Text == string.Empty || id.Text == string.Empty)
            {
                MessageBox.Show("data kosong");
            }
            else
            {
                int Id = (Table_Supplier.SelectedItem as Supplier).Id;
                Supplier update = (from n in myContext.Suppliers where n.Id == Id select n).Single();
                update.Name = nama.Text;
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil diupdate");
                Table_Supplier.ItemsSource = myContext.Suppliers.ToList();
                id.Clear();
                nama.Clear();
                
            }
        }
    }
}
