using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.GUI.BomHandling;
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
    public partial class BomHandlerMenu : UserControl
    {
        private List<BomControl> controlList;
        private DatabaseInterface @interface;
        public BomHandlerMenu()
        {
            InitializeComponent();
            controlList = new List<BomControl>();
        }

        public void Printthis(DatabaseInterface @interface)
        {
            this.@interface = @interface;
            PrintBoms();
            BringToFront();
        }

        public void PrintBoms()
        {
            for (int i = 0; i < @interface.Machines.Count; i++)
            {
                if (!exist(@interface.Machines[i].Id))
                {
                    controlList.Add(new BomControl(@interface.Machines[i],@interface.Filtering));
                }
            }
            for (int i = 0; i < controlList.Count; i++)
            {
                if (!Controls.Contains(controlList[i]))
                {
                    flowLayoutPanel1.Controls.Add(controlList[i]);
                    controlList[i].Controls.Find("button2",true)[0].Click += removethis;
                }
            }
        }

        private void removethis(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos ki akarod törölni a Bomot!","Törlés",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BomControl thisone = (BomControl)(((System.Windows.Forms.Button)sender).Parent);
                controlList.Remove(thisone);
                flowLayoutPanel1.Controls.Remove(thisone);
                @interface.removeThis(thisone.Controls.Find("label1", true)[0].Text);
            }
        }

        private bool exist(string id)
        {
            for (int i = 0; i < controlList.Count; i++)
            {
                if(id == controlList[i].Controls.Find("label1", true)[0].Text)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
