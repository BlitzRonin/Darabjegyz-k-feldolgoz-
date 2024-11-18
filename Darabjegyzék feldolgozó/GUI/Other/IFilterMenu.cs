using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.GUI.Other
{
    public interface IFilterMenu
    {
        public string MinDate { get; }
        public string MaxDate { get; }
    }
}
