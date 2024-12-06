using Darabjegyzék_feldolgozó.Database.File;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factories.Preppers
{
    //This class creates the Raws from the File
    public class RawPrepper : IDisposable
    {
        public List<Raw> prepper(FileReader readit)
        {
            List<Raw> result = new List<Raw>();
            string line;
            for (int i = 0; (line = readit.readALine()) != null; i++)
            {
                if (i != 0)
                {
                    result.Add(convert(line));
                }
            }
            return result;
        }

        private Raw convert(string line)
        {
            string[] temp = line.Split(";");
            int level = Convert.ToInt16(temp[0]);
            int item = Convert.ToInt16(temp[1]);
            double quantity = Convert.ToDouble(temp[2]);
            string um = temp[3];
            string id = temp[4];
            int kind = Convert.ToInt16(temp[5]);
            int ptyp = Convert.ToInt16(temp[6]);
            DateTime? validfrom;
            if (temp[7] == "")
            {
                validfrom = null;
            }
            else
            {
                validfrom = getdate(temp[7]);
            }
            DateTime? validto;
            if (temp[8] == "")
            {
                validto = null;
            }
            else
            {
                validto = getdate(temp[8]);
            }
            string serial = temp[9];
            return new Raw(level, item, quantity, um, id, kind, ptyp, validfrom, validto, serial);
        }

        private DateTime getdate(string input)
        {
            DateTime temp;
            string[] tempstr = input.Split(".");
            if (Convert.ToInt16(tempstr[0]) >= 9999 || Convert.ToInt16(tempstr[1]) >= 9999 || Convert.ToInt16(tempstr[2]) >= 9999)
            {
                temp = DateTime.MaxValue.Date;
            }
            else
            {
                temp = DateTime.ParseExact(input, "dd.MM.yyyy", null);
            }
            return temp;
        }

        public void Dispose()
        {

        }
    }
}
