using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.GUI.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Filters
{
    public class Filter
    {
        private ActiveFilter active;
        private DateFilter date;
        public Filter() 
        { 
            active = new ActiveFilter();
            date = new DateFilter();
        }

        public void addActive(string id)
        {
            active.addActive(id);
        }

        public void setActive(string id)
        {
            active.setActive(id);
        }

        public bool filterActive(string id)
        {
            return active.filterActive(id);
        }

        public void removeActive(string id)
        {
            active.removeActive(id);
        }

        public void setElement(object sender, EventArgs e)
        {
            IFilterMenu data = (IFilterMenu)((Button)sender).Parent;
            date.set(data.MinDate, data.MinDate);
        }

        public void resetElement(object sender, EventArgs e)
        {
            date.reset();
        }

        public bool filterElement(Raw thismach)
        { 
            bool thisfilter = true;
            thisfilter = date.filterDate(thismach.Validfrom,thismach.Validto);
            return thisfilter;
        }
    }
}
