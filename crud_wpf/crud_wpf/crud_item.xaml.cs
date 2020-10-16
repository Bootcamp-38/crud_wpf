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
    /// Interaction logic for crud_item.xaml
    /// </summary>
    public partial class crud_item : Window
    {
        MyContext myContext = new MyContext();
        public crud_item()
        {
            InitializeComponent();
            Table_Item.ItemsSource = myContext.Items.ToList();
            id.IsEnabled = false;
        }

        private void Table_Item_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                bt_delete.IsEnabled = true;
                bt_update.IsEnabled = true;
                bt_input.IsEnabled = false;
            }
                
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
                var input = new Item(nama.Text);
                myContext.Items.Add(input);
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil masuk");
                Table_Item.ItemsSource = myContext.Items.ToList();
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
                int Id = (Table_Item.SelectedItem as Item).Id;
                Item update = (from n in myContext.Items where n.Id == Id select n).Single();
                update.Name = nama.Text;
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil diupdate");
                Table_Item.ItemsSource = myContext.Items.ToList();
                id.Clear();
                nama.Clear();

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
                int Id = (Table_Item.SelectedItem as Item).Id;
                var del = myContext.Items.Where(n => n.Id == Id).Single();
                myContext.Items.Remove(del);
                myContext.SaveChanges();
                MessageBox.Show("Data Berhasil dihapus");
                Table_Item.ItemsSource = myContext.Items.ToList();
                id.Clear();
                nama.Clear();
                bt_delete.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            menu pndh = new menu();
            pndh.Show();
            this.Hide();
        }

        private void Sp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

           
        }
    }
}
