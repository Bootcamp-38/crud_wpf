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
    /// Interaction logic for mainlogin.xaml
    /// </summary>
    public partial class mainlogin : Window
    {
        MyContext myContext = new MyContext();
        public mainlogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (tb_email.Text.Length == 0)
                {
                    errormessage.Text = "Masukkan Email";
                    tb_email.Focus();
                }
                else if (!Regex.IsMatch(tb_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessage.Text = "Email tidak valid";
                    tb_email.Select(0, tb_email.Text.Length);
                    tb_email.Focus();
                }
                else
                {
                    
                    var emailcek = myContext.Logins.FirstOrDefault(v => v.Email == tb_email.Text);
                    var passcek = emailcek.Password;
                    //var passcek = emailcek.Password;
                    if (string.IsNullOrEmpty(emailcek.ToString()))
                    {

                    }
                    else
                    {
                        if (passcek == tb_pass.Password)
                        {
                            crud_item mainPage = new crud_item();
                            mainPage.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Email/Password salah", "Caution", MessageBoxButton.OK);
                            tb_email.Clear();
                            tb_pass.Focus();
                        }
                    }

                }
            }
            catch (Exception)
            {

            }
            //Login cek = (from n in myContext.Logins where n.Email = tb_email select n).Single();
            //cek.Email = tb_email.Text;}
            //crud_item pndh = new crud_item();
            //pndh.Show();
            //this.Hide();
        }
    }
}
