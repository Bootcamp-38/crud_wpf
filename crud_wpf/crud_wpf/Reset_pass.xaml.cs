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
    /// Interaction logic for Reset_pass.xaml
    /// </summary>
    public partial class Reset_pass : Window
    {
        public Reset_pass()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //public static Guid NewGuid();

            Guid g = Guid.NewGuid();
            Console.WriteLine(g);
            Console.WriteLine(Guid.NewGuid());

        }

    }
}
