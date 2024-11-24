using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.GUI.BomList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Darabjegyzék_feldolgozó.GUI
{
    public partial class RawPrinter : UserControl
    {
        private DatabaseInterface @interface;

        public RawPrinter(DatabaseInterface @interface)
        {
            InitializeComponent();
            filter1.setfilter(@interface.Filtering);
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
            for (int i=0;i< @interface.Machines.Count ; i++)
            {
                if (@interface.Filtering.filterActive(@interface.Machines[i].Id))
                {
                    treeView1.Nodes.Add(@interface.Machines[i].Id);
                    for (int j = 0; j < @interface.Machines[i].Raws.Count; j++)
                    {
                        Raw thisraw = @interface.Machines[i].Raws[j];
                        if(@interface.Filtering.filterElement(thisraw))
                        {
                            string name = "Level: " + thisraw.Level + "; Mat-No/Doc: " + thisraw.Id + "; Docu-No/He: " + thisraw.Serial;
                            string subs = "Item: " + thisraw.Item + "; Quantity: " + thisraw.Quantity + "; UM: " + thisraw.UM + "; Kind: " + thisraw.Kind + "; PTYP: " + thisraw.PTYP + "; Valid From: ";
                            if (thisraw.Validfrom != null)
                            {
                                subs += thisraw.Validfrom.Value.Date.Year + "." + thisraw.Validfrom.Value.Date.Month + "." + thisraw.Validfrom.Value.Date.Day;
                            }
                            subs += "; Valid To: ";
                            if (thisraw.Validto != null)
                            {
                                subs += thisraw.Validto.Value.Date.Year + "." + thisraw.Validto.Value.Date.Month + "." + thisraw.Validto.Value.Date.Day;
                            }
                            treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Add(name);
                            treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes[treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Count - 1].Nodes.Add(subs);
                        }
                    }
                }
            }
            treeView1.EndUpdate();
        }
    }
}
