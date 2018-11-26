using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software_Engineering_cw1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        [TestMethod]
        public void SMS_ID()
        {
            string messageID = "S12345678";
            SMS target = new SMS();
            target.MessageID = messageID;
            Assert.AreEqual(messageID, target.MessageID);
        }

        [TestMethod]
        public void SMS_PhoneNumber()
        {
            string phoneNumber = "7985425748";
            SMS target = new SMS();
            target.PhoneNumber = phoneNumber;
            Assert.AreEqual(phoneNumber, target.PhoneNumber);
        }

        [TestMethod]
        public void SMS_Body()
        {
            string messagebody = "lol";
            SMS target = new SMS();
            target.MessageBody = messagebody;
            Assert.AreEqual(messagebody, target.MessageBody);
        }

        [TestMethod]
        public void Email_MessageID()
        {
            string messageID = "E12345678";
            Email target = new Email();
            target.MessageID = messageID;
            Assert.AreEqual(messageID, target.MessageID);
        }
        [TestMethod]
        public void Email_EmailAddress()
        {
            string emailaddress = "ctjones1965@gmail.com";
            Email target = new Email();
            target.EmailAddress = emailaddress;
            Assert.AreEqual(emailaddress, target.EmailAddress);
        }
        [TestMethod]
        public void Email_Subjects()
        {
            string subject = "SIR 01/08/98";
            Email target = new Email();
            target.Subject = subject;
            Assert.AreEqual(subject, target.Subject);
        }
        [TestMethod]
        public void Email_Body()
        {
            string messageBody = "Sort CodeL 99-99-99 Nature of Incident: Theft";
            Email target = new Email();
            target.MessageBody = messageBody;
            Assert.AreEqual(messageBody, target.MessageBody);
        }
        [TestMethod]
        public void Twitter_MessageID()
        {
            string messageID = "T12345678";
            Twitter target = new Twitter();
            target.MessageID = messageID;
            Assert.AreEqual(messageID, target.MessageID);
        }
        [TestMethod]
        public void Twitter_TwitterHandle()
        {
            string twitterhandle = "@U9601";
            Twitter target = new Twitter();
            target.TwitterHandle = twitterhandle;
            Assert.AreEqual(twitterhandle,target.TwitterHandle);
        }
        [TestMethod]
        public void Twitter_messageBody()
        {
            string messageBody = "#lol";
            Twitter target = new Twitter();
            target.MessageBody = messageBody;
            Assert.AreEqual(messageBody, target.MessageBody);
        }
        [TestMethod]
        public void TrendingList_hashtags()
        {
            string hashtags = "#lol";
            TrendingList target = new TrendingList();
            target.HashTags = hashtags;
            Assert.AreEqual(hashtags, target.HashTags);
        }
        [TestMethod]
        public void TrendingList_Count()
        {
            int count = 1;
            TrendingList target = new TrendingList();
            target.Count = count;
            Assert.AreEqual(count, target.Count);
        }

        [TestMethod]
        public void MentionsList_mentions()
        {
            string mentions = "1";
            MentionsList target = new MentionsList();
            target.TwitterIDs = mentions;
            Assert.AreEqual(mentions, target.TwitterIDs);
        }

        [TestMethod]
        public void sirList_SortCode()
        {
            string sortCode = "99-99-99";
            SirList target = new SirList();
            target.SortCode = sortCode;
            Assert.AreEqual(sortCode, target.SortCode);
        }

        [TestMethod]
        public void sirList_NatureOfIncident()
        {
            string natureOfIncident = "Nature of Incident: Theft";
            SirList target = new SirList();
            target.NatureofIncident = natureOfIncident;
            Assert.AreEqual(natureOfIncident, target.NatureofIncident);
        }

        [TestMethod]
        public void URLQuarantineList_url()
        {
            string url = "www.facebook.com";
            URLQuarantineList target = new URLQuarantineList();
            target.URL = url;
            Assert.AreEqual(url, target.URL);
        }


    }
}
