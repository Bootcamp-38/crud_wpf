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
    /// Interaction logic for reset_token.xaml
    /// </summary>
    public partial class reset_token : Window
    {
        MyContext myContext = new MyContext();
        public reset_token()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //int Id = (Table_Supplier.SelectedItem as Supplier).Id;
            //Supplier update = (from n in myContext.Suppliers where n.Id == Id select n).Single();
            //update.Name = nama.Text;
            //myContext.SaveChanges();

            //string guid = email.ToString();
           

            if (string.IsNullOrEmpty(tb_email.Text))
            {
                MessageBox.Show("Email kosong", "Warning!", MessageBoxButton.OK);
            }
            else
            {
                if (!myContext.Logins.Any(x => x.Email == tb_email.Text))
                {
                    MessageBox.Show("Email anda tidak terdaftar", "Caution!", MessageBoxButton.OK);
                    tb_email.Clear();
                    tb_email.Focus();
                }
                else
                {
                    Login updatePassword = (from m in myContext.Logins
                                            where m.Email == tb_email.Text
                                            select m).FirstOrDefault();
                    updatePassword.Password = tb_pass.Password;
                    myContext.SaveChanges();
                    MessageBox.Show("Password Changed", "Succesfully", MessageBoxButton.OK);

                    tb_email.Clear();
                    tb_pass.Focus();
                    crud_item pndh = new crud_item();
                    pndh.Show();
                    this.Hide();
                }
            }

        }
    }
}
