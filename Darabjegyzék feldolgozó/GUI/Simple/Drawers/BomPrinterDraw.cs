using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.GUI.Other;

namespace Darabjegyzék_feldolgozó.GUI.Simple.Drawers
{
    public class BomPrinterDraw : IDrawer
    {
        public string NameOfFunc { get { return "Bom Fadiagram"; } }

        private FilterGUIHandler filter;

        public void LinkFilter(FilterGUIHandler filter,TabControl Tab)
        {
            this.filter = filter;
            Tab.SelectedIndexChanged += filterwrite;
        }

        public void Drawer(TabControl Tab, ToolStrip filtermenu, DatabaseInterface @interface)
        {
            Tab.TabPages.Clear();
            for (int i =0;i<@interface.Machines.Count;i++)
            {
                if (filter.Filter.Active[@interface.Machines[i].Id])
                {
                    Tab.TabPages.Add(new TabPage());
                    Tab.TabPages[Tab.TabCount - 1].Text = @interface.Machines[i].Id;
                    DrawOne(@interface.Machines[i].Parts, Tab.TabPages[Tab.TabCount - 1]);  
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

        private void DrawOne(List<Part> thisparts,TabPage page)
        {
            TreeView TreeView = new TreeView();
            TreeView.Dock = DockStyle.Fill;
            page.Controls.Add(TreeView);
            TreeView.Nodes.Clear();
            TreeView.BeginUpdate();
            for(int i = 0;i<thisparts.Count;i++)
            {
                printpart(thisparts[i], TreeView.Nodes);
                if (thisparts[i].Parts != null)
                {
                    DrawOne(ref thisparts[i].Parts, TreeView.Nodes[i]);
                }
            }
            TreeView.EndUpdate();
        }

        private void DrawOne(ref List<Part> parts,TreeNode thisnode)
        {
            for(int i = 0;i<parts.Count;i++)
            {
                printpart(parts[i],thisnode);
                if (parts[i].Parts != null)
                {
                    DrawOne(ref parts[i].Parts, thisnode.Nodes[i]);
                }
            }
        }

        private void printpart(Part thispart, TreeNode part)
        {
            string name = "Level: " + thispart.Level + "; Mat-No/Doc: " + thispart.Id + "; Docu-No/He: " + thispart.Serial;
            string subs = "Item: " + thispart.Item + "; Quantity: " + thispart.Quantity + "; UM: " + thispart.UM + "; Kind: " + thispart.Kind + "; PTYP: " + thispart.PTYP + "; Valid From: ";
            if (thispart.Validfrom != null)
            {
                subs += thispart.Validfrom.Value.Date.Year + "." + thispart.Validfrom.Value.Date.Month + "." + thispart.Validfrom.Value.Date.Day;
            }
            subs += "; Valid To: ";
            if (thispart.Validto != null)
            {
                subs += thispart.Validto.Value.Date.Year + "." + thispart.Validto.Value.Date.Month + "." + thispart.Validto.Value.Date.Day;
            }
            part.Nodes.Add(name);
            part.Nodes[part.Nodes.Count - 1].Nodes.Add(subs);
        }

        private void printpart(Part thispart, TreeNodeCollection part)
        {
            string name = "Level: " + thispart.Level + "; Mat-No/Doc: " + thispart.Id + "; Docu-No/He: " + thispart.Serial;
            string subs = "Item: " + thispart.Item + "; Quantity: " + thispart.Quantity + "; UM: " + thispart.UM + "; Kind: " + thispart.Kind + "; PTYP: " + thispart.PTYP + "; Valid From: ";
            if (thispart.Validfrom != null)
            {
                subs += thispart.Validfrom.Value.Date.Year + "." + thispart.Validfrom.Value.Date.Month + "." + thispart.Validfrom.Value.Date.Day;
            }
            subs += "; Valid To: ";
            if (thispart.Validto != null)
            {
                subs += thispart.Validto.Value.Date.Year + "." + thispart.Validto.Value.Date.Month + "." + thispart.Validto.Value.Date.Day;
            }
            part.Add(name);
            part[part.Count - 1].Nodes.Add(subs);
        }
    }
}
