using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Database;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Darabjegyzék_feldolgozó.GUI.BomList
{
    public class BomTree : IDisposable
    {
        private DatabaseInterface @interface;
        public BomTree(DatabaseInterface @interface)
        {
            this.@interface = @interface;
        }

        public void buildTree(TreeView tree)
        {
            tree.Nodes.Clear();
            tree.BeginUpdate();
            for (int i = 0; i < @interface.Machines.Count; i++)
            {
                if (@interface.Filtering.filterActive(@interface.Machines[i].Id))
                {
                    tree.Nodes.Add(@interface.Machines[i].Id);
                    makeTree(tree.Nodes[i], ref @interface.Machines[i].Parts);
                }
            }
            tree.EndUpdate();
        }

        private void makeTree(TreeNode basetree, ref List<Part> basedata)
        {
            for (int i = 0; i < basedata.Count; i++)
            {
                printpart(basetree, basedata[i]);
                if (basedata[i].Parts != null)
                {
                    makeTree(basetree.Nodes[basetree.Nodes.Count-1], ref basedata[i].Parts);
                }
            }
        }

        private void printpart(TreeNode part, Part thispart)
        {
            string name = "Level: " + thispart.Level + "; Mat-No/Doc: " + thispart.Id + "; Docu-No/He: " + thispart.Serial;
            string subs = "Item: " + thispart.Item + "; Quantity: " + thispart.Quantity + "; UM: " + thispart.UM + "; Kind: " + thispart.Kind + "; PTYP: " + thispart.PTYP + "; Valid From: "; 
            if (thispart.Validfrom != null)
            {
                subs += thispart.Validfrom.Value.Date.Year+"."+ thispart.Validfrom.Value.Date.Month + "."+ thispart.Validfrom.Value.Date.Day;
            }
            subs += "; Valid To: ";
            if (thispart.Validto != null)
            {
                subs += thispart.Validto.Value.Date.Year + "." + thispart.Validto.Value.Date.Month + "." + thispart.Validto.Value.Date.Day;
            }
            part.Nodes.Add(name);
            part.Nodes[part.Nodes.Count - 1].Nodes.Add(subs);
        }

        public void Dispose()
        {

        }
    }
}
