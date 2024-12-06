using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
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
        private FilterHandler filter;
        private List<CountNode> basecount;
        private List<Part> basepart;
        public CountTree(List<Part> basepart,FilterHandler filter)
        {
            this.basepart = basepart;
            this.filter = filter;
        }

        public List<CountNode> count(string id)
        {
            basecount = [new CountNode("",1)];
            makeCount(id,ref basepart,ref basecount);
            return basecount[0].node;
        }

        private void makeCount(string id,ref List<Part> currpart ,ref List<CountNode> currcount)
        {
            for (int i = 0; i < currpart.Count; i++)
            {
                if (filter.filterElement(id,currpart[i]))
                {
                    if (currpart[i].Level == 0)
                    {
                        currcount[currcount.Count - 1].countzero();
                    }
                    else
                    {
                        currcount[currcount.Count - 1].countlevel();
                    }
                    if (currpart[i].Parts != null)
                    {
                        if (currcount[currcount.Count - 1].node == null)
                        {
                            currcount[currcount.Count - 1].node = [new CountNode(currpart[i].Id, currpart[i].Parts[0].Level)];
                        }
                        else
                        {
                            currcount[currcount.Count - 1].node.Add(new CountNode(currpart[i].Id, currpart[i].Parts[0].Level));
                        }
                        makeCount(id,ref currpart[i].Parts, ref currcount[currcount.Count - 1].node);
                    }
                    else
                    {
                        if (currcount[currcount.Count - 1].node == null)
                        {
                            currcount[currcount.Count - 1].node = [new CountNode(currpart[i].Id, currpart[i].Level)];
                        }
                        else
                        {
                            currcount[currcount.Count - 1].node.Add(new CountNode(currpart[i].Id, currpart[i].Level));
                        }
                    }
                }
            }
        }

        public void Dispose()
        {

        }
    }
}
