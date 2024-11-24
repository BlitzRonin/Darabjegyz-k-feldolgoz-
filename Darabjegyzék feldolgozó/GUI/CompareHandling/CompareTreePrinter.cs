using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Factories.Statistics;
using Darabjegyzék_feldolgozó.GUI.CompareHandling;
using Darabjegyzék_feldolgozó.GUI.LevelList;
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

namespace Darabjegyzék_feldolgozó.GUI.Compare
{
    public partial class CompareTreePrinter : UserControl
    {
        DatabaseInterface @interface;

        public CompareTreePrinter(DatabaseInterface @interface)
        {
            InitializeComponent();
            filterMenu1.setfilter(@interface.Filtering);
        }

        public void Printthis(DatabaseInterface @interface)
        {
            this.@interface = @interface;
            fillcombo();
            BringToFront();
        }

        private void fillcombo()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (int i = 0; i < @interface.Machines.Count; i++)
            {
                if (@interface.Filtering.filterActive(@interface.Machines[i].Id))
                {
                    comboBox1.Items.Add(@interface.Machines[i].Id);
                    comboBox2.Items.Add(@interface.Machines[i].Id);
                }
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
        }


        private void filltree(int MA,int MB)
        {
            using (CompareTree treeBuilder = new CompareTree(@interface))
            {
                CompareBoms compareBoms = new CompareBoms(@interface.Filtering);
                compareBoms.Compare(@interface.Machines[MA], @interface.Machines[MB]);
                treeBuilder.buildTree(treeView1,compareBoms.ResultA, @interface.Machines[MA]);
                treeBuilder.buildTree(treeView2,compareBoms.ResultB, @interface.Machines[MB]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != comboBox2.SelectedIndex && comboBox1.Text != "" && comboBox2.Text != "")
            {
                filltree(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nem megfelelő a kiválasztás!");
            }
        }
    }
}
