using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types
{
    public class Part
    {
        public int Level { get; }
        public string BomName { get; }

        public Part(int level,string name) 
        {
            Level = level;
            BomName = name;
        }
    }
}
