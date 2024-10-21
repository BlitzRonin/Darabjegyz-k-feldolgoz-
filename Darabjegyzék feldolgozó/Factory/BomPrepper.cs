using Darabjegyzék_feldolgozó.Database.File;
using Darabjegyzék_feldolgozó.Database.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factory
{
    public class BomPrepper : IDisposable
    {
        private List<DMachine> prepared;
        public List<DMachine> prepper(string path)
        {
            using (FileReader readit = new FileReader(path))
            {
                prepsequence(readit);
            }
            return prepared; 
        }

        private void prepsequence(FileReader readit)
        { 
            prepared = new List<DMachine>();
            string line;
            for (int i =0;(line = readit.readALine()) != null; i++)
            {
                if (!(line[1] == '.' || line[2] == '.' || line[3] == '.' || line[4] == '.' || line[5] == '.'))
                {
                    prepared.Add(new DMachine(line));
                }
                else 
                {
                    addtostructure(convertline(line));
                }

            }
        }

        private void addtostructure(string[] input)
        {
            int legnagyobblevel = 1;
            if(Convert.ToInt16(input[0]) > legnagyobblevel)
            {
                legnagyobblevel++;
            }
            if (Convert.ToInt16(input[0]) < legnagyobblevel+1)
            {
                prepared[prepared.Count - 1].AddMainPart(Convert.ToInt16(input[0]), input[1]);
            }
            else 
            {
                prepared[prepared.Count - 1].MainParts[prepared[prepared.Count-1].MainParts.Count-1].AddSubPart(Convert.ToInt16(input[0]), input[1]);
            }
        }

        private string[] convertline(string line)
        {
            string[] temp;
            int indexer = line.LastIndexOf('-');
            if(indexer > -1 && indexer != line.IndexOf('-'))
            {
                StringBuilder sb = new StringBuilder(line);
                sb[indexer] = ' ';
                line = sb.ToString();
                temp = line.Split('-');
                sb = new StringBuilder(temp[1]);
                sb[indexer] = '-';
                temp[1] = sb.ToString();
            }
            else 
            {
                temp = line.Split('-');
            }
            temp[0] = temp[0].Split('.')[0];
            return temp;
        }

        public void Dispose() 
        { 
        
        }
    }
}
