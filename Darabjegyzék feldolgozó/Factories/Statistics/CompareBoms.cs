using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics.Compare;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factories.Statistics
{
    public class CompareBoms
    {
        //Ha a mode igaz akkor különbséget keres;
        public List<CompareElements> ResultA { get { return resultA; } }
        public List<CompareElements> ResultB { get { return resultB; } }

        private List<CompareElements> resultA;
        private List<CompareElements> resultB;

        public void Compare(DMachine A,DMachine B)
        {
            processparts(ref A.Parts, ref B.Parts, ref resultA,ref resultB);
        }

        private void processparts(ref List<Part> listA, ref List<Part> listB,ref List<CompareElements> currentresA, ref List<CompareElements> currentresB)
        {
            if (currentresA == null)
            {
                currentresA = new List<CompareElements>();
            }
            if (currentresB == null)
            {
                currentresB = new List<CompareElements>();
            }
            int first = listA.Count;
            int secound = 0;
            if (listA.Count > listB.Count)
            {
                first = listB.Count;
                secound = listA.Count;
            }
            else if(listB.Count > listA.Count)
            {
                first = listA.Count;
                secound= listB.Count;
            }
            for (int i = 0; i < first; i++)
            {
                currentresA.Add(new CompareElements(CompareTwo(listA[i], listB[i])));
                currentresB.Add(new CompareElements(currentresA[i].Mode));
                if (listA[i].Parts != null && listB[i].Parts != null)
                {
                    processparts(ref listA[i].Parts, ref listB[i].Parts, ref currentresA[i].relation, ref currentresB[i].relation);
                }
                else if(listA[i].Parts != null && listB[i].Parts == null)
                {
                    moveone(ref listA[i].Parts, ref currentresA[i].relation);
                }
                else if(listA[i].Parts == null && listB[i].Parts != null)
                {
                    moveone(ref listB[i].Parts, ref currentresB[i].relation);
                }
            }
            if(secound > 0)
            {
                if(listB.Count>listA.Count)
                {
                    for (int i = first; i < secound; i++)
                    {
                        if (listB[i].Parts != null)
                        {
                            moveone(ref listB[i].Parts, ref currentresB[i].relation);
                        }
                    }
                }
                else
                {
                    for (int i = first; i < secound; i++)
                    {
                        if (listA[i].Parts != null)
                        {
                            moveone(ref listA[i].Parts, ref currentresA[i].relation);
                        }
                    }
                }
            }
        }

        private void moveone(ref List<Part> list, ref List<CompareElements> currentres)
        {
            if(currentres == null)
            {
                currentres = new List<CompareElements>();
            }
            for(int i = 0;i<list.Count;i++)
            {
                currentres.Add(new CompareElements("different"));
                if (list[i].Parts != null)
                {
                    moveone(ref list[i].Parts, ref currentres[i].relation);
                }
            }
        }

        private string CompareTwo(Part A,Part B)
        {
            if (A.Id == B.Id)
            {
                if(A.Quantity != B.Quantity)
                {
                    return "changed";
                }
                return "same";
            }
            else
            {
                return "different";
            }
        } 
    }
}
