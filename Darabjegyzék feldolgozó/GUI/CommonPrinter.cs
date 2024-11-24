using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;
using Darabjegyzék_feldolgozó.Factories.Statistics;
using Darabjegyzék_feldolgozó.GUI.BomList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Darabjegyzék_feldolgozó.GUI.CommonListing
{
    public partial class CommonPrinter : UserControl
    {
        DatabaseInterface @interface;

        public CommonPrinter(DatabaseInterface @interface)
        {
            InitializeComponent();
            filterMenu1.setfilter(@interface.Filtering);
        }

        public void Printthis(DatabaseInterface @interface)
        {
            this.@interface = @interface;
            filltree();
            BringToFront();
        }

        private void filltree()
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            for (int i = 0; i < @interface.Machines.Count; i++)
            {
                if (@interface.Filtering.filterActive(@interface.Machines[i].Id))
                {
                    treeView1.Nodes.Add(@interface.Machines[i].Id);
                    using (CommonCounter counter = new CommonCounter(@interface.Machines[i].Raws,@interface.Filtering))
                    {
                        List<CountCommon> count = counter.dothecount();
                        for (int j = 0; j < count.Count; j++)
                        {
                            printpart(treeView1.Nodes[treeView1.Nodes.Count - 1], count[j]);
                        }
                    }
                }
            }
            treeView1.EndUpdate();
        }

        private void printpart(TreeNode part, CountCommon thiscommon)
        {
            string line = "ID: " + thiscommon.Id + " ";
            for (int i = 0; i < thiscommon.Levels.Count; i++)
            {
                line += "Level " + thiscommon.Levels.ElementAt(i).Key + ": " + thiscommon.Levels.ElementAt(i).Value + "; ";
            }
            line += "Zero?: ";
            if (thiscommon.Zero)
            {
                line += "Yes;";
            }
            else
            {
                line += "No;";
            }
            part.Nodes.Add(line);

        }
    }
}

