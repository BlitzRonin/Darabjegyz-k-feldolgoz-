using Darabjegyzék_feldolgozó.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darabjegyzék_feldolgozó.Factory
{
    public class Statistics
    {
        private DatabaseInterface database;
        public Statistics(DatabaseInterface @interface) 
        {
            database = @interface;
        }
        public int biggest_count(string id)
        {
            return countit(searchit(id));
        }

        public int biggest_count(int relation)
        {
            return countit(relation);
        }

        private int searchit(string id)
        {
            int index = -1;
            for (int i = 0; i < database.GetDatabase.Count; i++)
            {
                if (database.GetDatabase[i].Id == id)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private int countit(int id)
        {
            int biggest = -1;
            for (int i = 0; i < database.GetDatabase[id].MainParts.Count; i++)
            {
                if (database.GetDatabase[id].MainParts[i].Main.Level > biggest)
                {
                    biggest = database.GetDatabase[id].MainParts[i].Main.Level;
                }
                if (database.GetDatabase[id].MainParts[i].SubParts != null)
                {
                    for (int j = 0; j < database.GetDatabase[id].MainParts[i].SubParts.Count; j++)
                    {
                        if (database.GetDatabase[id].MainParts[i].SubParts[j].Level > biggest)
                        {
                            biggest = database.GetDatabase[id].MainParts[i].SubParts[j].Level;
                        }
                    }
                }
            }
            return biggest;
        }
    }
}
