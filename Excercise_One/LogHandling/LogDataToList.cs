using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public static class LogDataToList
    {
        public static List<string> GiveMeTheListOfTheLog(string path)
        {
            List<string> list = new List<string>();

            //Διαβάζω γραμμή γραμμή το αρχείο και αποθηκεύω την κάθε γραμμή σε λίστα και την επιστρέφω
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    list.Add(sr.ReadLine());
                }
            }
            return list;
        }
    }
}
