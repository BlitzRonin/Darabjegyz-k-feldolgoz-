using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Factories.Statistics;
using Darabjegyzék_feldolgozó.GUI.Other;
using Darabjegyzék_feldolgozó.GUI.Simple.Drawers;
using Darabjegyzék_feldolgozó.GUI.Special.CompareHandling;

namespace Darabjegyzék_feldolgozó.GUI.Compare
{
    public partial class CompareTreePrinter : UserControl, IFilterable
    {
        public string SelectedMachineId { get; set; }
        public string Category { get; set; }
        public string Filtername { get; set; }

        private DatabaseInterface @interface;
        private FilterGUIHandler filter;
        private event EventHandler filterreset;

        public CompareTreePrinter(DatabaseInterface @interface)
        {
            InitializeComponent();
            this.@interface = @interface;
            filter = new FilterGUIHandler(filtermenu, @interface.Filtering, filterreset, this);
        }

        public void PrintIt(DatabaseInterface @interface)
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
                if (@interface.Filtering.Active[@interface.Machines[i].Id])
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


        private void filltree(int MA, int MB)
        {
            using (CompareTree treeBuilder = new CompareTree(@interface))
            {
                CompareBoms compareBoms = new CompareBoms(@interface.Filtering);
                compareBoms.Compare(@interface.Machines[MA], @interface.Machines[MB]);
                treeBuilder.buildTree(treeView1, compareBoms.ResultA, @interface.Machines[MA]);
                treeBuilder.buildTree(treeView2, compareBoms.ResultB, @interface.Machines[MB]);
            }
            filter.fillfilter(@interface.Machines[MA].Id, @interface.Machines[MB].Id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != comboBox2.SelectedIndex && comboBox1.Text != "" && comboBox2.Text != "")
            {
                filltree(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nem megfelelő a kiválasztás!");
            }
        }

        public void Resetbutton_Click(object sender, EventArgs e)
        {
            SelectedMachineId = comboBox1.SelectedItem.ToString();
            filterreset?.Invoke(this, EventArgs.Empty);
            SelectedMachineId = comboBox2.SelectedItem.ToString();
            filterreset?.Invoke(this, EventArgs.Empty);
        }
    }
}
