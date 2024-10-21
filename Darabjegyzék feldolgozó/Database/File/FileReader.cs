using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Database.File
{
    public class FileReader : IDisposable
    {
        private StreamReader reader;
        public FileReader(string path) 
        {
            reader = new StreamReader(path);
        }

        public string readALine()
        {
            return reader.ReadLine();
        }

        public List<string> ReadAllLines() 
        {
            List<string> data = new List<string>();
            while (reader.ReadLine() != null)
            {
                data.Add(reader.ReadLine());
            }
            reader.Close();
            return data;    
        }

        public string Read()
        {
            string data = reader.ReadLine();
            reader.Close();
            return data;
        }

        public void Dispose() 
        {
            reader.Close();
        }
    }
}
