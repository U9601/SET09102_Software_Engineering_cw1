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
            string emailSubject = textBox4.Text;
            List<string> inputBody = new List<string>(messageBody.Split(null));

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
                                MethodsList smsAbbreviations = new MethodsList();
                                List<string> newinputBody = smsAbbreviations.smsAbbreviations(inputBody);
                                textBox3.Text = string.Join(" ", newinputBody);
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
                                MethodsList urlQuarantine = new MethodsList();
                                List<string> newInputBody = urlQuarantine.urlQuarantine(inputBody);
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
                                            textBox3.Text = string.Join(" ", newInputBody);

                                        }
                                        if (onlySix == false)
                                        {

                                            if (inputBody[7].Equals("Attack") || inputBody[7].Equals("Theft") || inputBody[7].Equals("Abuse") || inputBody[7].Equals("Threat") || inputBody[7].Equals("Incident") || inputBody[7].Equals("Loss"))
                                            {
                                                sirListData.NatureofIncident = inputBody[6].ToString() + " " + inputBody[7].ToString();
                                                textBox3.Text = string.Join(" ", newInputBody);

                                            }
                                            else
                                            {
                                                sirListData.NatureofIncident = inputBody[6];
                                                textBox3.Text = string.Join(" ", newInputBody);

                                            }
                                        }
                                    }
                                    
                                    MethodsList.addSirList(sirListData);

                                }
                                else
                                {
                                    textBox3.Text = string.Join(" ", newInputBody);

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
                            int counter = inputBody.Count;
                            MessageBox.Show("Twitter handle is valid");
                            for (int i = 0; i <= inputBody.Count; i++)
                            {
                                if (counter == i)
                                {
                                    break;
                                }

                                if (inputBody[i].Contains("#"))
                                {
                                    TrendingList hashtagListData = new TrendingList();
                                    hashtagListData.HashTags = inputBody[i].ToString();
                                    MethodsList.addTrendingsList(hashtagListData);

                                }
                                if (inputBody[i].Contains("@"))
                                {
                                    MentionsList mentionsListData = new MentionsList();
                                    mentionsListData.TwitterIDs = inputBody[i].ToString();
                                    MethodsList.addMentionsList(mentionsListData);
                                }
                            }

                            MethodsList smsAbbreviations = new MethodsList();
                            List<string> newInputBody = smsAbbreviations.smsAbbreviations(inputBody);
                            textBox3.Text = string.Join(" ", newInputBody);



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
        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            ListsWindow newWin = new ListsWindow();
            newWin.Show();

        }
    }
}
