using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.GUI
{
    public interface IFilterable : IPrinter
    {
        string SelectedMachineId { get; set; }
        string Category { get; set; }
        string Filtername { get; set; }
        void Resetbutton_Click(object sender, EventArgs e);
    }
}
