using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private SirList store = new SirList();
        public MainWindow()
        {
            InitializeComponent();
            InitialsingData();
        }


        private void InitialsingData()
        {
            label4.Content = "";
            label5.Content = "";
            label6.Content = "";
            textBox4.Visibility = Visibility.Hidden;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string messageID = textBox.Text;
            string messageBody = textBox3.Text;
            string senderID = textBox2.Text;
            string changeAbbreviation;
            string emailSubject = textBox4.Text;
            bool allWordsChanged = false;


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
                            if (messageBody.Length <= 140)
                            {
                                ReadingExcel readingFromExcel = new ReadingExcel();
                                ArrayList textWords = readingFromExcel.readFromExcel();
                                ArrayList splicedTextWords = readingFromExcel.spliceAnArray(textWords);
                                List<string> messageBodySplit = new List<string>(messageBody.Split(null));

                                for (int j = 0; j <= messageBodySplit.Count; j++)
                                {
                                    for ( int i = 0; i <= splicedTextWords.Count; i++)
                                    {
                                        if (i >= splicedTextWords.Count)
                                        {
                                            i = 0;
                                            if (j == messageBodySplit.Count - 1)
                                            {
                                                allWordsChanged = true;
                                            }
                                            else
                                            {
                                                j++;
                                            }
                                        }
                                        if (allWordsChanged == false)
                                        {
                                            if (messageBodySplit[j].ToString().Equals(splicedTextWords[i].ToString()))
                                            {
                                                MessageBox.Show("Match");
                                                changeAbbreviation = splicedTextWords[i + 1].ToString();
                                                changeAbbreviation = "<" + changeAbbreviation + ">";
                                                messageBodySplit.Insert(j + 1, changeAbbreviation);
                                                textBox3.Text = string.Join(" ", messageBodySplit);
                                                j++;
                                                i = -1;
                                            }


                                            if (j >= messageBodySplit.Count)
                                            {
                                                break;
                                            }
                                        }
                                        if(allWordsChanged == true)
                                        {
                                            break;
                                        }
                                    }
                                    if(allWordsChanged == true)
                                    {
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Your Message is too long, no more than 140 characters");

                            }
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
                            if (emailSubject.Length > 20)
                            {
                                MessageBox.Show("Subject is too long must be less and 20 characters");
                            }
                            else if (messageBody.Length > 1028)
                            {
                                MessageBox.Show("Message Text is too long must be less tahn 1028 characters");
                            }
                            else
                            {
                                string[] inputSubject = emailSubject.Split(null);
                                List<string> inputBody = new List<string>(messageBody.Split(null));
                                DateTime Date = new DateTime();
                                bool hasDate = false;

                                foreach(string text in inputSubject)
                                {
                                    try
                                    {
                                        if (inputSubject.Contains("SIR"))
                                        {
                                            Date = DateTime.Parse(text);
                                            hasDate = true;
                                            break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                if (hasDate)
                                {
                                    MessageBox.Show("important Email");
                                    SirList sirListData = new SirList();
                                    bool onlySix = false;
                                    if (inputBody.Contains("Sort"))
                                    {
                                        sirListData.SortCode = (inputBody[2]);
                                    }
                                    if (inputBody.Contains("Nature"))
                                    {
                                        if (inputBody.Count == 7)
                                        {
                                            sirListData.NatureofIncident = inputBody[6];
                                            onlySix = true;

                                        }
                                        if (onlySix == false)
                                        {

                                            if (inputBody[7].Equals("Attack") || inputBody[7].Equals("Theft") || inputBody[7].Equals("Abuse") || inputBody[7].Equals("Threat") || inputBody[7].Equals("Incident") || inputBody[7].Equals("Loss"))
                                            {
                                                sirListData.NatureofIncident = inputBody[6].ToString() + " " + inputBody[7].ToString();
                                            }
                                            else
                                            {
                                                sirListData.NatureofIncident = inputBody[6];
                                            }
                                        }
                                    }
                                    ReadingExcel.add(sirListData);

                                }
                                else
                                {
                                    MessageBox.Show("Not important");
                                    int counter = inputBody.Count;
                                    for(int i = 0; i <= inputBody.Count; i++)
                                    {
                                        if (counter == i)
                                        {
                                            break;
                                        }

                                        if (inputBody[i].Contains("https://") || inputBody[i].Contains("http://") || inputBody[i].Contains("www."))
                                        {
                                            MessageBox.Show("Qurantine");
                                            string url = inputBody[i].ToString();
                                            url = "<" + "URL Qrantined" + ">";
                                            inputBody.Insert(i + 1, url);
                                            inputBody.RemoveAt(i);
                                            textBox3.Text = string.Join(" ", inputBody);
                                        }
                                        
                                    }
                                 
                                }

                            }

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
                            MessageBox.Show("Twitter handle is valid");
                        }
                        else
                        {
                            MessageBox.Show("Twitter handle is not valid");
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
          if(twitterHandle[0].ToString().Equals("@") && twitterHandle.Length <=15)
            {
                return true;
            }
            else
            {
               return false;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageID = textBox.Text;
            
            if (messageID != "")
            {
                string messageType = messageID[0].ToString();
                if(messageType == "S")
                {
                    label4.Content = "SMS Selected";
                    label2.Content = "Please Enter your Phone Number Here:";
                    label5.Content = "";
                    label3.Content = "Please Enter your Text Here:";
                    label6.Content = "";
                    textBox4.Visibility = Visibility.Hidden;
                    textBox3.Margin = new Thickness(241, 205, 0, 0);
                    label3.Margin = new Thickness(10, 205, 0, 0);
                    button.Margin = new Thickness(333, 369, 0, 0);
                }
                else if(messageType == "E")
                {
                    label4.Content = "Email Selected";
                    label2.Content = "Please Enter your Email Address Here:";
                    label5.Content = "";
                    label3.Content = "Please Write your Email Here:";
                    label6.Content = "Please Write your Subject Here";
                    textBox4.Visibility = Visibility.Visible;
                    textBox3.Margin = new Thickness(241, 265, 0, 0);
                    label3.Margin = new Thickness(10, 265, 0, 0);
                    button.Margin = new Thickness(330, 410, 0, 0);
                }
                else if (messageType == "T")
                {
                    label4.Content = "Twitter Selected";
                    label2.Content = "Please Enter your Twitter Handle Here:";
                    label5.Content = "";
                    label3.Content = "Please Enter your Tweet Here";
                    label6.Content = "";
                    textBox4.Visibility = Visibility.Hidden;
                    textBox3.Margin = new Thickness(241, 205, 0, 0);
                    label3.Margin = new Thickness(10, 205, 0, 0);
                    button.Margin = new Thickness(333, 369, 0, 0);

                }
                else
                {
                    label4.Content = "Incorrect Message Type";
                    label5.Content = "Detected";
                    label2.Content = "Please use S, E or T Above:";
                    label3.Content = "";
                    textBox4.Visibility = Visibility.Hidden;
                    textBox3.Margin = new Thickness(241, 205, 0, 0);
                    label3.Margin = new Thickness(10, 205, 0, 0);
                    button.Margin = new Thickness(333, 369, 0, 0);

                }
            }

        }

        private void SirListButton_Click(object sender, RoutedEventArgs e)
        {
            SirListDisplay newWin = new SirListDisplay();
            newWin.Show();

           // WindowState = WindowState.Minimized;
        }
    }
}
