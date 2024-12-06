using Darabjegyzék_feldolgozó.Database.Types.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darabjegyzék_feldolgozó.GUI.Other
{
    public class FilterGUIHandler
    {
        public FilterHandler Filter { get; }

        public ToolStrip filtermenu;
        private event EventHandler setfilter;
        private IFilterable parent;
        private string lasttab1,lasttab2;

        public FilterGUIHandler(ToolStrip filtermenu, FilterHandler filter,EventHandler filterreset, IFilterable parent)
        {
            this.filtermenu = filtermenu;
            this.parent = parent;
            Filter = filter;
            filtermenu.Items["Resetbutton"].Click += parent.Resetbutton_Click;
            filterreset += Filter.resetFilter;
            setfilter += Filter.setElement;
        }

        public async void fillfilter(string id,int counter)
        {
            if(counter != 0 && lasttab1 != id)
            {
                lasttab1 = id;
                await Task.Run(() => fillcategories("IDmenu", Filter.Id[id]));
                await Task.Run(() => fillcategories("Levelmenu", Filter.Level[id]));
                await Task.Run(() => fillcategories("Serialmenu", Filter.Serial[id]));
                await Task.Run(() => fillcategories("Itemmenu", Filter.Item[id]));
                await Task.Run(() => fillcategories("Quantitymenu", Filter.Quantity[id]));
                await Task.Run(() => fillcategories("UMmenu", Filter.UM[id]));
                await Task.Run(() => fillcategories("Kindmenu", Filter.Kind[id]));
                await Task.Run(() => fillcategories("PTYPmenu", Filter.PTYP[id]));
                await Task.Run(() => fillcategories("Validfrommenu", Filter.Validfrom[id]));
                await Task.Run(() => fillcategories("Validtomenu", Filter.Validto[id]));
            }
        }

        public async void fillfilter(string id1,string id2)
        {
            if (lasttab1 != id1 && lasttab2 != id2)
            {
                lasttab1 = id1;
                lasttab2 = id2;
                await Task.Run(() => fillcategories("IDmenu", Filter.Id[id1], Filter.Id[id2]));
                await Task.Run(() => fillcategories("Levelmenu", Filter.Level[id1], Filter.Level[id2]));
                await Task.Run(() => fillcategories("Serialmenu", Filter.Serial[id1], Filter.Serial[id2]));
                await Task.Run(() => fillcategories("Itemmenu", Filter.Item[id1], Filter.Item[id2]));
                await Task.Run(() => fillcategories("Quantitymenu", Filter.Quantity[id1], Filter.Quantity[id2]));
                await Task.Run(() => fillcategories("UMmenu", Filter.UM[id1], Filter.UM[id2]));
                await Task.Run(() => fillcategories("Kindmenu", Filter.Kind[id1], Filter.Kind[id2]));
                await Task.Run(() => fillcategories("PTYPmenu", Filter.PTYP[id1], Filter.PTYP[id2]));
                await Task.Run(() => fillcategories("Validfrommenu", Filter.Validfrom[id1], Filter.Validfrom[id2]));
                await Task.Run(() => fillcategories("Validtomenu", Filter.Validto[id1], Filter.Validto[id2]));
            }
        }

        private void fillcategories(string category, Filter filter)
        {
            if (filtermenu.InvokeRequired)
            {
                filtermenu.Invoke(new Action<string,Filter>(fillcategories), [category, filter]);
            }
            else
            {
                ToolStripDropDownButton thisbutton = (ToolStripDropDownButton)filtermenu.Items[category];
                thisbutton.DropDownItems.Clear();
                for (int i = 0; i < filter.Count; i++)
                {
                    thisbutton.DropDownItems.Add(addfilter(filter.ElementAtIndex(i).Key, filter.ElementAtIndex(i).Value, i, category));
                    thisbutton.DropDownItems[thisbutton.DropDownItems.Count - 1].Click += flipit;

                }
            }
        }



        private void fillcategories(string category, Filter filter1,Filter filter2)
        {
            if (filtermenu.InvokeRequired)
            {
                filtermenu.Invoke(new Action<string, Filter,Filter>(fillcategories), [category, filter1,filter2]);
            }
            else
            {
                ToolStripDropDownButton thisbutton = (ToolStripDropDownButton)filtermenu.Items[category];
                thisbutton.DropDownItems.Clear();
                for (int i = 0; i < filter1.Count; i++)
                {
                    thisbutton.DropDownItems.Add(addfilter(filter1.ElementAtIndex(i).Key, filter1.ElementAtIndex(i).Value, i, category));
                    thisbutton.DropDownItems[thisbutton.DropDownItems.Count - 1].Click += flipit;
                }
                for (int i = 0; i < filter2.Count; i++)
                {
                    thisbutton.DropDownItems.Add(addfilter(filter2.ElementAtIndex(i).Key, filter2.ElementAtIndex(i).Value, i, category));
                    thisbutton.DropDownItems[thisbutton.DropDownItems.Count - 1].Click += flipit;
                }
            }
        }

        private ToolStripMenuItem addfilter(string menuname, bool state, int num, string menucat)
        {
            ToolStripMenuItem thisfilter = new ToolStripMenuItem();
            thisfilter.Name = menucat + num;
            thisfilter.Text = menuname;
            if (state)
            {
                thisfilter.BackColor = Color.Green;
            }
            else
            {
                thisfilter.BackColor = Color.Red;
            }
            return thisfilter;
        }

        private void flipit(object sender, EventArgs args)
        {
            ToolStripMenuItem thismen = (ToolStripMenuItem)sender;
            if (thismen.BackColor == Color.Green)
            {
                thismen.BackColor = Color.Red;
            }
            else
            {
                thismen.BackColor = Color.Green;
            }
            parent.Filtername = ((ToolStripMenuItem)sender).Text;
            parent.Category = ((ToolStripMenuItem)sender).GetCurrentParent().Text;
            setfilter?.Invoke(parent, args);
        }
    }
}
