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
        public List<Raw> Raws;

        public DMachine(string id)
        {
            Id = id;
        }
    }
}
