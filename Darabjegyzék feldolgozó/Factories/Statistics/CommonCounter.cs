using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factories.Statistics
{
    public class CommonCounter : IDisposable
    {
        private List<Raw> @interface;
        public CommonCounter(List<Raw> raws)
        {
            @interface = raws;
        }

        public List<CountCommon> dothecount()
        {
            List<CountCommon> commons = new List<CountCommon>();
            for (int i = 0; i < @interface.Count; i++)
            {
                int index;
                if ((index = Exist(@interface[i].Id,commons)) >= 0)
                {
                    commons[index].countit(@interface[i].Level);
                }
                else
                {
                    commons.Add(new CountCommon(@interface[i].Id, @interface[i].Level));
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
