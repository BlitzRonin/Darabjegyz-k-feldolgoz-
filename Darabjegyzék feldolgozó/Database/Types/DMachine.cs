using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Darabjegyzék_feldolgozó.Database.Types
{
    public class DMachine
    {
        public List<MainPart> MainParts { get { return mainparts; } }
        public string Id {  get { return id; } }

        private List<MainPart> mainparts;
        private string id;

        public DMachine(string id) 
        {
            this.id = id;
        }

        public void AddMainPart(int level, string name)
        {
            if (mainparts == null)
            {
                mainparts = new List<MainPart>();
            }
            mainparts.Add(new MainPart(level, name));
        }
    }
}
