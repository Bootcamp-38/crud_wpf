using crud_wpf.Context;
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
    /// Interaction logic for Reset_pass.xaml
    /// </summary>
    public partial class Reset_pass : Window
    {
        MyContext myContext = new MyContext();
        public Reset_pass()
        {
            InitializeComponent();
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tb_email.Text.Length == 0)
                {
                    MessageBox.Show("masukkan email");
                    tb_email.Focus();
                }
                else if (!Regex.IsMatch(tb_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MessageBox.Show("Email tidak valid");
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
                        if (passcek == tb_token.Password)
                        {
                            //crud_item mainPage = new crud_item();
                            //mainPage.Show();
                            //this.Close();
                            reset_token pndh = new reset_token();
                            pndh.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Email/Password salah", "Caution", MessageBoxButton.OK);
                            tb_email.Clear();
                            tb_token.Focus();
                        }
                    }

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
