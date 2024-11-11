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
        public string Path { get; }
        public Part part { get; }
        public CompareElements(string path, Part part)
        {
            Path = path;
            this.part = part;
        }
    }
}
