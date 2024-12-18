using Darabjegyzék_feldolgozó.Database.Types.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Darabjegyzék_feldolgozó.GUI.Other.Filters
{
    public partial class FilterGUI : UserControl
    {
        public event EventHandler<FilterSetterArgs> FilterSetter;
        public bool Readytofil { get; set; }
        public IPrinter currentprinter { get; set; }
        public List<string> machine { get; set; }

        private List<string> filters;
        private string type;

        public FilterGUI(string type, Point place)
        {
            InitializeComponent();
            Namelabel.Text = type + ":";
            this.type = type;
            Location = place;
            Visible = false;
            SendToBack();
        }

        public void ClearList()
        {
            checkedListBox1.Items.Clear();
            machine = new List<string>();
            filters = new List<string>();
            Readytofil = false;
        }

        public void AddItem(string element, bool state)
        {
            if (!checkedListBox1.Items.Contains(element))
            {
                checkedListBox1.Items.Add(element, state);
            }
        }

        public bool ContainItem(string element)
        {
            return checkedListBox1.Items.Contains(element);
        }

        public void setup()
        {
            RatioLabel.Text = checkedListBox1.Items.Count + "/" + (checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count);
        }

        public void setup(bool check)
        {
            if(check)
            {
                RatioLabel.Text = checkedListBox1.Items.Count + "/" + (checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count+1);
            }
            else
            {
                RatioLabel.Text = checkedListBox1.Items.Count + "/" + (checkedListBox1.Items.Count - checkedListBox1.CheckedItems.Count-1);
            }
        }

        public void FilterGUI_Leave(object sender, EventArgs e)
        {
            Visible = false;
            SendToBack();
            if (filters != null)
            {
                if (filters.Count > 0)
                {
                    FilterSetter?.Invoke(currentprinter, new FilterSetterArgs(filters, type, machine));
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (Readytofil)
            {
                if (filters.Contains(checkedListBox1.Items[e.Index].ToString()))
                {
                    filters.Remove(checkedListBox1.Items[e.Index].ToString());
                }
                else
                {
                    filters.Add(checkedListBox1.Items[e.Index].ToString());
                }
                if(e.NewValue == CheckState.Checked)
                {
                    setup(false);
                }
                else
                {
                    setup(true);
                }
            }
        }

        public List<string> Checkstate()
        {
            List<string> state = new List<string>();
            for(int i =0;i<checkedListBox1.Items.Count;i++)
            {
                if (!checkedListBox1.CheckedItems.Contains(checkedListBox1.Items[i].ToString()))
                {
                    state.Add(checkedListBox1.Items[i].ToString());
                }
            }
            return state;
        }
    }
}
