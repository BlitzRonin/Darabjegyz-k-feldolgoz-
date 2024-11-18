﻿using Darabjegyzék_feldolgozó.Database;
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
    public partial class ComparePrinter : UserControl
    {
        DatabaseInterface @interface;

        public ComparePrinter(DatabaseInterface @interface, Size formsize)
        {
            InitializeComponent();
            filterMenu1.setfilter(@interface.Filtering);
            pr(@interface, formsize);
        }

        private void pr(DatabaseInterface @interface, Size formsize)
        {
            this.@interface = @interface;
            setsize(formsize);
            filltree();
            BringToFront();
        }

        public void Printthis(DatabaseInterface @interface, Size formsize)
        {
            pr(@interface, formsize);
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
            setsize(((Form1)sender).Size);
        }

        private void setsize(Size formsize)
        {
            Size = new Size(formsize.Width - Location.X - 10, formsize.Height - Location.Y - 10);
            //treeView1.Size = new Size(((Size.Width - treeView1.Location.X - 10) * 25) / 100, Size.Height - treeView1.Location.Y - 40);
            //treeView2.Location = new Point(treeView1.Location.X + treeView1.Width + 10, treeView2.Location.Y);
            //treeView2.Size = new Size(Size.Width - 20 - treeView2.Location.X, Size.Height - treeView2.Location.Y - 40);
        }
    }
}
