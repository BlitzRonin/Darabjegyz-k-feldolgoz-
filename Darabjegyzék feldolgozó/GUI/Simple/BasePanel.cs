using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.GUI.Other;
using Darabjegyzék_feldolgozó.GUI.Simple.Drawers;

namespace Darabjegyzék_feldolgozó.GUI
{
    public partial class BasePanel : UserControl, IFilterable
    {
        public string SelectedMachineId { get; set; }
        public string Category { get; set; }
        public string Filtername {  get; set; }

        private IDrawer drawer;
        private event EventHandler filterreset;

        public BasePanel(IDrawer drawme, DatabaseInterface databaseInterface)
        {
            InitializeComponent();
            drawer = drawme;
            FilterGUIHandler handler = new FilterGUIHandler(filtermenu, databaseInterface.Filtering, filterreset, this);
            drawer.LinkFilter(handler, Tab,this);
            label1.Text = drawer.NameOfFunc;
        }

        public void PrintIt(DatabaseInterface @interface)
        {
            drawer.Drawer(Tab, filtermenu, @interface);
            BringToFront();
        }

        public void Resetbutton_Click(object sender, EventArgs e)
        {
            SelectedMachineId = Tab.SelectedTab.Text;
            filterreset?.Invoke(this, EventArgs.Empty);
        }
    }
}
