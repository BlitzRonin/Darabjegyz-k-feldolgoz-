using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;
using Darabjegyzék_feldolgozó.Factories.Statistics.Counter.Linear;
using Darabjegyzék_feldolgozó.Factories.Statistics.Counter.Tree;
using System.Windows.Forms;
using Darabjegyzék_feldolgozó.GUI.Other;

namespace Darabjegyzék_feldolgozó.GUI.Simple.Drawers
{
    public class LevelPrinterDraw : IDrawer
    {
        public string NameOfFunc { get { return "Szint Kimutatás"; } }

        private FilterGUIHandler filter;

        public void LinkFilter(FilterGUIHandler filter,TabControl Tab)
        {
            this.filter = filter;
            Tab.SelectedIndexChanged += filterwrite;
        }

        public void Drawer(TabControl Tab ,ToolStrip filtermenu, DatabaseInterface @interface)
        {
            Tab.TabPages.Clear();
            for (int i = 0; i < @interface.Machines.Count; i++)
            {
                if (filter.Filter.Active[@interface.Machines[i].Id])
                {
                    Tab.TabPages.Add(new TabPage());
                    Tab.TabPages[Tab.TabCount - 1].Text = @interface.Machines[i].Id;
                    DrawOne(@interface.Machines[i], Tab.TabPages[Tab.TabCount - 1]);
                }
            }
            if (Tab.TabCount != 0)
            {
                filter.fillfilter(Tab.SelectedTab.Text, Tab.TabCount);
            }
        }

        private void filterwrite(object sender, EventArgs e)
        {
            TabControl TempTab = (TabControl)sender;
            if (TempTab.TabCount != 0)
            {
                filter.fillfilter(TempTab.SelectedTab.Text, TempTab.TabCount);
            }
        }

        private void DrawOne(DMachine machine, TabPage page)
        {
            SplitContainer contain = new SplitContainer();
            contain.Dock = DockStyle.Fill;
            page.Controls.Add(contain);
            using (CountTree counter = new CountTree(machine.Parts, filter.Filter))
            {
                contain.Panel2.Controls.Add(drawtree(counter.count(machine.Id)));
            }
            using (CountLinear linear = new CountLinear(machine.Raws))
            {
                contain.Panel1.Controls.Add(drawlist(linear.dothecount(machine.Id,filter.Filter)));
            }
        }

        private TreeView drawtree(List<CountNode> counted)
        {
            TreeView TreeView = new TreeView();
            TreeView.Dock = DockStyle.Fill;
            TreeView.Nodes.Clear();
            TreeView.BeginUpdate();
            for (int i = 0; i < counted.Count; i++)
            {
                printpart(TreeView.Nodes, counted[i]);
                if (counted[i].node != null)
                {
                    drawtree(ref counted[i].node, TreeView.Nodes[i]);
                }
            }
            TreeView.EndUpdate();
            return TreeView;
        }

        private void drawtree(ref List<CountNode> counted, TreeNode thisnode)
        {
            for (int i = 0; i < counted.Count; i++)
            {
                printpart(thisnode, counted[i]);
                if (counted[i].node != null)
                {
                    drawtree(ref counted[i].node, thisnode.Nodes[i]);
                }
            }
        }


        private void printpart(TreeNode part, CountNode thispart)
        {
            string name = "Name: " + thispart.Id + " Level: " + thispart.Level + " Conted: " + thispart.Count + " Zeroes: " + thispart.Zeroes;
            part.Nodes.Add(name);
        }

        private void printpart(TreeNodeCollection part, CountNode thispart)
        {
            string name = "Name: " + thispart.Id + " Level: " + thispart.Level + " Conted: " + thispart.Count + " Zeroes: " + thispart.Zeroes;
            part.Add(name);
        }

        private ListView drawlist(List<Countlevels> levels)
        {
            ListView thisListView = setListView();
            thisListView.Items.Clear();
            thisListView.BeginUpdate();
            for (int i = 0; i < levels.Count; i++)
            {
                thisListView.Items.Add(setItem(levels[i]));
            }
            thisListView.EndUpdate();
            return thisListView;
        }

        private ListViewItem setItem(Countlevels count)
        {
            ListViewItem item = new ListViewItem(count.Level.ToString());
            item.SubItems.Add(count.Count.ToString());
            item.SubItems.Add(count.Zeroes.ToString());
            return item;
        }

        private ListView setListView()
        {
            ListView listView = new ListView();
            listView.GridLines = true;
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.Columns.Add("Levels", 70);
            listView.Columns.Add("Count", 70);
            listView.Columns.Add("Zeroes", 70);
            return listView;
        }
    }
}
