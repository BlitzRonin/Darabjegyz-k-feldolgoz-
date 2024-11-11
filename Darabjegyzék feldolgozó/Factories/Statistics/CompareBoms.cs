using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics.Compare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factories.Statistics
{
    public class CompareBoms
    {
        //Ha a mode igaz akkor különbséget keres
        private bool mode;
        private List<CompareMachines> result;
        public List<CompareMachines> Compare(List<DMachine> comparable, bool difference)
        {
            mode = difference;
            result = new List<CompareMachines>();
            List<List<Part>> baseparts = new List<List<Part>>();
            for(int i=0;i<comparable.Count;i++)
            {
                result.Add(new CompareMachines(comparable[i].Id));
                baseparts.Add(comparable[i].Parts);
            }
            processparts(ref baseparts);
            return result;
        }

        private int countmax(List<List<Part>> currpart)
        {
            int max = currpart[0].Count;
            for(int i =1;i<currpart.Count ; i++)
            {
                if (currpart[i].Count > max)
                {
                    max = currpart[i].Count;
                }
            }
            return max;
        }

        private void processparts(ref List<List<Part>> currparts)
        {
            int count = countmax(currparts);
            bool alldoes = false;
            for (int i = 0; i < count; i++)
            {

            }
            if (alldoes == mode)
            {
            
            }
        }

        private bool CompareTwo(Part A,Part B)
        {
            if (A.Item != B.Item && A.Level != B.Level && A.PTYP != B.PTYP && A.Kind != B.Kind && A.UM != B.UM && A.Quantity != B.Quantity && A.Id != B.Id && A.Parts != B.Parts)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
