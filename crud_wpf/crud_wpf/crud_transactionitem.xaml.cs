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
    /// Interaction logic for crud_transactionitem.xaml
    /// </summary>
    public partial class crud_transactionitem : Window
    {
        MyContext myContext = new MyContext();
        
        public int cbn;
        public int cbo;
        public crud_transactionitem()
        {
            InitializeComponent();
            
            Table_Transactionitem.ItemsSource = myContext.Items.ToList();
            Table_Transactionitem.ItemsSource = myContext.Transactions.ToList();
            Table_Transactionitem.ItemsSource = myContext.TransactionItems.ToList();
            var nam = myContext.Items.ToList();
            var ord = myContext.Transactions.ToList();
            cb_nama.ItemsSource = nam;
            cb_orderdate.ItemsSource = ord;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            crud_transactionitem pndh = new crud_transactionitem();
            pndh.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainlogin pndh = new mainlogin();
            pndh.Show();
            this.Hide();
        }

        private void Bt_input_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nama.Text == string.Empty || cb_orderdate.SelectedItem == null || cb_nama.SelectedItem == null)
                {
                    MessageBox.Show("Data kosong");
                    nama.Focus();

                }
                else
                {
                    //int Stock = Convert.ToInt32(tb_stock.Text);
                    int qt = Convert.ToInt32(nama.Text);
                    var nami = myContext.Items.Where(s => s.Id == cbn).FirstOrDefault();
                    var od = myContext.Transactions.Where(o => o.Id == cbo).FirstOrDefault();

                    var input = new TransactionItem(qt, od, nami);
                    myContext.TransactionItems.Add(input);
                    myContext.SaveChanges();
                    MessageBox.Show("Data Berhasil masuk");
                    Table_Transactionitem.ItemsSource = myContext.TransactionItems.ToList();
                    id.Text = "";
                    nama.Text = "";
                    cb_nama.Text = "";
                    cb_orderdate.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void Bt_update_Click(object sender, RoutedEventArgs e)
        {
            if (nama.Text == string.Empty)
            {
                MessageBox.Show("data kosong");
            }
            else if (id.Text == string.Empty)
            {
                MessageBox.Show("Date id Kosong");
            }
            else if (cb_orderdate.Text=="")
            {
                MessageBox.Show("Order Date Kosong");
            }
            else if (cb_nama.Text == "")
            {
                MessageBox.Show("data item kosong");
            }
            else
            {
                //int Stock = Convert.ToInt32(tb_stock.Text);
                int qn = Convert.ToInt32(nama.Text);
                int Id = (Table_Transactionitem.SelectedItem as TransactionItem).Id;
                TransactionItem update = (from n in myContext.TransactionItems where n.Id == Id select n).Single();
                var nami = myContext.Items.Where(s => s.Id == cbn).FirstOrDefault();
                var od = myContext.Transactions.Where(o => o.Id == cbo).FirstOrDefault();
                update.Quantity = qn;
                update.Item = nami;
                update.Transaction = od;            
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil diupdate");
                Table_Transactionitem.ItemsSource = myContext.TransactionItems.ToList();
                id.Text = "";
                nama.Text = "";
                cb_nama.Text = "";
                cb_orderdate.Text = "";
                


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            id.Text = "";
            nama.Text = "";
            cb_nama.Text = "";
            cb_orderdate.Text = "";
            
            bt_input.IsEnabled = true;
            //bt_delete.IsEnabled = false;
            bt_update.IsEnabled = false;
        }
        private void Bt_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("hapus data ini?", "Konfirmasi Hapus", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int Id = (Table_Transactionitem.SelectedItem as TransactionItem).Id;
                var del = myContext.TransactionItems.Where(n => n.Id == Id).Single();
                myContext.TransactionItems.Remove(del);
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil dihapus");
                Table_Transactionitem.ItemsSource = myContext.TransactionItems.ToList();
                id.Clear();
                nama.Clear();
                //bt_delete.IsEnabled = false;
                id.Text = "";
                nama.Text = "";
                nama.Text = "";
                cb_nama.Text = "";
                cb_orderdate.Text = "";
            }
            else
            {

            }
        }

        private void Table_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                object item = Table_Transactionitem.SelectedItem;
                if (item != null)
                {
                    string ID = (Table_Transactionitem.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    id.Text = ID;
                    string QN = (Table_Transactionitem.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    nama.Text = QN;
                    string NM_I = (Table_Transactionitem.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    cb_nama.Text = NM_I;
                    string OR_DATE = (Table_Transactionitem.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    cb_orderdate.Text = OR_DATE.ToString();
                    
                    //bt_delete.IsEnabled = true;
                    bt_update.IsEnabled = true;
                    bt_input.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
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

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            crud_transaction pndh = new crud_transaction();
            pndh.Show();
            this.Hide();
        }

        private void Sp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbn = Convert.ToInt32(cb_nama.SelectedValue.ToString());
                cbo = Convert.ToInt32(cb_orderdate.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void Sp_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbo = Convert.ToInt32(cb_orderdate.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            change_password pndh = new change_password();
            pndh.Show();
            this.Hide();
        }
    }
}
