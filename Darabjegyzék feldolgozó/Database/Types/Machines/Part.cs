using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Machines
{
    public class Part : Raw
    {
        public List<Part> Parts;

        public Part(int level, int item, double quantity, string um, string id, int kind, int ptyp, DateTime? validfrom, DateTime? validto, string serial) : base(level,item,quantity,um,id,kind,ptyp,validfrom,validto,serial)
        {

        }
    }
}
