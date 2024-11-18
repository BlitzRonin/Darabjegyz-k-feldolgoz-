using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database.File;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Factories.Preppers;

namespace Darabjegyzék_feldolgozó.Database
{
    //This Class is the Connection between the database and the Execution Layers

    public class DatabaseHandler : DatabaseInterface
    {
        public Filter Filtering { get; }
        public List<DMachine> Machines { get { return machines; } }
        
        private List<DMachine> machines;

        public DatabaseHandler()
        {
            Filtering = new Filter();
            machines = new List<DMachine>();
        }

        public void removeThis(int index)
        {
            machines.RemoveAt(index);
            Filtering.removeActive(machines[index].Id);
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
            Filtering.removeActive(id);
        }

        //Adds a new BOM into the program

        public void addNew(string path)
        {
            using (RawPrepper prepit = new RawPrepper())
            {
                machines.Add(prepit.prepper(path, machines));
            }
            Filtering.addActive(machines[machines.Count - 1].Id);
            addTree(machines.Count-1);
        }

        //Makes the BOM relational with the inclusion of pointers to its child nodes

        private void addTree(int index)
        {
            using (BomPrepper prepit = new BomPrepper())
            {
                machines[index].Parts = prepit.prepper(machines[index].Raws);
            }
        }
    }
}
