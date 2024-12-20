﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;

namespace Darabjegyzék_feldolgozó.Database
{
    public interface DatabaseInterface
    {
        FilterHandler Filtering { get; }
        List<DMachine> Machines { get; }
        string addNews(string[] paths);
        void removeThis(string id);
        void removeThis(int index);
    }
}
