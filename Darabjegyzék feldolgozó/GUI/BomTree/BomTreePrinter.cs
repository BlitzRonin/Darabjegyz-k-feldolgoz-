using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
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

namespace Darabjegyzék_feldolgozó.GUI
{
    public partial class BomTreePrinter : UserControl
    {
        DatabaseInterface @interface;

        public BomTreePrinter(DatabaseInterface @interface)
        {
            InitializeComponent();
            filterMenu1.setfilter(@interface.Filtering);
        }

        public void Printthis(DatabaseInterface @interface)
        {
            this.@interface = @interface;
            filltree();
            BringToFront();
        }

        private void filltree()
        {
            using (BomTree treeBuilder = new BomTree(@interface))
            {
                treeBuilder.buildTree(treeView1);
            }
        }
    }
}
