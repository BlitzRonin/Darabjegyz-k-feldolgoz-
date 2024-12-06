using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Filters
{
    public class Filter
    {
        public int Count { get { return filter.Count; } }
        public bool Filtered { get { return filtered; } }

        private Dictionary<string, bool> filter;
        private bool filtered;
        public Filter()
        {
            filter = new Dictionary<string, bool>();
            filtered = false;
        }

        public bool this[string id]
        {
            get { return filter[id]; }
        }

        public KeyValuePair<string, bool> ElementAtIndex(int index)
        {
            return filter.ElementAt(index);
        }


        public void AddFilter(string id)
        {
            if (!filter.ContainsKey(id))
            {
                filter.Add(id,true);
            }
        }

        public void setFilter(string id)
        {
            if (filter[id])
            {
                filter[id] = false;
            }
            else
            {
                filter[id] = true;
            }
        }

        public void RemoveFilter(string id)
        {
            filter.Remove(id);
        }

        public void ResetFilter()
        {
            for (int i = 0; i < filter.Count; i++)
            {
                filter[filter.ElementAt(i).Key] = true;
            }
        }
    }
}
