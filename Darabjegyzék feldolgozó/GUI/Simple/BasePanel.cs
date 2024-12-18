using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.GUI.Other.Filters;
using Darabjegyzék_feldolgozó.GUI.Simple.Drawers;
using System.Reflection.PortableExecutable;

namespace Darabjegyzék_feldolgozó.GUI
{
    public partial class BasePanel : UserControl, IPrinter
    {
        private IDrawer drawer;
        private FilterGUIHandler handler;
        private string activefilter;

        public BasePanel(IDrawer drawme, FilterGUIHandler handler)
        {
            InitializeComponent();
            drawer = drawme;
            label1.Text = drawer.NameOfFunc;
            this.handler = handler;
            setkillfilter();
        }

        public void PrintIt(DatabaseInterface @interface)
        {
            drawer.Drawer(Tab, @interface);
            if (Tab.SelectedTab != null)
            {
                handler.Set(Tab.SelectedTab.Text, this);
            }
            else
            {
                handler.Clear();
            }
            setstate();
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

        private void IDmenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("Id");
        }

        private void Serialmenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("Serial");
        }

        private void Levelmenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("Level");
        }

        private void Itemmenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("Item");
        }

        private void Quantitymenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("Quantitity");
        }

        private void UMmenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("UM");
        }

        private void Kindmenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("Kind");
        }

        private void PTYPmenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("PTYP");
        }

        private void ValidFrommenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("Validfrom");
        }

        private void ValidTomenu_Click(object sender, EventArgs e)
        {
            activefilter = handler.Show("Validto");
        }

        private void Resebutton_Click(object sender, EventArgs e)
        {
            if (Tab.SelectedTab != null)
            {
                handler.Reset(this, Tab.SelectedTab.Text);
            }
            setstate();
        }

        private void Tab_Selected(object sender, TabControlEventArgs e)
        {
            if (Tab.SelectedTab != null)
            {
                handler.Set(Tab.SelectedTab.Text, this);
            }
            setstate();
        }

        private void killfilter(object sender,EventArgs e)
        {
            if (activefilter != "")
            {
                handler.Hide(activefilter, this);
            }
        }

        private void setkillfilter()
        {
            activefilter = "";
            Tab.Click += killfilter;
            Click += killfilter;
            label1.Click += killfilter;
            filtermenu.Click += killfilter;
        }
    }
}
