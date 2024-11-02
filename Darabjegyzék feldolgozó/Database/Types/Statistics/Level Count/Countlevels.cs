using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Statistics
{
    public class Countlevels
    {
        public int Level { get; }
        public int Count { get { return count; } }
        public int Zeroes { get { return zeroes; } }

        protected int count;
        protected int zeroes;

        public Countlevels(int level)
        {
            Level = level;
            count = 0;
            zeroes = 0;
        }

        public void countzero()
        {
            zeroes++;
        }

        public void countlevel()
        {
            count++;
        }
    }
}
