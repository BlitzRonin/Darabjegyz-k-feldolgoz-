using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factories.Statistics
{
    //This class counts how many instances of distinct elements are in a bom and on wich level
    public class CommonCounter : IDisposable
    {
        public int HowMuchLVL { get { return howmuchlvl; } }
        private FilterHandler filter;
        private List<Raw> @interface;
        private int howmuchlvl;
        public CommonCounter(List<Raw> raws,FilterHandler filter)
        {
            @interface = raws;
            this.filter = filter;
        }

        public List<CountCommon> dothecount(string id)
        {
            List<CountCommon> commons = new List<CountCommon>();
            for (int i = 0; i < @interface.Count; i++)
            {
                if(filter.filterElement(id, @interface[i]))
                {
                    int index;
                    if ((index = Exist(@interface[i].Id, commons)) >= 0)
                    {
                        if (@interface[i].Level == 0)
                        {
                            for (int j = i; j > 0; j--)
                            {
                                if (@interface[j].Level != 0)
                                {
                                    commons[index].countit(@interface[i].Quantity, @interface[j].Level);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            commons[index].countit(@interface[i].Quantity, @interface[i].Level);
                        }
                    }
                    else
                    {
                        commons.Add(new CountCommon(@interface[i].Id, @interface[i].Level, @interface[i].Quantity));
                        if (@interface[i].Level == 0)
                        {
                            for (int j = i; j > 0; j--)
                            {
                                if (@interface[j].Level != 0)
                                {
                                    commons[commons.Count - 1].countit(@interface[i].Quantity, @interface[j].Level);
                                }
                            }
                        }
                    }
                    if (howmuchlvl < @interface[i].Level)
                    {
                        howmuchlvl = @interface[i].Level;
                    }
                }
            }
            return commons;
        }

        private int Exist(string id,List<CountCommon> commons)
        { 
            for(int i = 0;i<commons.Count;i++)
            {
                if(id == commons[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Dispose()
        {

        }
    }
}
