using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database.Types;

namespace Darabjegyzék_feldolgozó.Database
{
    public interface DatabaseInterface
    {
        List<DMachine> GetDatabase { get; }
        void fillthelist(string path);
    }
}
