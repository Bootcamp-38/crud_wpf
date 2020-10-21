using crud_wpf.Context;
using crud_wpf.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace crud_wpf
{
    /// <summary>
    /// Interaction logic for crud_item.xaml
    /// </summary>
    public partial class crud_item : Window
    {
        MyContext myContext = new MyContext();
        public int cb;

        public crud_item()
        {

            InitializeComponent();
            Table_Item.ItemsSource = myContext.Suppliers.ToList();
            Table_Item.ItemsSource = myContext.Items.ToList();
            var com = myContext.Suppliers.ToList();
            sp.ItemsSource = com;
            id.IsEnabled = false;
            //bt_delete.IsEnabled = false;
            //bt_update.IsEnabled = false;
        }

        private void Table_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                
                object item = Table_Item.SelectedItem;
                if (item != null)
                {
                    string ID = (Table_Item.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    id.Text = ID;
                    string NM = (Table_Item.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    nama.Text = NM;
                    string NM_S = (Table_Item.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                    sp.Text = NM_S;
                    string STOCK = (Table_Item.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    tb_stock.Text = STOCK;
                    string PRICE = (Table_Item.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                    tb_price.Text = PRICE;
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

        private void Bt_input_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nama.Text == string.Empty || tb_price.Text == string.Empty || tb_stock.Text == string.Empty)
                {
                    MessageBox.Show("Data kosong");
                    nama.Focus();

                }
                else
                {
                    int Stock = Convert.ToInt32(tb_stock.Text);
                    int Price = Convert.ToInt32(tb_price.Text);
                    var sup = myContext.Suppliers.Where(s => s.Id == cb).FirstOrDefault();
                    var input = new Item(nama.Text, sup, Stock, Price);

                    myContext.Items.Add(input);
                    myContext.SaveChanges();
                    MessageBox.Show("Data Berhasil masuk");
                    Table_Item.ItemsSource = myContext.Items.ToList();
                    id.Text = "";
                    nama.Text = "";
                    sp.Text = "";
                    tb_price.Text = "";
                    tb_stock.Text = "";
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            
        }

        private void Bt_update_Click(object sender, RoutedEventArgs e)
        {
            if (nama.Text == string.Empty || tb_stock.Text == string.Empty || tb_price.Text == string.Empty || id.Text == string.Empty)
            {
                MessageBox.Show("data kosong");
            }
            else
            {
                int Stock = Convert.ToInt32(tb_stock.Text);
                int Price = Convert.ToInt32(tb_price.Text);
                int Id = (Table_Item.SelectedItem as Item).Id;
                Item update = (from n in myContext.Items where n.Id == Id select n).Single();
                var sup = myContext.Suppliers.Where(s => s.Id == cb).FirstOrDefault();
                update.Name = nama.Text;
                update.Supplier =sup;
                update.Stock = Stock;
                update.Price = Price;
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil diupdate");
                Table_Item.ItemsSource = myContext.Items.ToList();
                id.Text = "";
                nama.Text = "";
                sp.Text = "";
                tb_price.Text = "";
                tb_stock.Text = "";


            }
        }

        private void Bt_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("hapus data ini?", "Konfirmasi Hapus", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int Id = (Table_Item.SelectedItem as Item).Id;
                var del = myContext.Items.Where(n => n.Id == Id).Single();
                myContext.Items.Remove(del);
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil dihapus");
                Table_Item.ItemsSource = myContext.Items.ToList();
                id.Clear();
                nama.Clear();
                //bt_delete.IsEnabled = false;
                id.Text = "";
                nama.Text = "";
                sp.Text = "";
                tb_price.Text = "";
                tb_stock.Text = "";
            }
            else
            {
               
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainlogin pndh = new mainlogin();
            pndh.Show();
            this.Hide();
        }

        private void Sp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            cb = Convert.ToInt32(sp.SelectedValue.ToString());
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            id.Text = "";
            nama.Text = "";
            sp.Text = "";
            tb_price.Text = "";
            tb_stock.Text = "";
            bt_input.IsEnabled = true;
            //bt_delete.IsEnabled = false;
            bt_update.IsEnabled = false;

        }

        private void nama_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tb_stock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tb_price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+$");
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

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            crud_transaction pndh = new crud_transaction();
            pndh.Show();
            this.Hide();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
