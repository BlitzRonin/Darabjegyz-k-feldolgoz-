using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;
using Darabjegyzék_feldolgozó.Factories.Statistics.Counter.Linear;
using Darabjegyzék_feldolgozó.Factories.Statistics.Counter.Tree;

namespace Darabjegyzék_feldolgozó.GUI.LevelList
{
    public class LevelTree : IDisposable
    {
        private DatabaseInterface @interface;

        public LevelTree(DatabaseInterface @interface)
        {
            this.@interface = @interface;
        }

        public void buildList(TreeView tree)
        {
            tree.Nodes.Clear();
            tree.BeginUpdate();
            for (int i = 0; i < @interface.Machines.Count; i++)
            {
                if (@interface.Filtering.filterActive(@interface.Machines[i].Id))
                {
                    tree.Nodes.Add(@interface.Machines[i].Id);
                    using (CountLinear linear = new CountLinear(@interface.Machines[i].Raws))
                    {
                        List<Countlevels> levels = linear.dothecount();
                        for (int j = 0; j < levels.Count; j++)
                        {
                            tree.Nodes[tree.Nodes.Count - 1].Nodes.Add("Levels: " + levels[j].Level.ToString() + "; Count: " + levels[j].Count + "; Zeroes: " + levels[j].Zeroes);
                        }
                    }
                }
            }
            tree.EndUpdate();
        }

        public void buildTree(TreeView tree)
        {
            tree.Nodes.Clear();
            tree.BeginUpdate();
            for (int i = 0; i < @interface.Machines.Count; i++)
            {
                if (@interface.Filtering.filterActive(@interface.Machines[i].Id))
                {
                    using (CountTree counter = new CountTree(@interface.Machines[i].Parts))
                    {
                        List<CountNode> counted = counter.count(@interface.Machines[i].Id);
                        string name = "Name: " + counted[0].Id + "; Level: " + counted[0].Level + "; Counted: " + counted[0].Count + "; Zeroes: " + counted[0].Zeroes;
                        tree.Nodes.Add(name);
                        makeTree(tree.Nodes[i], ref counted[0].node);
                    }
                }
            }
            tree.EndUpdate();
        }


        private void makeTree(TreeNode currtree, ref List<CountNode> currdata)
        {
            for (int i = 0; i < currdata.Count; i++)
            {
                printpart(currtree, currdata[i]);
                //MessageBox.Show(currdata.Count.ToString());
                if (currdata[i].node != null)
                {
                    makeTree(currtree.Nodes[i], ref currdata[i].node);
                }
            }
        }

        private void printpart(TreeNode part, CountNode thispart)
        {
            string name = "Name: " + thispart.Id + " Level: "+thispart.Level+" Conted: "+thispart.Count+" Zeroes: "+thispart.Zeroes;
            part.Nodes.Add(name);
        }

        public void Dispose()
        {

        }
    }
}
