using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            label7.Content = "";
            label8.Content = "";
            label9.Content = "";
            textBox4.Visibility = Visibility.Hidden;
            dataGrid.Visibility = Visibility.Hidden;
            dataGrid2.Visibility = Visibility.Hidden;
            dataGrid3.Visibility = Visibility.Hidden;
            dataGrid4.Visibility = Visibility.Hidden;
            comboBox.Visibility = Visibility.Hidden;
            button.Margin = new Thickness(443, 430, 0, 0);
            button2.Margin = new Thickness(241, 430, 0, 0);
            Application.Current.MainWindow = this;
            Application.Current.MainWindow.Height = 520;
            Application.Current.MainWindow.Width = 650;
            comboBox.Items.Add("+93");
            comboBox.Items.Add("+355");
            comboBox.Items.Add("+213");
            comboBox.Items.Add("+376");
            comboBox.Items.Add("+244");
            comboBox.Items.Add("+54");
            comboBox.Items.Add("+374");
            comboBox.Items.Add("+297");
            comboBox.Items.Add("+61");
            comboBox.Items.Add("+43");
            comboBox.Items.Add("+880");
            comboBox.Items.Add("+32");
            comboBox.Items.Add("+44");
            comboBox.Items.Add("+1");
            comboBox.Items.Add("+56");
            comboBox.Items.Add("+53");
            comboBox.Items.Add("+45");
            comboBox.Items.Add("+56");
            comboBox.Items.Add("+20");
            comboBox.Items.Add("+33");
            comboBox.Items.Add("+49");
            comboBox.Items.Add("+30");
            comboBox.Items.Add("+36");
            comboBox.Items.Add("+91");
            comboBox.Items.Add("+98");
            comboBox.Items.Add("+93");
            comboBox.Items.Add("+81");
            comboBox.Items.Add("+93");

        }
        List<JObject> obj = new List<JObject>();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string messageID = textBox.Text;
            string messageBody = textBox3.Text;
            string senderID = textBox2.Text;
            string emailSubject = textBox4.Text;
            List<string> inputBody = new List<string>(messageBody.Split(null));

            if (!Regex.Match(messageID, @"[a-zA-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]").Success)
            {
                MessageBox.Show("The Message ID must be 10 characters long including the starting letter");

            }
            else
            {

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
                                SMS sms = new SMS();
                                sms.MessageID = textBox.Text;
                                sms.PhoneNumber = textBox2.Text;
                                sms.MessageBody = textBox3.Text;
                                using (StreamWriter writer = File.AppendText(@"output.json"))
                                {
                                    JsonSerializer serializer = new JsonSerializer();
                                    serializer.Serialize(writer, sms);
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
                                MethodsList urlQuarantine = new MethodsList();
                                List<string> newInputBody = urlQuarantine.urlQuarantine(inputBody);
                                Emailing(newInputBody);
                            }
                            Email email = new Email();
                            email.MessageID = textBox.Text;
                            email.EmailAddress = textBox2.Text;
                            email.Subject = textBox4.Text;
                            email.MessageBody = textBox3.Text;
                            using (StreamWriter writer = File.AppendText(@"output.json"))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(writer, email);
                            }
                            dataGrid.ItemsSource = MethodsList.getDataSirList();
                            dataGrid4.ItemsSource = MethodsList.getDataQuaratineList();
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
                            MethodsList smsAbbreviations = new MethodsList();
                            List<string> newInputBody = smsAbbreviations.smsAbbreviations(inputBody);
                            textBox3.Text = string.Join(" ", newInputBody);

                            Tweeting(newInputBody);

                            Twitter twitter = new Twitter();
                            twitter.MessageID = textBox.Text;
                            twitter.TwitterHandle = textBox2.Text;
                            twitter.MessageBody = textBox3.Text;
                            using (StreamWriter writer = File.AppendText(@"output.json"))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(writer, twitter);
                            }

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
            if (twitterHandle[0].ToString().Equals("@") && twitterHandle.Length <= 15 && twitterHandle.Length != 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Emailing(List<string> newInputBody)
        {
            string emailSubject = textBox4.Text;
            string[] inputSubject = emailSubject.Split(null);

            DateTime Date = new DateTime();
            bool hasDate = false;

            foreach (string text in inputSubject)
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
                if (newInputBody.Contains("Sort"))
                {
                    sirListData.SortCode = (newInputBody[2]);
                }
                if (newInputBody.Contains("Nature"))
                {
                    if (newInputBody.Count == 7)
                    {
                        sirListData.NatureofIncident = newInputBody[6];
                        onlySix = true;
                        textBox3.Text = string.Join(" ", newInputBody);
                    }
                    if (onlySix == false)
                    {

                        if (newInputBody[7].Equals("Attack") || newInputBody[7].Equals("Theft") || newInputBody[7].Equals("Abuse") || newInputBody[7].Equals("Threat") || newInputBody[7].Equals("Incident") || newInputBody[7].Equals("Loss"))
                        {
                            sirListData.NatureofIncident = newInputBody[6].ToString() + " " + newInputBody[7].ToString();
                            textBox3.Text = string.Join(" ", newInputBody);

                        }
                        else
                        {
                            sirListData.NatureofIncident = newInputBody[6];
                            textBox3.Text = string.Join(" ", newInputBody);

                        }
                    }
                }
                MethodsList.addSirList(sirListData);
                dataGrid.ItemsSource = MethodsList.getDataSirList();
                dataGrid4.ItemsSource = MethodsList.getDataQuaratineList();


            }
            else
            {
                textBox3.Text = string.Join(" ", newInputBody);
            }
        }

        public void Tweeting(List<string> inputBody)
        {
            MethodsList smsAbbreviations = new MethodsList();
            List<string> newInputBody = smsAbbreviations.smsAbbreviations(inputBody);
            textBox3.Text = string.Join(" ", newInputBody);
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


                    if (!MethodsList.trendingsList.Any(x => x.HashTags == inputBody[i].ToString()))
                    {
                        hashtagListData.HashTags = inputBody[i].ToString();
                        hashtagListData.Count = 1;
                        MethodsList.addTrendingsList(hashtagListData);
                        dataGrid2.ItemsSource = MethodsList.getDataTrendingsList();
                    }
                    else
                    {
                        TrendingList trendingList = MethodsList.trendingsList.FirstOrDefault(n => n.HashTags == inputBody[i].ToString());
                        trendingList.Count = trendingList.Count + 1;
                        dataGrid2.ItemsSource = null;
                        dataGrid2.ItemsSource = MethodsList.getDataTrendingsList();
                    }


                }

                if (inputBody[i].Contains("@"))
                {
                    MentionsList mentionsListData = new MentionsList();
                    mentionsListData.TwitterIDs = inputBody[i].ToString();
                    MethodsList.addMentionsList(mentionsListData);
                    dataGrid3.ItemsSource = MethodsList.getDataMentionsList();
                }
            }
        }



        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageID = textBox.Text;

            if (messageID != "")
            {
                string messageType = messageID[0].ToString();
                if (messageType == "S")
                {
                    label4.Content = "SMS Selected";
                    label2.Content = "Please Enter your Phone Number Here:";
                    label5.Content = "";
                    label3.Content = "Please Enter your Text Here:";
                    label6.Content = "";
                    label7.Content = "";
                    label8.Content = "";
                    textBox2.Clear();
                    dataGrid.Visibility = Visibility.Hidden;
                    dataGrid2.Visibility = Visibility.Hidden;
                    dataGrid3.Visibility = Visibility.Hidden;
                    dataGrid4.Visibility = Visibility.Hidden;
                    textBox4.Visibility = Visibility.Hidden;
                    comboBox.Visibility = Visibility.Visible;
                    textBox3.Margin = new Thickness(241, 205, 0, 0);
                    label3.Margin = new Thickness(0, 205, 0, 0);
                    button.Margin = new Thickness(443, 430, 0, 0);
                    button2.Margin = new Thickness(241, 430, 0, 0);
                    Application.Current.MainWindow = this;
                    Application.Current.MainWindow.Height = 520;
                    Application.Current.MainWindow.Width = 650;
                }
                else if (messageType == "E")
                {
                    label4.Content = "Email Selected";
                    label2.Content = "Please Enter your Email Address Here:";
                    label5.Content = "";
                    label3.Content = "Please Write your Email Here:";
                    label6.Content = "Please Write your Subject Here";
                    label7.Content = "SIR LIST";
                    label8.Content = "URL Quarantine";
                    textBox2.Clear();
                    dataGrid.Visibility = Visibility.Visible;
                    dataGrid2.Visibility = Visibility.Hidden;
                    dataGrid3.Visibility = Visibility.Hidden;
                    dataGrid4.Visibility = Visibility.Visible;
                    textBox4.Visibility = Visibility.Visible;
                    comboBox.Visibility = Visibility.Hidden;
                    textBox.Margin = new Thickness(241, 108, 0, 0);
                    textBox2.Margin = new Thickness(241, 158, 0, 0);
                    textBox3.Margin = new Thickness(241, 255, 0, 0);
                    label3.Margin = new Thickness(0, 255, 0, 0);
                    label6.Margin = new Thickness(0, 205, 0, 0);
                    label8.Margin = new Thickness(845, 70, 0, 0);
                    label7.Margin = new Thickness(680, 70, 0, 0);
                    button.Margin = new Thickness(443, 480, 0, 0);
                    button2.Margin = new Thickness(241, 480, 0, 0);
                    Application.Current.MainWindow = this;
                    Application.Current.MainWindow.Height = 580;
                    Application.Current.MainWindow.Width = 1060;
                }
                else if (messageType == "T")
                {
                    label4.Content = "Twitter Selected";
                    label2.Content = "Please Enter your Twitter Handle Here:";
                    label5.Content = "";
                    label3.Content = "Please Enter your Tweet Here";
                    label6.Content = "";
                    label8.Content = "Trending List";
                    label7.Content = "Mentions List";
                    textBox2.Clear();
                    dataGrid.Visibility = Visibility.Hidden;
                    dataGrid2.Visibility = Visibility.Visible;
                    dataGrid3.Visibility = Visibility.Visible;
                    dataGrid4.Visibility = Visibility.Hidden;
                    textBox4.Visibility = Visibility.Hidden;
                    textBox4.Visibility = Visibility.Hidden;
                    comboBox.Visibility = Visibility.Hidden;
                    textBox3.Margin = new Thickness(241, 205, 0, 0);
                    label3.Margin = new Thickness(0, 205, 0, 0);
                    label7.Margin = new Thickness(845, 70, 0, 0);
                    label8.Margin = new Thickness(680, 70, 0, 0);
                    button.Margin = new Thickness(443, 430, 0, 0);
                    button2.Margin = new Thickness(241, 430, 0, 0);
                    Application.Current.MainWindow = this;
                    Application.Current.MainWindow.Height = 520;
                    Application.Current.MainWindow.Width = 1060;
                }
                else
                {
                    label4.Content = "Incorrect Message Type";
                    label5.Content = "Detected";
                    label2.Content = "Please use S, E or T Above:";
                    label3.Content = "";
                    label6.Content = "";
                    label7.Content = "";
                    label8.Content = "";
                    textBox2.Clear();
                    dataGrid.Visibility = Visibility.Hidden;
                    dataGrid2.Visibility = Visibility.Hidden;
                    dataGrid4.Visibility = Visibility.Hidden;
                    dataGrid3.Visibility = Visibility.Hidden;
                    textBox4.Visibility = Visibility.Hidden;
                    textBox4.Visibility = Visibility.Hidden;
                    comboBox.Visibility = Visibility.Hidden;
                    textBox3.Margin = new Thickness(241, 205, 0, 0);
                    label3.Margin = new Thickness(10, 205, 0, 0);
                    button.Margin = new Thickness(333, 369, 0, 0);
                    button2.Margin = new Thickness(241, 430, 0, 0);
                    Application.Current.MainWindow = this;
                    Application.Current.MainWindow.Height = 520;
                    Application.Current.MainWindow.Width = 710;
                }
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog browse = new Microsoft.Win32.OpenFileDialog();

            browse.DefaultExt = ".json";
            browse.Filter = "JSON Files (.json)|*.json";

            bool? result = browse.ShowDialog();

            if (result == true)
            {
                string filename = browse.FileName;
                if (new FileInfo(filename).Length != 0)
                {
                    MethodsList jsonDeserialize = new MethodsList();
                    obj = jsonDeserialize.jsonDeserializer(filename);
                    for (int i = 0; i < obj.Count; i++)
                    {
                        string messageID = obj[i]["MessageID"].ToString();
                        string messageBody = obj[i]["MessageBody"].ToString();
                        listBox.Items.Add(obj[i]["MessageID"]);
                      

                        /* if (messageID[0].ToString() == "S")
                         {
                             textBox.Text = obj[i]["MessageID"].ToString();
                             textBox2.Text = obj[i]["PhoneNumber"].ToString();
                             textBox3.Text = obj[i]["MessageBody"].ToString();
                             MethodsList smsAbbreviations = new MethodsList();
                             List<string> newInputBody = smsAbbreviations.smsAbbreviations(inputBody);
                             textBox3.Text = string.Join(" ", newInputBody);

                         }
                         else if (messageID[0].ToString() == "E")
                         {
                             textBox.Text = obj[i]["MessageID"].ToString();
                             textBox2.Text = obj[i]["EmailAddress"].ToString();
                             textBox4.Text = obj[i]["Subject"].ToString();
                             textBox3.Text = obj[i]["MessageBody"].ToString();
                             Emailing(inputBody);

                         }
                         else if ((messageID[0].ToString() == "T"))
                         {
                             textBox.Text = obj[i]["MessageID"].ToString();
                             textBox2.Text = obj[i]["TwitterHandle"].ToString();
                             textBox3.Text = obj[i]["MessageBody"].ToString();
                             Tweeting(inputBody);
                         }
                     }*/
                    }
                }
                else
                {
                    MessageBox.Show("The file you have selected is empty D:");
                }

            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string messageID = listBox.SelectedItem.ToString();

            if (messageID[0].ToString() == "S")
            {
                JObject findobj = obj.FirstOrDefault(n => n["MessageID"].ToString().Equals(messageID));
                textBox.Text = findobj["MessageID"].ToString();
                textBox2.Text = findobj["PhoneNumber"].ToString();
                textBox3.Text = findobj["MessageBody"].ToString();
                MethodsList smsAbbreviations = new MethodsList();
                string messageBody = findobj["MessageBody"].ToString();
                List<string> inputBody = new List<string>(messageBody.Split(null));
                List<string> newInputBody = smsAbbreviations.smsAbbreviations(inputBody);
                textBox3.Text = string.Join(" ", newInputBody);
            }
            else if (messageID[0].ToString() == "E")
            {
                JObject findobj = obj.FirstOrDefault(n => n["MessageID"].ToString().Equals(messageID));
                textBox.Text = findobj["MessageID"].ToString();
                textBox2.Text = findobj["EmailAddress"].ToString();
                textBox4.Text = findobj["Subject"].ToString();
                textBox3.Text = findobj["MessageBody"].ToString();
                string messageBody = findobj["MessageBody"].ToString();
                List<string> inputBody = new List<string>(messageBody.Split(null));
                Emailing(inputBody);

            }
            else if ((messageID[0].ToString() == "T"))
            {
                JObject findobj = obj.FirstOrDefault(n => n["MessageID"].ToString().Equals(messageID));
                textBox.Text = findobj["MessageID"].ToString();
                textBox2.Text = findobj["TwitterHandle"].ToString();
                textBox3.Text = findobj["MessageBody"].ToString();
                string messageBody = findobj["MessageBody"].ToString();
                List<string> inputBody = new List<string>(messageBody.Split(null));
                Tweeting(inputBody);

            }
        }
    





        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageID = textBox.Text;
            string validation = textBox2.Text;

            if (messageID != "")
            {
                string messageType = messageID[0].ToString();
                if (messageType == "S")
                {
                    if (IsValidPhoneNumber(validation))
                    {
                        label9.Content = "Valid";
                        label9.Background = Brushes.Green;
                        textBox2.Background = Brushes.Green;
                    }
                    else
                    {
                        label9.Content = "Invalid";
                        label9.Background = Brushes.Red;
                        textBox2.Background = Brushes.Red;
                    }
                }
                if (messageType == "E")
                {
                    if (IsValidEmail(validation))
                    {
                        label9.Content = "Valid";
                        label9.Background = Brushes.Green;
                        textBox2.Background = Brushes.Green;
                    }
                    else
                    {
                        label9.Content = "Invalid";
                        textBox2.Background = Brushes.Red;
                        label9.Background = Brushes.Red;
                    }
                }
                if (messageType == "T")
                {
                    if (IsValidTwitterHandle(validation))
                    {
                        label9.Content = "Valid";
                        label9.Background = Brushes.Green;
                        textBox2.Background = Brushes.Green;
                    }
                    else
                    {
                        label9.Content = "Invalid";
                        label9.Background = Brushes.Red;
                        textBox2.Background = Brushes.Red;
                    }
                }

            }
        }
    }
}


   
    
