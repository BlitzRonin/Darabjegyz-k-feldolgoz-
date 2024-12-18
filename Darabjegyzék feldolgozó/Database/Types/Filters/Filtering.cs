using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Filters
{
    public class Filtering
    {
        private Dictionary<string, Filter> filter;
        public Filtering() 
        {
            filter = new Dictionary<string,Filter>();
        }

        public Filter this [string id]
        {
            get { return filter[id]; }
        }

        public KeyValuePair<string,Filter> ElementAtIndex(int index)
        {
            return filter.ElementAt(index);
        }

        public void AddFilter(string id)
        {
            filter.Add(id,new Filter());
        }

        public void RemoveFilter(string id)
        {
            filter.Remove(id);
        }

        public bool Contains(string id)
        {
            return filter.ContainsKey(id);
        }
    }
}
