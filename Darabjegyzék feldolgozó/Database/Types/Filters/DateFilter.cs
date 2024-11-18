using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.Types.Filters
{
    public class DateFilter
    {
        private DateTime? maxDate;
        private DateTime? minDate;

        public DateFilter() 
        {
            reset();
        }

        public void reset()
        {
            maxDate = null;
            minDate = null;
        }

        public void set(string MinDate,string MaxDate)
        {
            minDate = DateTime.ParseExact(MinDate, "dd.MM.yyyy", null);
            maxDate = DateTime.ParseExact(MaxDate, "dd.MM.yyyy", null);
        }

        public bool filterDate(DateTime? Min,DateTime? Max)
        {
            if(minDate != null && maxDate != null)
            {
                if(Min != null && Max != null && (minDate >= Min || maxDate <= Max))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
