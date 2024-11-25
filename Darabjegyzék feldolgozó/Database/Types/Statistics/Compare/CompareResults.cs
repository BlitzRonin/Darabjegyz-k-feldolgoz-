using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Statistics.Compare
{
    public class CompareResults
    {
        public string A { get; set; }
        public string B { get; set; }
        public CompareResults(string a,string b) 
        { 
            A = a; 
            B = b;
        }

        public CompareResults()
        {
            
        }
    }
}
