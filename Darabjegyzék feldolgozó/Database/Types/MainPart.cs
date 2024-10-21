using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Darabjegyzék_feldolgozó.Database.Types
{
    public class MainPart
    {
        public Part Main { get { return main; } }
        public List<Part> SubParts { get { return parts; } }

        private List<Part> parts;
        private Part main;

        public MainPart(int level, string name)
        {
            main = new Part(level, name);
        }

        public void AddSubPart(int level, string name) 
        {
            if (parts == null)
            {
                parts = new List<Part>();
            }
            parts.Add(new Part(level, name));
        }
    }
    
}
