using Darabjegyzék_feldolgozó.Database.File;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Factories.Preppers;
using System.IO;

namespace Darabjegyzék_feldolgozó.Database
{
    //This Class is the Connection between the database and the Execution Layers

    public class DatabaseHandler : DatabaseInterface
    {
        public FilterHandler Filtering { get; }
        public List<DMachine> Machines { get { return machines; } }
        
        private List<DMachine> machines;

        public DatabaseHandler()
        {
            Filtering = new FilterHandler();
            machines = new List<DMachine>();
        }

        public void removeThis(int index)
        {
            machines.RemoveAt(index);
            Filtering.removeMachine(machines[machines.Count - 1].Id);
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
            Filtering.Active.RemoveFilter(id);
        }

        //Adds a new BOM into the program

        public string addNews(string[] paths)
        {
            int good=0,bad=0;
            string res;
            for (int i = 0; i < paths.Length; i++)
            {
                if (addNew(paths[i]))
                {
                    bad++;
                }
                else
                {
                    good++;
                }
            }
            return res = makeresult(good, bad);
        }

        private bool addNew(string path)
        {
            using (MachinePrepper prepit = new MachinePrepper(path, ref machines))
            {
                if (!prepit.Duplic)
                {
                    addRaw(prepit.BomStream);
                    Filtering.Active.AddFilter(machines[machines.Count - 1].Id);
                    addTree();
                    Filtering.addMachine(machines[machines.Count - 1]);
                }
                return prepit.Duplic;
            }
        }

        private string makeresult(int good,int bad)
        {
            string res;
            string file = "file";
            if(good + bad > 1)
            {
                file += "s";
            }
            if (bad == 0)
            {
                res = "The "+file+" has been loaded successfully!";
            }
            else if(good == 0)
            {
                res = "The Bom handler already contains the "+file;
            }
            else
            {
                file = "file";
                if (good > 1)
                {
                    file += "s";
                }
                res = "The file reading was successfull!\n"+good+" "+file+" has been readed\n";
                file = "file";
                if (bad > 1)
                {
                    file += "s";
                }
                res += bad+" "+file+" was not readed due to duplication!";
            }
            return res;
        }

        //Adds raw data into the Bom

        private void addRaw(FileReader thisbomread)
        {
            using (RawPrepper prepit = new RawPrepper())
            {
                machines[machines.Count - 1].Raws = prepit.prepper(thisbomread);
            }
        }

        //Makes the BOM relational with the inclusion of pointers to its child nodes

        private void addTree()
        {
            using (BomPrepper prepit = new BomPrepper())
            {
                machines[machines.Count - 1].Parts = prepit.prepper(machines[machines.Count - 1].Raws);
            }
        }
    }
}
