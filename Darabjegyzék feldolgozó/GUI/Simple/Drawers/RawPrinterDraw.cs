using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.GUI.Other;
namespace Darabjegyzék_feldolgozó.GUI.Simple.Drawers
{
    public class RawPrinterDraw : IDrawer
    {
        public string NameOfFunc { get { return "Nyers Adatok"; } }

        private FilterGUIHandler filter;

        public void LinkFilter(FilterGUIHandler filter,TabControl Tab)
        {
            this.filter = filter;
            Tab.SelectedIndexChanged += filterwrite;
        }

        public void Drawer(TabControl Tab , ToolStrip filtermenu, DatabaseInterface @interface)
        {
            Tab.TabPages.Clear();
            for (int i = 0; i < @interface.Machines.Count; i++)
            {
                if (filter.Filter.Active[@interface.Machines[i].Id])
                {
                    Tab.TabPages.Add(new TabPage());
                    Tab.TabPages[Tab.TabCount - 1].Text = @interface.Machines[i].Id;
                    DrawOne(@interface.Machines[i].Raws, Tab.TabPages[Tab.TabCount - 1]);
                }          
            }
            if (Tab.TabCount != 0)
            {
                filter.fillfilter(Tab.SelectedTab.Text, Tab.TabCount);
            }
        }

        private void filterwrite(object sender,EventArgs e)
        {
            TabControl TempTab = (TabControl)sender;
            if (TempTab.TabCount != 0)
            {
                filter.fillfilter(TempTab.SelectedTab.Text, TempTab.TabCount);
            }
        }

        private void DrawOne(List<Raw> thisraw, TabPage page)
        {
            ListView thisListView = setListView();
            page.Controls.Add(thisListView);
            thisListView.Items.Clear();
            thisListView.BeginUpdate();
            for (int i = 0; i < thisraw.Count; i++)
            {
                thisListView.Items.Add(setItem(thisraw[i]));
            }
            thisListView.EndUpdate();
        }

        private ListViewItem setItem(Raw raw)
        {
            ListViewItem item = new ListViewItem(raw.Id);
            item.SubItems.Add(raw.Serial);
            item.SubItems.Add(raw.Level.ToString());
            item.SubItems.Add(raw.Item.ToString());
            item.SubItems.Add(raw.Quantity.ToString());
            item.SubItems.Add(raw.UM);
            item.SubItems.Add(raw.Kind.ToString());
            item.SubItems.Add(raw.PTYP.ToString());
            item.SubItems.Add(raw.Validfrom.ToString());
            item.SubItems.Add(raw.Validto.ToString());
            return item;
        }

        private ListView setListView()
        {
            ListView listView = new ListView();
            listView.GridLines = true;
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.Columns.Add("ID", 100);
            listView.Columns.Add("Serial", 130);
            listView.Columns.Add("Level", -2);
            listView.Columns.Add("Item", -2);
            listView.Columns.Add("Quantity", -2);
            listView.Columns.Add("UM", -2);
            listView.Columns.Add("Kind", -2);
            listView.Columns.Add("PTYP", -2);
            listView.Columns.Add("Validfrom", 130);
            listView.Columns.Add("Validto", 130);
            return listView;
        }
    }
}
