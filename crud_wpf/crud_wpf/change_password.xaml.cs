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
    /// Interaction logic for change_password.xaml
    /// </summary>
    public partial class change_password : Window
    {
        MyContext myContext = new MyContext();
        public change_password()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tb_old.Password == "" || tb_new.Password=="")
                {
                    MessageBox.Show("masukkan password");
                    //tb_old.Focus();
                }
                else if (tb_new.Password != tb_conf.Password)
                {
                    MessageBox.Show("Password tidak sesuai!");
                }

                else
                {

                    if (!myContext.Logins.Any(x => x.Password == tb_old.Password))
                    {
                        MessageBox.Show("Password anda salah", "Caution!", MessageBoxButton.OK);
                        tb_old.Clear();
                        tb_new.Focus();
                    }
                    else
                    {
                        Login updatePassword = (from m in myContext.Logins
                                                where m.Password == tb_old.Password
                                                select m).FirstOrDefault();
                        updatePassword.Password = tb_new.Password;
                        myContext.SaveChanges();
                        MessageBox.Show("Password Changed", "Succesfully", MessageBoxButton.OK);

                        tb_new.Clear();
                        tb_old.Focus();
                        crud_item pndh = new crud_item();
                        pndh.Show();
                        this.Hide();
                    }

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
