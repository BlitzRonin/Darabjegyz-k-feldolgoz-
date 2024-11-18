using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darabjegyzék_feldolgozó.GUI.Other
{
    public partial class FilterMenu : UserControl,IFilterMenu
    {
        public string MinDate { get { return createmin(); } }
        public string MaxDate { get { return createmax(); } }

        public FilterMenu()
        {
            InitializeComponent();
            clearfilter();
        }

        public void setfilter(Filter filter)
        {
            button1.Click += filter.setElement;
            button2.Click += filter.resetElement;
        }

        private void clearfilter()
        {
            MinYear.Items.Clear();
            MinMonth.Items.Clear();
            MinDay.Items.Clear();
            for (int i = 12;i>0;i--)
            {
                MinMonth.Items.Add(i);
                MaxMonth.Items.Add(i);
            }
            for (int i = 31; i > 0; i--)
            {
                MinDay.Items.Add(i);
                MaxDay.Items.Add(i);
            }
            for (int i = 3000; i > 1950; i--)
            {
                MinYear.Items.Add(i);
                MaxYear.Items.Add(i);
            }
        }

        private string createmin()
        {
            return turndate(MinDay.Text) + "." + turndate(MinMonth.Text) + "." + MinYear.Text;
        }

        private string createmax()
        {
            return turndate(MaxDay.Text) + "." + turndate(MaxMonth.Text) + "." + MaxYear.Text;
        }

        private string turndate(string raw)
        {
            if(Convert.ToInt16(raw) < 10)
            {
                raw = "0" + raw;
            }
            return raw;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearfilter();
        }
    }
}
