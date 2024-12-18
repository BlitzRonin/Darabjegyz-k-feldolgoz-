using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.GUI;

namespace Darabjegyzék_feldolgozó.Database.Types.Filters
{
    public class FilterHandler
    {
        public event EventHandler filteringevent;
        public Dictionary<string,string> actualfilters;    
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
            actualfilters = new Dictionary<string,string>();
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

        public void setElement(object sender, FilterSetterArgs e)
        {
            for (int i = 0; i < e.filters.Count; i++)
            {
                for (int j = 0; j < e.machine.Count; j++)
                {
                    switch (e.type)
                    {
                        case "Id":
                            if(Id.Contains(e.machine[j]))
                            {
                                Id[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "Serial":
                            if (Serial.Contains(e.machine[j]))
                            {
                                Serial[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "Level":
                            if (Level.Contains(e.machine[j]))
                            {
                                Level[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "Item":
                            if (Item.Contains(e.machine[j]))
                            {
                                Item[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "Quantitity":
                            if (Quantity.Contains(e.machine[j]))
                            {
                                Quantity[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "UM":
                            if (UM.Contains(e.machine[j]))
                            {
                                UM[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "Kind":
                            if (Kind.Contains(e.machine[j]))
                            {
                                Kind[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "PTYP":
                            if (PTYP.Contains(e.machine[j]))
                            {
                                PTYP[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "Validfrom":
                            if (Validfrom.Contains(e.machine[j]))
                            {
                                Validfrom[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                        case "Validto":
                            if (Validto.Contains(e.machine[j]))
                            {
                                Validto[e.machine[j]].setFilter(e.filters[i]);
                            }
                            break;
                    }
                }
            }
            filteringevent?.Invoke(sender, EventArgs.Empty);
        }

        public void resetFilter(IPrinter thisprinter,string machineid)
        {
            Level[machineid].ResetFilter();
            Item[machineid].ResetFilter();
            Quantity[machineid].ResetFilter();
            UM[machineid].ResetFilter();
            Id[machineid].ResetFilter();
            Kind[machineid].ResetFilter();
            PTYP[machineid].ResetFilter();
            Validfrom[machineid].ResetFilter();
            Validto[machineid].ResetFilter();
            Serial[machineid].ResetFilter();
            filteringevent?.Invoke(thisprinter, EventArgs.Empty);
            actualfilters.Clear();
        }

        public bool filterElement(string id,Raw thisraw)
        { 
            if (!Level[id][thisraw.Level.ToString()])
            {
                return false;
            }
            if (!Item[id][thisraw.Item.ToString()])
            {
                return false;
            }
            if (!Quantity[id][thisraw.Quantity.ToString()])
            {
                return false;
            }
            if (!UM[id][thisraw.UM])
            {
                return false;
            }
            if (!Id[id][thisraw.Id])
            {
                return false;
            }
            if (!Kind[id][thisraw.Kind.ToString()])
            {
                return false;
            }
            if (!PTYP[id][thisraw.PTYP.ToString()])
            {
                return false;
            }
            if (!Validfrom[id][thisraw.Validfrom.ToString()])
            {
                return false;
            }
            if (!Validto[id][thisraw.Validto.ToString()])
            {
                return false;
            }
            if (!Serial[id][thisraw.Serial])
            {
                return false;
            }
            return true;
        }
    }
}
