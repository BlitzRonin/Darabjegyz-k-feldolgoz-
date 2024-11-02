using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database.File;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Factories.Preppers;

namespace Darabjegyzék_feldolgozó.Database
{
    public class DatabaseHandler : DatabaseInterface
    {
        public List<DMachine> Machines { get { return machines; } }
        private List<DMachine> machines;

        public DatabaseHandler()
        {
            machines = new List<DMachine>();
        }

        public void removeThis(int index)
        {
            machines.RemoveAt(index);
        }

        public void removeThis(string id)
        {
            for (int i = 0; i < machines.Count; i++)
            {
                if(id == machines[i].Id)
                {
                    machines.RemoveAt(i);
                }
            }
        }

        public void addNew(string path)
        {
            addRaw(path);
        }

        private void addRaw(string path)
        {
            using (RawPrepper prepit = new RawPrepper())
            {
                machines.Add(prepit.prepper(path,machines));
            }
            alterrations();
        }

        private void alterrations()
        {
            int thisone = machines.Count - 1;
            addTree(thisone);
        }

        private void addTree(int index)
        {
            using (BomPrepper prepit = new BomPrepper())
            {
                machines[index].Parts = prepit.prepper(machines[index].Raws);
            }
        }
    }
}
