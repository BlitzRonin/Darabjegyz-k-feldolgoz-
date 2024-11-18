using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Darabjegyzék_feldolgozó.Database.Types.Machines
{
    // The Type of all BOM Files
    public class DMachine
    {
        public string Id { get; }
        public List<Part> Parts;
        public List<Raw> Raws { get {return raws; } }

        private List<Raw> raws;

        public DMachine(string id)
        {
            Id = id;
        }

        public void AddRaw(int level, int item, double quantity, string um, string id, int kind, int ptyp, DateTime? validfrom, DateTime? validto, string serial)
        {
            if (raws == null)
            {
                raws = [new Raw(level, item, quantity, um, id, kind, ptyp, validfrom, validto, serial)];
            }
            else
            {
                raws.Add(new Raw(level, item, quantity, um, id, kind, ptyp, validfrom, validto, serial));
            }
        }
    }
}
