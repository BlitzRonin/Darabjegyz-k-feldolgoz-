using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Filters
{
    public class FilterSetterArgs : EventArgs
    {
        public FilterSetterArgs(List<string> filters,string type,List<string> machine)
        { 
            this.filters = filters;
            this.type = type;
            this.machine = machine;
        }

        public List<string> filters {  get; }
        public string type { get; }
        public List<string> machine { get; }
    }
}
