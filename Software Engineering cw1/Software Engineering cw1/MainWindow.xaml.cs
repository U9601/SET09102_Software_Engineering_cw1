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
            string messageBody = textBox3.Text;
            string senderID = textBox2.Text;


            if (messageID.Length != 10)
            {
                MessageBox.Show("The Message ID must be 10 characters long including the starting letter");

            }
            else {

                if (messageID != null)
                {

                    if (messageID[0].ToString().Equals("S") || messageID[0].ToString().Equals("s"))
                    {
                        if (IsValidPhoneNumber(senderID))
                        {
                            MessageBox.Show("Phone number is valid");
                        }
                        else
                        {
                            MessageBox.Show("Phone number is not valid");
                        }
                    }
                    else if (messageID[0].ToString().Equals("E") || messageID[0].ToString().Equals("e"))
                    {
                        if (IsValidEmail(senderID))
                        {
                            MessageBox.Show("Email Address is valid");
                        }
                        else
                        {
                            MessageBox.Show("Email Address is not valid");
                        }
                    }
                    else if (messageID[0].ToString().Equals("T") || messageID[0].ToString().Equals("t"))
                    {
                        if (IsValidTwitterHandle(senderID))
                        {
                            MessageBox.Show("Twiter handle is valid");
                        }
                        else
                        {
                            MessageBox.Show("Twiter handle is not valid");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please start your Message ID with either 'S', 'E' or 'T'");
                }
            }
        }

        public static bool IsValidPhoneNumber(string number)
        {
            return Regex.Match(number, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").Success;
        }
        
        public static bool IsValidEmail(string email)
        {
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(email);
                return emailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidTwitterHandle(string twitterHandle)
        {
          if(twitterHandle[0].ToString().Equals("@"))
            {
                return true;
            }
            else
            {
               return false;
            }
        }



    }
}
