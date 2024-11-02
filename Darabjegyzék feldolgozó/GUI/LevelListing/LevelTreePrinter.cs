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
        public LevelTreePrinter()
        {
            InitializeComponent();
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

        public void Resizer(object sender, EventArgs e)
        {
            Size formsize = ((Form1)sender).Size;
            Size = new Size(formsize.Width - Location.X - 10, formsize.Height - Location.Y - 10);
            treeView1.Size = new Size(((Size.Width - treeView1.Location.X - 10) * 25) / 100, Size.Height - treeView1.Location.Y - 40);
            treeView2.Location = new Point(treeView1.Location.X + treeView1.Width + 10, treeView2.Location.Y);
            treeView2.Size = new Size(Size.Width - 20 - treeView2.Location.X, Size.Height - treeView2.Location.Y - 40);
        }
    }
}
