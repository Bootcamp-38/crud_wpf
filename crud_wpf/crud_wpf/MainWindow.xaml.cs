using crud_wpf.Context;
using crud_wpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            //bt_delete.IsEnabled = false;
            //bt_update.IsEnabled = false;
            id.IsEnabled = false;
            //menu
            
        }

        private void Table_Supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = Table_Supplier.SelectedItem;
            if (item != null)
            {
                string ID = (Table_Supplier.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                id.Text = ID;
                string NM = (Table_Supplier.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                nama.Text = NM;
                //bt_delete.IsEnabled = true;
                bt_update.IsEnabled = true;
                bt_input.IsEnabled = false;
            }
            
            
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
                id.Text = "";
                nama.Text = "";
            }
            

        }

        private void Bt_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("hapus data ini?", "Konfirmasi Hapus", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int Id = (Table_Supplier.SelectedItem as Supplier).Id;
                var del = myContext.Suppliers.Where(n => n.Id == Id).Single();
                try
                {
                    
                    myContext.Suppliers.Remove(del);
                    //myContext.Entry(del).Reload();
                    myContext.SaveChanges();
                    MessageBox.Show("Data Berhasil dihapus");
                    Table_Supplier.ItemsSource = myContext.Suppliers.ToList();
                    id.Clear();
                    nama.Clear();
                    //bt_delete.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data tidak bisa dihapus sedang digunakan di Table Item");
                    myContext.Entry(del).Reload();
                    id.Clear();
                    nama.Clear();
                    
                }
                
            }
            else
            {
                
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainlogin pndh = new mainlogin();
            pndh.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            id.Text = "";
            nama.Text = "";
            bt_input.IsEnabled = true;
            //bt_delete.IsEnabled = false;
            bt_update.IsEnabled = false;
        }

        private void nama_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pndh = new MainWindow();
            pndh.Show();
            this.Hide();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            crud_item pndh = new crud_item();
            pndh.Show();
            this.Hide();
        }
    }
}
