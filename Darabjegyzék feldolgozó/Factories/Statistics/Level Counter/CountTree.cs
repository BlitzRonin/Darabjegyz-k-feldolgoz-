using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factories.Statistics.Counter.Tree
{
    //This class counts the levels individually and reletaionally binds them
    public class CountTree : IDisposable
    {
        private List<CountNode> basecount;
        private List<Part> basepart;
        public CountTree(List<Part> basepart)
        {
            this.basepart = basepart;
        }

        public List<CountNode> count(string id)
        {
            basecount = [new CountNode(id,1)];
            makeCount(ref basepart,ref basecount);
            return basecount;
        }

        private void makeCount(ref List<Part> currpart ,ref List<CountNode> currcount)
        {
            for (int i = 0; i < currpart.Count; i++)
            {
                if (currpart[i].Level == 0)
                {
                    currcount[currcount.Count-1].countzero();
                }
                else
                {
                    currcount[currcount.Count-1].countlevel();
                }
                if (currpart[i].Parts != null)
                {
                    if(currcount[currcount.Count-1].node == null)
                    {
                        currcount[currcount.Count-1].node = [new CountNode(currpart[i].Id, currpart[i].Parts[0].Level)];
                    }
                    else
                    {
                        currcount[currcount.Count-1].node.Add(new CountNode(currpart[i].Id, currpart[i].Parts[0].Level));
                    }
                    makeCount(ref currpart[i].Parts,ref currcount[currcount.Count-1].node);
                }
            }
        }

        public void Dispose()
        {

        }
    }
}
