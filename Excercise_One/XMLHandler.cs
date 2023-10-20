using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public class XMLHandler //: IDataHandler
    {
        /*public List<XMLData> ConvertLogsIntoList(string path)
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
            List<XMLData> xmlList = new List<XMLData>();
            int i = -1;
            foreach (var item in list)
            {
                i++;
                XMLData xml = new XMLData();
                xmlList.Add(xml);
                xml.row
            }
            return logsList;
        }*/
        public void GiveMeQuerriesOptions(List<XMLData> list)
        {
            {
                Console.WriteLine("Want to see the XML data?  1.Yes or 2.No");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1) 
                {
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

    }
}
