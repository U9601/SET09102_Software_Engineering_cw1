using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_cw1
{
    //Getters and setters for Mentions List
    public class MentionsList
    {
        private string twitterIDs;


        public string TwitterIDs
        {
            get
            {
                return twitterIDs;
            }
            set
            {
                twitterIDs = value;
            }
        }
    }
}
