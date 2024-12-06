using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;
using Darabjegyzék_feldolgozó.Factories.Statistics;
using Darabjegyzék_feldolgozó.GUI.Other;

namespace Darabjegyzék_feldolgozó.GUI.Simple.Drawers
{
    public class CommonPrinterDraw : IDrawer
    {
        public string NameOfFunc { get { return "Elemek Gyakorisága"; } }

        private FilterGUIHandler filter;

        public void LinkFilter(FilterGUIHandler filter,TabControl Tab)
        {
            this.filter = filter;
            Tab.SelectedIndexChanged += filterwrite;
        }

        public void Drawer(TabControl Tab, ToolStrip filtermenu, DatabaseInterface @interface)
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
            using (CommonCounter counter = new CommonCounter(machine.Raws, filter.Filter))
            {
                List<CountCommon> count = counter.dothecount(machine.Id);
                ListView thisListView = setListView(counter.HowMuchLVL);
                page.Controls.Add(thisListView);
                thisListView.Items.Clear();
                thisListView.BeginUpdate();
                for (int i = 0; i < count.Count; i++)
                {
                    thisListView.Items.Add(setItem(count[i],counter.HowMuchLVL));
                }
                thisListView.EndUpdate();
            }
        }

        private ListViewItem setItem(CountCommon thiscommon,int howmuchlvl)
        {
            ListViewItem item = new ListViewItem(thiscommon.Id);
            for (int i = 0; i < howmuchlvl; i++)
            {
                if (thiscommon.Levels.ContainsKey(i+1))
                {
                    item.SubItems.Add(thiscommon.Levels[i+1].ToString());
                }
                else
                {
                    item.SubItems.Add("0");
                }
            }
            if(thiscommon.Zero)
            {
                item.SubItems.Add("Yes");
            }
            else
            {
                item.SubItems.Add("No");
            }
            return item;
        }

        private ListView setListView(int howmuchlvl)
        {
            ListView listView = new ListView();
            listView.GridLines = true;
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.Columns.Add("ID", 100);
            for(int i = 0; i< howmuchlvl; i++)
            {
                string lvl = (i+1).ToString()+".szint";
                listView.Columns.Add(lvl, 70);
            }
            listView.Columns.Add("Zero", 130);
            return listView;
        }
    }
}
