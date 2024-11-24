using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Darabjegyzék_feldolgozó.Factories.Statistics;
using Darabjegyzék_feldolgozó.Database.Types.Statistics;

namespace Darabjegyzék_feldolgozó.GUI.CompareHandling
{
    public class CompareTree : IDisposable
    {
        private DatabaseInterface @interface;

        public CompareTree(DatabaseInterface @interface) 
        {
            this.@interface = @interface;
        }

        public void buildTree(TreeView tree, List<CompareElements> compare,DMachine machine)
        {
            tree.Nodes.Clear();
            tree.BeginUpdate();
            tree.Nodes.Add(machine.Id);
            makeTree(tree.Nodes[0], ref machine.Parts,ref compare);
            tree.EndUpdate();
        }

        private void makeTree(TreeNode basetree, ref List<Part> basedata,ref List<CompareElements> compare)
        {
            for (int i = 0; i < basedata.Count; i++)
            {
                printpart(basetree, basedata[i], compare[i].Mode);
                if (basedata[i].Parts != null)
                {
                    makeTree(basetree.Nodes[basetree.Nodes.Count - 1], ref basedata[i].Parts, ref compare[i].relation);
                }
            }
        }

        private void printpart(TreeNode part, Part thispart,string state)
        {
            string name = "Level: " + thispart.Level + "; Mat-No/Doc: " + thispart.Id + "; Docu-No/He: " + thispart.Serial;
            string subs = "Item: " + thispart.Item + "; Quantity: " + thispart.Quantity + "; UM: " + thispart.UM + "; Kind: " + thispart.Kind + "; PTYP: " + thispart.PTYP + "; Valid From: ";
            if (thispart.Validfrom != null)
            {
                subs += thispart.Validfrom.Value.Date.Year + "." + thispart.Validfrom.Value.Date.Month + "." + thispart.Validfrom.Value.Date.Day;
            }
            subs += "; Valid To: ";
            if (thispart.Validto != null)
            {
                subs += thispart.Validto.Value.Date.Year + "." + thispart.Validto.Value.Date.Month + "." + thispart.Validto.Value.Date.Day;
            }
            subs += state;
            part.Nodes.Add(name);
            part.Nodes[part.Nodes.Count - 1].Nodes.Add(subs);
            colorthis(part.Nodes[part.Nodes.Count-1],state);
        }

        private void colorthis(TreeNode thispart,string state)
        {
            switch(state)
            {
                case "changed":
                    thispart.ForeColor = Color.Yellow;
                    thispart.Nodes[thispart.Nodes.Count - 1].ForeColor = Color.Yellow;
                break;
                case "same":
                    thispart.ForeColor = Color.Green;
                    thispart.Nodes[thispart.Nodes.Count - 1].ForeColor = Color.Green;
                break;
                case "different":
                    thispart.ForeColor = Color.Red;
                    thispart.Nodes[thispart.Nodes.Count - 1].ForeColor = Color.Red;
                break;
            }
        }

        public void Dispose()
        {

        }
    }
}
