using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Filters
{
    public class ActiveFilter
    {
        private Dictionary<string, bool> actives;
        public ActiveFilter() 
        { 
            actives = new Dictionary<string, bool>();
        }

        public void addActive(string id)
        {
            actives.Add(id, true);
        }

        public void setActive(string id)
        {
            if (actives[id])
            {
                actives[id] = false;
            }
            else
            {
                actives[id] = true;
            }
        }

        public void removeActive(string id)
        {
            actives.Remove(id);
        }

        public bool filterActive(string id)
        {
            return actives[id];
        }
    }
}
