using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Factories.Statistics;
using Darabjegyzék_feldolgozó.GUI.Other.Filters;
using Darabjegyzék_feldolgozó.GUI.Simple.Drawers;
using Darabjegyzék_feldolgozó.GUI.Special.CompareHandling;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Darabjegyzék_feldolgozó.GUI.Compare
{
    public partial class CompareTreePrinter : UserControl, IPrinter
    {
        private DatabaseInterface @interface;
        private FilterGUIHandler handler;
        private string A, B;

        public CompareTreePrinter(DatabaseInterface @interface, FilterGUIHandler handler)
        {
            InitializeComponent();
            this.@interface = @interface;
            this.handler = handler;
            comboBox1.SelectedIndexChanged += comboBox_TextChanged;
            comboBox2.SelectedIndexChanged += comboBox_TextChanged;
            A = "";
            B = "";
        }

        public void PrintIt(DatabaseInterface @interface)
        {
            this.@interface = @interface;
            fillcombo();
            setthefilter();
            treeinsthandler();
            BringToFront();
        }

        private void setstate()
        {
            Status.ToolTipText = handler.State();
            if (Status.ToolTipText == "" || Status.ToolTipText == null)
            {
                Status.Text = "Unfiltererd";
            }
            else
            {
                Status.Text = "Filtered";
            }
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
                comboBox1.SelectedIndex = istherecombo(ref A);
                comboBox2.SelectedIndex = istherecombo(ref B);
            }
        }

        private int istherecombo(ref string element)
        { 
            if(element != "" && comboBox1.Items.Contains(element))
            {
                return comboBox1.Items.IndexOf(element);
            }
            else
            {
                element = "";
                return 0;
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

        }

        public void Resetbutton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                handler.Reset(this, comboBox1.SelectedItem.ToString());
            }
            if (comboBox2.SelectedItem != null)
            {
                handler.Reset(this, comboBox2.SelectedItem.ToString());
            }
            setstate();
        }

        private void IDmenu_Click(object sender, EventArgs e)
        {
            handler.Show("Id");
        }

        private void Serialmenu_Click(object sender, EventArgs e)
        {
            handler.Show("Serial");
        }

        private void Levelmenu_Click(object sender, EventArgs e)
        {
            handler.Show("Level");
        }

        private void Itemmenu_Click(object sender, EventArgs e)
        {
            handler.Show("Item");
        }

        private void Quantitymenu_Click(object sender, EventArgs e)
        {
            handler.Show("Quantitity");
        }

        private void UMmenu_Click(object sender, EventArgs e)
        {
            handler.Show("UM");
        }

        private void Kindmenu_Click(object sender, EventArgs e)
        {
            handler.Show("Kind");
        }

        private void PTYPmenu_Click(object sender, EventArgs e)
        {
            handler.Show("PTYP");
        }

        private void ValidFrommenu_Click(object sender, EventArgs e)
        {
            handler.Show("Validfrom");
        }

        private void ValidTomenu_Click(object sender, EventArgs e)
        {
            handler.Show("Validto");
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            setthefilter();
            treeinsthandler();
        }

        private void treeinsthandler()
        {
            if (comboBox1.SelectedIndex != comboBox2.SelectedIndex && comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                filltree(comboBox1.SelectedIndex, comboBox2.SelectedIndex);
            }
            else
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add("NaN");
                treeView2.Nodes.Clear();
                treeView2.Nodes.Add("NaN");
            }
        }

        private void setthefilter()
        {
            if (comboBox1.SelectedItem != null)
            {
                handler.Set(comboBox1.SelectedItem.ToString(), this);
                A = comboBox1.SelectedItem.ToString();
            }
            if (comboBox2.SelectedItem != null)
            {
                handler.Set(comboBox2.SelectedItem.ToString());
                B = comboBox2.SelectedItem.ToString();
            }
            if (comboBox1.SelectedItem == null && comboBox2.SelectedItem == null)
            {
                handler.Clear();
            }
            setstate();
        }
    }
}
