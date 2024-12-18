using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Darabjegyzék_feldolgozó.GUI.Other.Filters
{
    public class FilterGUIHandler
    {
        private Dictionary<string, FilterGUI> filterGUI;
        private FilterHandler filter;

        public FilterGUIHandler(FilterHandler filter)
        {
            this.filter = filter;
            filterGUI = new Dictionary<string, FilterGUI>
            {
                { "Level", new FilterGUI("Level",new Point(115, 50)) },
                { "Item", new FilterGUI("Item",new Point(152, 50)) },
                { "Quantitity", new FilterGUI("Quantitity",new Point(187, 50)) },
                { "UM", new FilterGUI("UM",new Point(245, 50)) },
                { "Id", new FilterGUI("Id",new Point(48, 50)) },
                { "Kind", new FilterGUI("Kind",new Point(276, 50)) },
                { "PTYP", new FilterGUI("PTYP",new Point(309, 50)) },
                { "Validfrom", new FilterGUI("Validfrom",new Point(344, 50)) },
                { "Validto", new FilterGUI("Validto",new Point(413, 50)) },
                { "Serial", new FilterGUI("Serial",new Point(74, 50)) }
            };
            voidsetevents();
        }

        private void voidsetevents()
        {
            for (int i = 0; i < filterGUI.Count; i++)
            {
                filterGUI.ElementAt(i).Value.FilterSetter += filter.setElement;
            }
        }

        public FilterGUI this[string type]
        {
            get { return filterGUI[type]; }
        }

        public void Set(string machineid, IPrinter currprinter)
        {
            settype(filter.Level[machineid], "Level", machineid, currprinter);
            settype(filter.Item[machineid], "Item", machineid, currprinter);
            settype(filter.Quantity[machineid], "Quantitity", machineid, currprinter);
            settype(filter.UM[machineid], "UM", machineid, currprinter);
            settype(filter.Id[machineid], "Id", machineid, currprinter);
            settype(filter.Kind[machineid], "Kind", machineid, currprinter);
            settype(filter.PTYP[machineid], "PTYP", machineid, currprinter);
            settype(filter.Validfrom[machineid], "Validfrom", machineid, currprinter);
            settype(filter.Validto[machineid], "Validto", machineid, currprinter);
            settype(filter.Serial[machineid], "Serial", machineid, currprinter);
        }

        public void Set(string machineid)
        {
            settype(filter.Level[machineid], "Level", machineid);
            settype(filter.Item[machineid], "Item", machineid);
            settype(filter.Quantity[machineid], "Quantitity", machineid);
            settype(filter.UM[machineid], "UM", machineid);
            settype(filter.Id[machineid], "Id", machineid);
            settype(filter.Kind[machineid], "Kind", machineid);
            settype(filter.PTYP[machineid], "PTYP", machineid);
            settype(filter.Validfrom[machineid], "Validfrom", machineid);
            settype(filter.Validto[machineid], "Validto", machineid);
            settype(filter.Serial[machineid], "Serial", machineid);
        }

        public void Clear()
        {
            filterGUI["Level"].ClearList();
            filterGUI["Item"].ClearList();
            filterGUI["Quantitity"].ClearList();
            filterGUI["UM"].ClearList();
            filterGUI["Id"].ClearList();
            filterGUI["Kind"].ClearList();
            filterGUI["PTYP"].ClearList();
            filterGUI["Validfrom"].ClearList();
            filterGUI["Validto"].ClearList();
            filterGUI["Serial"].ClearList();
        }

        private void settype(Filter filter, string type, string machine)
        {
            filterGUI[type].Readytofil = false;
            for (int i = 0; i < filter.Count; i++)
            {
                if (!filterGUI[type].ContainItem(filter.ElementAtIndex(i).Key))
                {
                    filterGUI[type].AddItem(filter.ElementAtIndex(i).Key, filter.ElementAtIndex(i).Value);
                }
            }
            filterGUI[type].Readytofil = true;
            filterGUI[type].machine.Add(machine);
        }

        private void settype(Filter filter, string type, string machine, IPrinter currprinter)
        {
            filterGUI[type].ClearList();
            for (int i = 0; i < filter.Count; i++)
            {
                filterGUI[type].AddItem(filter.ElementAtIndex(i).Key, filter.ElementAtIndex(i).Value);
            }
            filterGUI[type].Readytofil = true;
            filterGUI[type].currentprinter = currprinter;
            filterGUI[type].machine.Add(machine);
        }

        public string Show(string type)
        {
            filterGUI[type].setup();
            filterGUI[type].Visible = true;
            filterGUI[type].BringToFront();
            filterGUI[type].Select();
            return type;
        }

        public void Hide(string type,object sender)
        {
            filterGUI[type].FilterGUI_Leave(sender,EventArgs.Empty);
        }

        public void Reset(IPrinter thisprinter, string machineid)
        {
            filter.resetFilter(thisprinter, machineid);
        }

        public string State()
        {
            string state = "";
            state += onestate("Level");
            state += onestate("Item");
            state += onestate("Quantitity");
            state += onestate("UM");
            state += onestate("Id");
            state += onestate("Kind");
            state += onestate("PTYP");
            state += onestate("Validfrom");
            state += onestate("Validto");
            state += onestate("Serial");
            return state;
        }

        private string onestate(string type)
        {
            List<string> states = filterGUI[type].Checkstate();
            string state = "";
            for(int i = 0;i<states.Count;i++)
            {
                state += states[i] + " "+type+"\n";
            }
            return state;
        }
    }
}
