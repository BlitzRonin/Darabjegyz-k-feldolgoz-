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
        public bool Zero { get; set; }
        public Dictionary<int,double> Levels { get { return levels; } }

        private Dictionary<int, double> levels;

        public CountCommon(string id)
        {
            Id = id;
            levels = new Dictionary<int, double>();
        }

        public void countit(double input,int level)
        {
            if (!levels.ContainsKey(level))
            {
                levels.Add(level,input);
            }
            else
            {
                levels[level] += input;
            }
        }
    }
}
