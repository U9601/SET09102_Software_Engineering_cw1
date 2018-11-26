using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_cw1
{
    //Getters and setters for SMS's
   public class SMS
    {
        private string messageID;
        private string phoneNumber;
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

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
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
