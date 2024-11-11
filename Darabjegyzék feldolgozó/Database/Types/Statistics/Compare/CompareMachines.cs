using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database.Types.Machines;

namespace Darabjegyzék_feldolgozó.Database.Types.Statistics.Compare
{
    public class CompareMachines
    {
        public string Id { get; }
        private List<CompareElements> elements;
        public CompareMachines(string id) 
        {
            Id = id;
            elements = new List<CompareElements>();
        }

        public void AddElement(string path,Part part)
        {
            elements.Add(new CompareElements(path,part));
        }
    }
}
