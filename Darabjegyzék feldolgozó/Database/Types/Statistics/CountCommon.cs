using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Statistics
{
    //This type contains the commonality data of each distinct elements
    public class CountCommon
    {
        public string Id { get; }
        public bool Zero { get; }
        public Dictionary<int,int> Levels { get { return levels; } }

        private Dictionary<int, int> levels;

        public CountCommon(string id,int level)
        {
            Id = id;
            levels = new Dictionary<int, int>();
            if(level != 0)
            {
                countit(level);
                Zero = false;
            }
            else
            {
                Zero = true;
            }
        }

        public void countit(int level)
        {
            if (!levels.ContainsKey(level))
            {
                levels.Add(level,1);
            }
            else
            {
                levels[level]++;
            }
        }
    }
}
