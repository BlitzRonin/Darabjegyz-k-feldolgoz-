using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.GUI.Other.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.GUI.Simple.Drawers
{
    public interface IDrawer
    {
        string NameOfFunc { get; }
        void Drawer(TabControl thistab, DatabaseInterface @interface);
    }
}
