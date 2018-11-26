using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_cw1
{
    //Getters and setters for Twitter
    public class Twitter
    {
        private string messageID;
        private string twitterHandle;
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

        public string TwitterHandle
        {
            get
            {
                return twitterHandle;
            }
            set
            {
                twitterHandle = value;
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
