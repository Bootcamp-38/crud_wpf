using crud_wpf.Context;
using crud_wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
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
            if(Properties.Settings.Default.Username != string.Empty)
            {
                tb_email.Text = Properties.Settings.Default.Username;
                tb_pass.Password = Properties.Settings.Default.Password;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb_remember.IsChecked == true)
            {
                Properties.Settings.Default.Username = tb_email.Text;
                Properties.Settings.Default.Password = tb_pass.Password;
                Properties.Settings.Default.Save();
            }
            if (cb_remember.IsChecked == false)
            {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }


            try
            {
                if (tb_email.Text.Length == 0)
                {
                    MessageBox.Show("Email kosong");
                    //errormessage.Text = "Masukkan Email";
                   tb_email.Focus();
                }
                else if (!Regex.IsMatch(tb_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    MessageBox.Show("Email tidak valid");
                    //errormessage.Text = "Email tidak valid";
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
                            if (cb_remember.IsChecked == true)
                            {
                                
                            }
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

        private void Button_ForgotPass_Click(object sender, RoutedEventArgs e)
        {
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
                    Guid id = Guid.NewGuid();
                    string guid = id.ToString();
                    Login updateAdmins = (from m in myContext.Logins
                                          where m.Email == tb_email.Text
                                          select m).FirstOrDefault();
                    updateAdmins.Password = guid;
                    myContext.SaveChanges();

                    string PasswordText = "Masukkan karakter pengganti Password " + guid;

                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("agungaliakbar5@gmail.com", "twincell");
                    MailMessage mm = new MailMessage("tampan@gmail.com", tb_email.Text, "Secret!", PasswordText);
                    mm.Subject = "Lupa Password";
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.Send(mm);
                    MessageBox.Show("Password Changed, please check your email", "Succesfully", MessageBoxButton.OK);
                    tb_email.Clear();
                    tb_pass.Focus();
                    Reset_pass pndh = new Reset_pass();
                    pndh.Show();
                    this.Hide();
                }
            }
        }
        
    }
}
