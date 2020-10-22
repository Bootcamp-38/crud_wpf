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
using System.Windows.Shapes;

namespace crud_wpf
{
    /// <summary>
    /// Interaction logic for crud_transaction.xaml
    /// </summary>
    public partial class crud_transaction : Window
    {
        MyContext myContext = new MyContext();
        public crud_transaction()
        {
            InitializeComponent();
            Table_Transaction.ItemsSource = myContext.Transactions.ToList();
            id.IsEnabled = false;
        }

        private void Bt_input_Click(object sender, RoutedEventArgs e)
        {
            if (orderdate.Text == string.Empty)
            {
                MessageBox.Show("Data kosong");
                orderdate.Focus();

            }
            else
            {
                var order = Convert.ToDateTime(orderdate.Text);
                var input = new Transaction(order);
                myContext.Transactions.Add(input);
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil masuk");
                Table_Transaction.ItemsSource = myContext.Transactions.ToList();
                id.Text = "";
                orderdate.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainlogin pndh = new mainlogin();
            pndh.Show();
            this.Hide();
        }

        private void Bt_update_Click(object sender, RoutedEventArgs e)
        {
            if (orderdate.Text == string.Empty || id.Text == string.Empty)
            {
                MessageBox.Show("data kosong");
            }
            else
            {
                var order = Convert.ToDateTime(orderdate.Text);
                int Id = (Table_Transaction.SelectedItem as Transaction).Id;
                Transaction update = (from n in myContext.Transactions where n.Id == Id select n).Single();
                update.OrderDate = order;
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil diupdate");
                Table_Transaction.ItemsSource = myContext.Transactions.ToList();
                id.Clear();
                //nama.Clear();

            }
        }

        private void Table_Transacton_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = Table_Transaction.SelectedItem;
            if (item != null)
            {
                string ID = (Table_Transaction.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                id.Text = ID;
                string NM = (Table_Transaction.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                orderdate.Text = NM;
                //bt_delete.IsEnabled = true;
                bt_update.IsEnabled = true;
                bt_input.IsEnabled = false;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow pndh = new MainWindow();
            pndh.Show();
            this.Hide();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            crud_item pndh = new crud_item();
            pndh.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            id.Text = "";
            orderdate.Text = "";
            bt_input.IsEnabled = true;
            //bt_delete.IsEnabled = false;
            bt_update.IsEnabled = false;
        }
        private void Bt_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("hapus data ini?", "Konfirmasi Hapus", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int Id = (Table_Transaction.SelectedItem as Transaction).Id;
                var del = myContext.Transactions.Where(n => n.Id == Id).Single();
                try
                {

                    myContext.Transactions.Remove(del);
                    //myContext.Entry(del).Reload();
                    myContext.SaveChanges();
                    MessageBox.Show("Data Berhasil dihapus");
                    Table_Transaction.ItemsSource = myContext.Transactions.ToList();
                    id.Clear();
                    //orderdate.Clear();
                    //bt_delete.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Data tidak bisa dihapus sedang digunakan di Table Item");
                    //myContext.Entry(del).Reload();
                    //id.Clear();
                    //nama.Clear();

                }

            }
            else
            {

            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            crud_transaction pndh = new crud_transaction();
            pndh.Show();
            this.Hide();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            change_password pndh = new change_password();
            pndh.Show();
            this.Hide();
        }
    }
}
