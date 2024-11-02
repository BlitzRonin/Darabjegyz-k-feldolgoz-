using Darabjegyzék_feldolgozó.Database.File;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factories.Preppers
{
    public class BomPrepper : IDisposable
    {
        private List<Part> prepared;
        public List<Part> prepper(List<Raw> raws)
        {
            prepared = new List<Part>();
            int lastone = 1;
            for(int i = 0;i < raws.Count ; i++)
            {
                lastone = packlist(raws[i], lastone);
            }
            return prepared;
        }

        private int packlist(Raw oneraw, int lastone)
        {
            Part thispart = convert(oneraw);
            ref List<Part> currentpart = ref prepared;
            bool added = false;
            int clevel = 1;
            do
            {
                if (thispart.Level == clevel || thispart.Level == 0 && lastone == clevel)
                {
                    if (currentpart == null)
                    {
                        currentpart = [thispart];
                    }
                    else
                    {
                        currentpart.Add(thispart);
                    }
                    added = true;
                    lastone = clevel;
                }
                else
                {
                    clevel++;
                    currentpart = ref currentpart[currentpart.Count - 1].Parts;
                }
            }
            while (!added);
            return lastone;
        }

        private Part convert(Raw convertable)
        {
            return new Part(convertable.Level, convertable.Item, convertable.Quantity, convertable.UM, convertable.Id, convertable.Kind, convertable.PTYP, convertable.Validfrom, convertable.Validto, convertable.Serial);
        }

        public void Dispose()
        {

        }
    }
}
