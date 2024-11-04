using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Machines
{
    public class Raw
    {
        //The Raw part Type, essentially contains a BOM element in itself does not contains relations

        public int Level { get; }
        public int Item { get; }
        public double Quantity { get; }
        public string UM { get; }
        public string Id { get; }
        public int Kind { get; }
        public int PTYP { get; }
        public DateTime? Validfrom { get; }
        public DateTime? Validto { get; }
        public string Serial { get; }

        public Raw(int level, int item, double quantity, string um, string id, int kind, int ptyp, DateTime? validfrom, DateTime? validto, string serial)
        {
            Level = level;
            Item = item;
            Quantity = quantity;
            UM = um;
            Id = id;
            Kind = kind;
            PTYP = ptyp;
            Validfrom = validfrom;
            Validto = validto;
            Serial = serial;
        }
    }
}
