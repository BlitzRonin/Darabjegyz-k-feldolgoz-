using Darabjegyzék_feldolgozó.Database.Types.Machines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darabjegyzék_feldolgozó.GUI.BomHandling
{
    public partial class BomControl : UserControl
    {
        private DMachine machine;
        public BomControl(DMachine machine)
        {
            InitializeComponent();
            this.machine = machine;
            label1.Text = machine.Id;
            label2.Text = machine.Raws.Count.ToString();
            if(machine.Active)
            {
                printactive();
            }
            else
            {
                printinact();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setactivebutton();
        }

        private void setactivebutton()
        {
            if(machine.Active)
            {
                printinact();
                machine.Active = false;

            }
            else 
            {
                printactive();
                machine.Active = true;
            }
        }

        private void printactive()
        {
            button1.Text = "Aktív";
            button1.BackColor = Color.LightGreen;
        }

        private void printinact()
        {
            button1.Text = "Inaktív";
            button1.BackColor = Color.Red;
        }
    }
}
