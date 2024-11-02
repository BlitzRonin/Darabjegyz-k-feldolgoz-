using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Statistics
{
    public class CountNode : Countlevels
    {
        public string Id { get; }
        public List<CountNode> node;

        public CountNode(string id,int level) : base(level)
        {
            Id = id;
        }
    }
}
