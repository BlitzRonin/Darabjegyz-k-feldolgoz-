using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.GUI.Other;
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
        void LinkFilter(FilterGUIHandler filter,TabControl Tab);
        void Drawer(TabControl thistab, ToolStrip filtermenu, DatabaseInterface @interface);
    }
}
