using Darabjegyzék_feldolgozó.Database.File;
using Darabjegyzék_feldolgozó.Database.Types.Machines;

namespace Darabjegyzék_feldolgozó.Factories.Preppers
{
    public class MachinePrepper : IDisposable
    {
        public bool Duplic { get { return duplic; } }
        public FileReader BomStream { get { return bomstream; } }

        private bool duplic;
        private FileReader bomstream;

        public MachinePrepper(string path, ref List<DMachine> machines)
        {
            string name = path.Split('\\').Last().Split('.')[0];
            duplic = exist(name, machines);
            if(!duplic)
            {
                machines.Add(new DMachine(name));
                bomstream = new FileReader(path);
            }
        }

        private bool exist(string name, List<DMachine> machines)
        {
            for (int i = 0; i < machines.Count; i++)
            {
                if (machines[i].Id == name)
                {
                    return true;
                }
            }
            return false;
        }

        public void Dispose()
        {

        }
    }
}
