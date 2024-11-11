using Darabjegyzék_feldolgozó.Database;
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

        public BomTreePrinter()
        {
            InitializeComponent();
        }

        public void Printthis(DatabaseInterface @interface,Size formsize)
        {
            this.@interface = @interface;
            setsize(formsize);
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

        public void Resizer(object sender, EventArgs e)
        {
            setsize(((Form1)sender).Size);
        }

        private void setsize(Size formsize)
        {
            Size = new Size(formsize.Width - Location.X - 10, formsize.Height - Location.Y - 10);
            treeView1.Size = new Size(Width - treeView1.Location.X - 20, Height - treeView1.Location.Y - 40);
        }
    }
}
