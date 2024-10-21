using Darabjegyzék_feldolgozó.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darabjegyzék_feldolgozó.GUI
{
    public partial class BomLister : UserControl
    {
        private DatabaseInterface @interface;
        public BomLister(DatabaseInterface @interface)
        {
            InitializeComponent();
            this.@interface = @interface;
        }

        private void BomLister_Load(object sender, EventArgs e)
        {
            filltree();
        }

        private void filltree()
        {
            treeView1.BeginUpdate();
            for (int i = 0; i < (@interface.GetDatabase.Count); i++)
            {
                treeView1.Nodes.Add(@interface.GetDatabase[i].Id);
                for (int j = 0; j < (@interface.GetDatabase[i].MainParts.Count); j++)
                {
                    treeView1.Nodes[i].Nodes.Add(@interface.GetDatabase[i].MainParts[j].Main.Level.ToString() + " - " + @interface.GetDatabase[i].MainParts[j].Main.BomName);
                    if (@interface.GetDatabase[i].MainParts[j].SubParts != null)
                    {
                        for (int k = 0; k < (@interface.GetDatabase[i].MainParts[j].SubParts.Count); k++)
                        {
                            treeView1.Nodes[i].Nodes[j].Nodes.Add(@interface.GetDatabase[i].MainParts[j].SubParts[k].Level.ToString() + " - " + @interface.GetDatabase[i].MainParts[j].SubParts[k].BomName);
                        }
                    }
                }
            }
            treeView1.EndUpdate();
        }

        public void Resizer(int Height,int Width)
        {
            Size = new Size(Width-10,Height-10);
            treeView1.Size = new Size(this.Width - 10, this.Height - 10);
        }
    }
}
