using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.GUI;
using Darabjegyzék_feldolgozó.GUI.Other;

namespace Darabjegyzék_feldolgozó.Database.Types.Filters
{
    public class FilterHandler
    {
        public event EventHandler filteringevent;
        public Filter Active { get; }
        public Filtering Level { get; }
        public Filtering Item { get; }
        public Filtering Quantity { get; }
        public Filtering UM { get; }
        public Filtering Id { get; }
        public Filtering Kind { get; }
        public Filtering PTYP { get; }
        public Filtering Validfrom { get; }
        public Filtering Validto { get; }
        public Filtering Serial { get; }

        public FilterHandler() 
        { 
            Active = new Filter();
            Level = new Filtering();
            Item = new Filtering();
            Quantity = new Filtering();
            UM = new Filtering();
            Id = new Filtering();
            Kind = new Filtering();
            PTYP = new Filtering();
            Validfrom = new Filtering();
            Validto = new Filtering();
            Serial = new Filtering();
        }

        public void addMachine(DMachine machine)
        {
            List<string> level = new List<string>();
            List<string> item = new List<string>();
            List<string> quantity = new List<string>();
            List<string> um = new List<string>();
            List<string> id = new List<string>();
            List<string> kind = new List<string>();
            List<string> ptyp = new List<string>();
            List<string> validfrom = new List<string>();
            List<string> validto = new List<string>();
            List<string> serial = new List<string>();
            Active.AddFilter(machine.Id);
            Level.AddFilter(machine.Id);
            Item.AddFilter(machine.Id);
            Quantity.AddFilter(machine.Id);
            UM.AddFilter(machine.Id);
            Id.AddFilter(machine.Id);
            Kind.AddFilter(machine.Id);
            PTYP.AddFilter(machine.Id);
            Validfrom.AddFilter(machine.Id);
            Validto.AddFilter(machine.Id);
            Serial.AddFilter(machine.Id);
            for(int i = 0; i < machine.Raws.Count; i++)
            {
                Raw thisraw = machine.Raws[i];
                level.Add(thisraw.Level.ToString());
                item.Add(thisraw.Item.ToString());
                quantity.Add(thisraw.Quantity.ToString());
                um.Add(thisraw.UM);
                id.Add(thisraw.Id);
                kind.Add(thisraw.Kind.ToString());
                ptyp.Add(thisraw.PTYP.ToString());
                validfrom.Add(thisraw.Validfrom.ToString());
                validto.Add(thisraw.Validto.ToString());
                serial.Add(thisraw.Serial);
            }
            level.Sort();
            item.Sort();
            quantity.Sort();
            um.Sort(); 
            id.Sort();
            kind.Sort();
            ptyp.Sort(); 
            validfrom.Sort(); 
            validto.Sort();
            serial.Sort();
            for (int i = 0;i < level.Count;i++)
            {
                Level[machine.Id].AddFilter(level[i]);
            }
            for (int i = 0; i < item.Count; i++)
            {
                Item[machine.Id].AddFilter(item[i]);
            }
            for (int i = 0; i < quantity.Count; i++)
            {
                Quantity[machine.Id].AddFilter(quantity[i]);
            }
            for (int i = 0; i < um.Count; i++)
            {
                UM[machine.Id].AddFilter(um[i]);
            }
            for (int i = 0; i < id.Count; i++)
            {
                Id[machine.Id].AddFilter(id[i]);
            }
            for (int i = 0; i < kind.Count; i++)
            {
                Kind[machine.Id].AddFilter(kind[i]);
            }
            for (int i = 0; i < ptyp.Count; i++)
            {
                PTYP[machine.Id].AddFilter(ptyp[i]);
            }
            for (int i = 0; i < validfrom.Count; i++)
            {
                Validfrom[machine.Id].AddFilter(validfrom[i]);
            }
            for (int i = 0; i < validto.Count; i++)
            {
                Validto[machine.Id].AddFilter(validto[i]);
            }
            for (int i = 0; i < serial.Count; i++)
            {
                Serial[machine.Id].AddFilter(serial[i]);
            }
        }

        public void removeMachine(string id) 
        {
            Active.RemoveFilter(id);
            Level.RemoveFilter(id);
            Item.RemoveFilter(id);
            Quantity.RemoveFilter(id);
            UM.RemoveFilter(id);
            Id.RemoveFilter(id);
            Kind.RemoveFilter(id);
            PTYP.RemoveFilter(id);
            Validfrom.RemoveFilter(id);
            Validto.RemoveFilter(id);
            Serial.RemoveFilter(id);
        }

        public void setElement(object sender, EventArgs e)
        {
            IFilterable filter = (IFilterable)sender;
            MessageBox.Show(filter.Filtername+" "+filter.Category+" "+filter.SelectedMachineId);
            switch (filter.Category)
            {
                case "IDmenu":
                    Id[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "Serialmenu":
                    Serial[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "Levelmenu":
                    Level[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "Itemmenu":
                    Item[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "Quantitymenu":
                    Quantity[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "UMmenu":
                    UM[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "Kindmenu":
                    Kind[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "PTYPmenu":
                    PTYP[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "ValidFrommenu":
                    Validfrom[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
                case "ValidTomenu":
                    Validto[filter.SelectedMachineId].setFilter(filter.Filtername);
                break;
            }
            filteringevent?.Invoke(sender, EventArgs.Empty);
        }

        public void resetFilter(object sender, EventArgs e)
        {
            IFilterable printer = (IFilterable)sender;
            Level[printer.SelectedMachineId].ResetFilter();
            Item[printer.SelectedMachineId].ResetFilter();
            Quantity[printer.SelectedMachineId].ResetFilter();
            UM[printer.SelectedMachineId].ResetFilter();
            Id[printer.SelectedMachineId].ResetFilter();
            Kind[printer.SelectedMachineId].ResetFilter();
            PTYP[printer.SelectedMachineId].ResetFilter();
            Validfrom[printer.SelectedMachineId].ResetFilter();
            Validto[printer.SelectedMachineId].ResetFilter();
            Serial[printer.SelectedMachineId].ResetFilter();
            filteringevent?.Invoke(printer, EventArgs.Empty);
        }

        public bool filterElement(string id,Raw thisraw)
        { 
            bool thisfilter = true;
            if (Level[id].Filtered)
            {
                thisfilter = Level[id][thisraw.Level.ToString()];
                thisfilter = Item[id][thisraw.Item.ToString()];
                thisfilter = Quantity[id][thisraw.Quantity.ToString()];
                thisfilter = UM[id][thisraw.UM];
                thisfilter = Id[id][thisraw.Id];
                thisfilter = Kind[id][thisraw.Kind.ToString()];
                thisfilter = PTYP[id][thisraw.PTYP.ToString()];
                thisfilter = Validfrom[id][thisraw.Validfrom.ToString()];
                thisfilter = Validto[id][thisraw.Validto.ToString()];
                thisfilter = Serial[id][thisraw.Serial];
            }
            return thisfilter;
        }
    }
}
