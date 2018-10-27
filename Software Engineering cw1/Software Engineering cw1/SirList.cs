using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Engineering_cw1
{
    public class SirList
    {
        private string sortCode;
        private string natureofIncident;


        public string SortCode
        {
            get
            {
                return sortCode;
            }
            set
            {
                sortCode = value;
            }
        }

        public string NatureofIncident
        {
            get
            {
                return natureofIncident;
            }
            set
            {
                natureofIncident = value;
            }
        }
    }
}
