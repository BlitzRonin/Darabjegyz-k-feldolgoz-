using Darabjegyzék_feldolgozó.Database;
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

namespace Darabjegyzék_feldolgozó.GUI
{
    public partial class LevelTreePrinter : UserControl
    {
        DatabaseInterface @interface;

        public LevelTreePrinter(DatabaseInterface @interface)
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
            using (LevelTree treeBuilder = new LevelTree(@interface))
            {
                treeBuilder.buildList(treeView1);
                treeBuilder.buildTree(treeView2);
            }
        }
    }
}
