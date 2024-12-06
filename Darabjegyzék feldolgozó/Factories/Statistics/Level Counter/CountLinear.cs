using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factories.Statistics.Counter.Linear
{
    //This Class counts the Levels in a Raw
    public class CountLinear : IDisposable
    {
        private List<Raw> @interface;
        public CountLinear(List<Raw> raws)
        {
            @interface = raws;
        }

        public List<Countlevels> dothecount(string id,FilterHandler filter)
        {
            List<Countlevels> levels = new List<Countlevels>();
            for (int i = 0; i < @interface.Count; i++)
            {
                if (filter.filterElement(id,@interface[i]))
                {
                    if (@interface[i].Level > levels.Count)
                    {
                        levels.Add(new Countlevels(@interface[i].Level));
                    }
                    if (@interface[i].Level == 0)
                    {
                        for (int j = i; j > 0; j++)
                        {
                            if (@interface[j].Level != 0)
                            {
                                levels[@interface[j].Level - 1].countzero();
                                break;
                            }
                        }
                    }
                    else
                    {
                        levels[@interface[i].Level - 1].countlevel();
                    }
                }    
            }
            return levels;
        }

        public void Dispose()
        { 
        
        }
    }
}
