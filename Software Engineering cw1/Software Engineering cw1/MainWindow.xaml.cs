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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Software_Engineering_cw1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string messageID = textBox.Text;
            string messageBody = textBlock.Text;
            string senderID = textBox2.Text;

            if (messageID[0].ToString().Equals("S"))
            {  
                if (IsPhoneNumber(senderID))
                {
                    MessageBox.Show("Phone number is valid");
                }
                else
                {
                    MessageBox.Show("Phone number is not valid");
                }
            }
            else if (messageID[0].ToString().Equals("E"))
            {
                MessageBox.Show("E");
            }
            else if (messageID[0].ToString().Equals("T"))
            {
                MessageBox.Show("T");
            }
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$").Success;
        }

        
    }
}
