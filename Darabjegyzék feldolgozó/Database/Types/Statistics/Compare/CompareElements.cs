using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database.Types.Machines;

namespace Darabjegyzék_feldolgozó.Database.Types.Statistics.Compare
{
    public class CompareElements
    {
        public string Mode { get; }
        public List<CompareElements> relation;

        public CompareElements(string mode)
        {
            Mode = mode;
        }
    }
}
