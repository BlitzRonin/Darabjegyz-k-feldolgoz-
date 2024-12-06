using Darabjegyzék_feldolgozó.Database.Types.Filters;
using Darabjegyzék_feldolgozó.Database.Types.Machines;
using Darabjegyzék_feldolgozó.Database.Types.Statistics.Compare;
using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darabjegyzék_feldolgozó.Factories.Statistics
{
    public class CompareBoms
    {
        //Ha a mode igaz akkor különbséget keres;
        public List<CompareElements> ResultA { get { return resultA; } }
        public List<CompareElements> ResultB { get { return resultB; } }

        private List<CompareElements> resultA;
        private List<CompareElements> resultB;
        private FilterHandler filter;

        public CompareBoms(FilterHandler filter)
        { 
            this.filter = filter;
        }

        public void Compare(DMachine A, DMachine B)
        {
            comparethem(ref A.Parts, ref B.Parts, ref resultA, ref resultB);
        }

        private void comparethem(ref List<Part> listA, ref List<Part> listB, ref List<CompareElements> currentresA, ref List<CompareElements> currentresB)
        {
            currentresA = new List<CompareElements>();
            currentresB = new List<CompareElements>();
            pack(fit(getthemdata(listA), getthemdata(listB), ref listA,ref listB), ref currentresA, ref currentresB);
            advancebigger(ref listA,ref listB,ref currentresA, ref currentresB, getthemdata(listA), getthemdata(listB));
        }

        private void onlyone(ref List<Part> list, ref List<CompareElements> currentres)
        {
            currentres = new List<CompareElements>();
            for (int i = 0; i < list.Count; i++)
            {
                currentres.Add(new CompareElements("different"));
                if (list[i].Parts != null)
                {
                    onlyone(ref list[i].Parts, ref currentres[i].relation);
                }
            }
        }

        private void advance(ref List<Part> listA, ref List<Part> listB, bool aisbigger,ref List<CompareElements> currentresA, ref List<CompareElements> currentresB, Dictionary<string, List<int>> bigger, Dictionary<string, List<int>> smaller)
        {
            do
            {
                if (bigger.ContainsKey(smaller.ElementAt(0).Key))
                {
                    bool timetokill = true;
                    do
                    {
                        if (bigger[smaller.ElementAt(0).Key].Count != 0)
                        {
                            int indexA;
                            int indexB;
                            if (aisbigger)
                            {
                                indexA = bigger[smaller.ElementAt(0).Key][0];
                                indexB = smaller.ElementAt(0).Value[0];
                            }
                            else
                            {
                                indexB = bigger[smaller.ElementAt(0).Key][0];
                                indexA = smaller.ElementAt(0).Value[0];
                            }
                            if (listA[indexA].Parts != null && listB[indexB].Parts != null)
                            {
                                comparethem(ref listA[indexA].Parts, ref listB[indexB].Parts, ref currentresA[indexA].relation, ref currentresB[indexB].relation);
                            }
                            else
                            {
                                if(listA[indexA].Parts != null)
                                {
                                    onlyone(ref listA[indexA].Parts, ref currentresA[indexA].relation);
                                }
                                else if(listB[indexB].Parts != null)
                                {
                                    onlyone(ref listB[indexB].Parts, ref currentresB[indexB].relation);
                                }
                            }                          
                            smaller.ElementAt(0).Value.RemoveAt(0);
                            bigger[smaller.ElementAt(0).Key].RemoveAt(0);
                        }
                        if (bigger[smaller.ElementAt(0).Key].Count == 0)
                        {
                            bigger.Remove(smaller.ElementAt(0).Key);
                            timetokill = false;
                        }
                        if (smaller.ElementAt(0).Value.Count == 0)
                        {
                            smaller.Remove(smaller.ElementAt(0).Key);
                            timetokill = false;
                        }
                    }
                    while (timetokill);
                }
                else
                {
                    do
                    {
                        if (aisbigger)
                        {
                            if (listB[smaller.ElementAt(0).Value[0]].Parts != null)
                            {
                                onlyone(ref listB[smaller.ElementAt(0).Value[0]].Parts, ref currentresB[smaller.ElementAt(0).Value[0]].relation);
                            }
                        }
                        else
                        {
                            if (listA[smaller.ElementAt(0).Value[0]].Parts != null)
                            {
                                onlyone(ref listA[smaller.ElementAt(0).Value[0]].Parts, ref currentresA[smaller.ElementAt(0).Value[0]].relation);
                            }
                        }
                        smaller.ElementAt(0).Value.RemoveAt(0);
                    } while (smaller.ElementAt(0).Value.Count != 0);
                    if (smaller.ElementAt(0).Value.Count == 0)
                    {
                        smaller.Remove(smaller.ElementAt(0).Key);
                    }
                }
            } while (smaller.Count != 0);
            while (bigger.Count != 0)
            {
                if (!aisbigger)
                {
                    if (listB[bigger.ElementAt(0).Value[0]].Parts != null)
                    {
                        onlyone(ref listB[bigger.ElementAt(0).Value[0]].Parts, ref currentresB[bigger.ElementAt(0).Value[0]].relation);
                    }
                }
                else
                {
                    if (listA[bigger.ElementAt(0).Value[0]].Parts != null)
                    {
                        onlyone(ref listA[bigger.ElementAt(0).Value[0]].Parts, ref currentresA[bigger.ElementAt(0).Value[0]].relation);
                    }
                }
                bigger.ElementAt(0).Value.RemoveAt(0);
                if (bigger.ElementAt(0).Value.Count == 0)
                {
                    bigger.Remove(bigger.ElementAt(0).Key);
                }
            }
        }

        private void advancebigger(ref List<Part> listA, ref List<Part> listB, ref List<CompareElements> currentresA, ref List<CompareElements> currentresB, Dictionary<string, List<int>> A, Dictionary<string, List<int>> B)
        {
            if (listA.Count > listB.Count)
            {
                advance(ref listA, ref listB, true, ref currentresA, ref currentresB, A, B);
            }
            else
            {
                advance(ref listA, ref listB, false, ref currentresA, ref currentresB, B,  A);
            }
        }

        private Dictionary<string,List<int>> getthemdata(List<Part> thislist)
        {
            Dictionary<string, List<int>> data = new Dictionary<string, List<int>>();
            for(int i = 0;i< thislist.Count;i++)
            {
                if (!data.ContainsKey(thislist[i].Id))
                {
                    data.Add(thislist[i].Id, new List<int>());
                }
                data[thislist[i].Id].Add(i);
            }
            return data;
        }

        private List<CompareResults> fit(Dictionary<string, List<int>> A, Dictionary<string, List<int>> B, ref List<Part> listA, ref List<Part> listB)
        {
            if (listA.Count > listB.Count)
            {
                return contains(A, B, true, ref listA, ref listB);
            }
            else
            {
                return contains(B, A, false, ref listA, ref listB);
            }
        }

        private List<CompareResults> contains(Dictionary<string, List<int>> bigger, Dictionary<string, List<int>> smaller, bool aisbigger, ref List<Part> listA, ref List<Part> listB)
        {
            List<CompareResults> result = new List<CompareResults>();
            do
            {
                if (bigger.ContainsKey(smaller.ElementAt(0).Key))
                {
                    bool timetokill = true;
                    do
                    {
                        if (bigger[smaller.ElementAt(0).Key].Count != 0)
                        {
                            int byhowmuch = 0;
                            if (bigger[smaller.ElementAt(0).Key][0] > smaller.ElementAt(0).Value[0])
                            {
                                byhowmuch = bigger[smaller.ElementAt(0).Key][0] + 1 - result.Count;
                            }
                            else
                            {
                                byhowmuch = smaller.ElementAt(0).Value[0] + 1 - result.Count;
                            }
                            if (byhowmuch > 1)
                            {
                                for (int i = 0; i < byhowmuch - 1; i++)
                                {
                                    result.Add(new CompareResults());
                                }
                                result.Add(new CompareResults());
                                if (aisbigger)
                                {
                                    Abigger(ref result, ref bigger, ref smaller, ref listA, ref listB);
                                }
                                else
                                {
                                    Bbigger(ref result, ref bigger, ref smaller, ref listA, ref listB);
                                }
                            }
                            else if (byhowmuch == 1)
                            {
                                result.Add(new CompareResults());
                                if (aisbigger)
                                {
                                    Abigger(ref result, ref bigger, ref smaller, ref listA, ref listB);
                                }
                                else
                                {
                                    Bbigger(ref result, ref bigger, ref smaller, ref listA, ref listB);
                                }
                            }
                            else
                            {
                                if (aisbigger)
                                {
                                    Abigger(ref result, ref bigger, ref smaller, ref listA, ref listB);
                                }
                                else
                                {
                                    Bbigger(ref result, ref bigger, ref smaller, ref listA, ref listB);
                                }
                            }
                            smaller.ElementAt(0).Value.RemoveAt(0);
                            bigger[smaller.ElementAt(0).Key].RemoveAt(0);
                        }
                        if (bigger[smaller.ElementAt(0).Key].Count == 0)
                        {
                            bigger.Remove(smaller.ElementAt(0).Key);
                            timetokill = false;
                        }
                        if (smaller.ElementAt(0).Value.Count == 0)
                        {
                            smaller.Remove(smaller.ElementAt(0).Key);
                            timetokill = false;
                        }
                    }
                    while (timetokill);
                }
                else
                {
                    do
                    {
                        int byhowmuch = smaller.ElementAt(0).Value[0] + 1 - result.Count;
                        if (byhowmuch > 1)
                        {
                            for (int i = 0; i < byhowmuch - 1; i++)
                            {
                                result.Add(new CompareResults());
                            }
                            result.Add(new CompareResults());
                            if (aisbigger)
                            {
                                result[result.Count - 1].B = "different";
                            }
                            else
                            {
                                result[result.Count - 1].A = "different";
                            }
                        }
                        else if (byhowmuch == 1)
                        {
                            result.Add(new CompareResults());
                            if (aisbigger)
                            {
                                result[result.Count - 1].B = "different";
                            }
                            else
                            {
                                result[result.Count - 1].A = "different";
                            }
                        }
                        else
                        {
                            if (aisbigger)
                            {
                                result[smaller.ElementAt(0).Value[0]].B = "different";
                            }
                            else
                            {
                                result[smaller.ElementAt(0).Value[0]].A = "different";
                            }
                        }
                        smaller.ElementAt(0).Value.RemoveAt(0);
                    } 
                    while (smaller.ElementAt(0).Value.Count != 0);
                    if (smaller.ElementAt(0).Value.Count == 0)
                    {
                        smaller.Remove(smaller.ElementAt(0).Key);
                    }
                }
            } while (smaller.Count != 0);
            while (bigger.Count != 0)
            {
                int byhowmuch = bigger.ElementAt(0).Value[0] + 1 - result.Count;
                if (byhowmuch > 1)
                {
                    for (int i = 0; i < byhowmuch - 1; i++)
                    {
                        result.Add(new CompareResults());
                    }
                    result.Add(new CompareResults());
                    if (aisbigger)
                    {
                        result[result.Count - 1].A = "different";
                    }
                    else
                    {
                        result[result.Count - 1].B = "different";
                    }
                }
                else if (byhowmuch == 1)
                {
                    result.Add(new CompareResults());
                    if (aisbigger)
                    {
                        result[result.Count - 1].A = "different";
                    }
                    else
                    {
                        result[result.Count - 1].B = "different";
                    }
                }
                else
                {
                    if (aisbigger)
                    {
                        result[bigger.ElementAt(0).Value[0]].A = "different";
                    }
                    else
                    {
                        result[bigger.ElementAt(0).Value[0]].B = "different";
                    }
                }
                bigger.ElementAt(0).Value.RemoveAt(0);
                if (bigger.ElementAt(0).Value.Count == 0)
                {
                    bigger.Remove(bigger.ElementAt(0).Key);
                }
            }
            return result;
        }

        private void Abigger(ref List<CompareResults> result,ref Dictionary<string,List<int>> bigger,ref Dictionary<string,List<int>> smaller,ref List<Part> listA, ref List<Part> listB)
        {
            if (listA[bigger[smaller.ElementAt(0).Key][0]].Quantity != listB[smaller.ElementAt(0).Value[0]].Quantity || theyarentthesame(listA[bigger[smaller.ElementAt(0).Key][0]].Parts, listB[smaller.ElementAt(0).Value[0]].Parts))
            {
                result[smaller.ElementAt(0).Value[0]].B = "changed";
                result[bigger[smaller.ElementAt(0).Key][0]].A = "changed";
            }
            else
            {
                result[smaller.ElementAt(0).Value[0]].B = "same";
                result[bigger[smaller.ElementAt(0).Key][0]].A = "same";
            }
        }

        private void Bbigger(ref List<CompareResults> result,ref Dictionary<string, List<int>> bigger,ref Dictionary<string, List<int>> smaller, ref List<Part> listA, ref List<Part> listB)
        {
            if (listB[bigger[smaller.ElementAt(0).Key][0]].Quantity != listA[smaller.ElementAt(0).Value[0]].Quantity || theyarentthesame(listA[smaller.ElementAt(0).Value[0]].Parts, listB[bigger[smaller.ElementAt(0).Key][0]].Parts))
            {
                result[smaller.ElementAt(0).Value[0]].A = "changed";
                result[bigger[smaller.ElementAt(0).Key][0]].B = "changed";
            }
            else
            {
                result[smaller.ElementAt(0).Value[0]].A = "same";
                result[bigger[smaller.ElementAt(0).Key][0]].B = "same";
            }
        }

        private void pack(List<CompareResults> fitted, ref List<CompareElements> A, ref List<CompareElements> B)
        {
            for (int i = 0; i < fitted.Count; i++)
            {
                if (fitted[i].A != null)
                {
                    A.Add(new CompareElements(fitted[i].A));
                }
                if(fitted[i].B != null)
                {
                    B.Add(new CompareElements(fitted[i].B));
                }
            }
        }

        private bool theyarentthesame(List<Part> partA,List<Part> partB)
        {
            if (partA != null && partB == null || partA == null && partB != null)
            {
                return true;
            }
            if(partA == null && partB == null)
            {
                return false;
            }
            if(partA.Count != partB.Count)
            {
                return true;
            }
            for(int i = 0;i<partA.Count;i++)
            {
                if (partA[i].Id != partB[i].Id || partA[i].Quantity != partB[i].Quantity)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
