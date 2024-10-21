using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database.File;
using Darabjegyzék_feldolgozó.Database.Types;
using Darabjegyzék_feldolgozó.Factory;

namespace Darabjegyzék_feldolgozó.Database
{
    public class DatabaseHandler : DatabaseInterface
    {
        public List<DMachine> GetDatabase { get { return machines; } }
        private List<DMachine> machines;
        public void fillthelist(string path)
        {
            using (BomPrepper prepit = new BomPrepper())
            {
                machines = prepit.prepper(path);
            }
        }
    }
}
