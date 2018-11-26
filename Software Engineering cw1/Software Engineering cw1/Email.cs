using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_cw1
{
    //Getters and Setters for email
   public class Email
    {
        private string messageID;
        private string email;
        private string subject;
        private string messageBody;


        public string MessageID
        {
            get
            {
                return messageID;
            }
            set
            {
                messageID = value;
            }
        }

        public string EmailAddress

        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }


        public string MessageBody
        {
            get
            {
                return messageBody;
            }
            set
            {
                messageBody = value;
            }
        }
    }
}
