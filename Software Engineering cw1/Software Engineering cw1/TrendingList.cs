using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_cw1
{
    //Getters and setters for TrendingList 
   public class TrendingList
    {
        private string hashTags;
        private int count;


        public string HashTags
        {
            get
            {
                return hashTags;
            }
            set
            {
                hashTags = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
    }
}
