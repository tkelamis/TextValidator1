using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public static class LogsQueries
    {
        public static void ShowMeErrorLogs(List<LogData> data)
        {
            //To i είναι μετρηρής για το πόσες περιπτώσεις βρήκα και να το γράφει στο UI
            //Η λίστα φτιάχνεται για να γίνει populate με τις περιπτωσεις και να γίνουν μετά print μέσω foreach
            int i = 0;
            List<LogData> errorList = new List<LogData>();
            
            foreach (var dato in data)
            {
                if (dato.errorType == "ERROR")
                {
                    i++;
                    errorList.Add(dato);
                }
            }

            Console.WriteLine("The {0} logs that failed are:", i);
            foreach (var item in errorList)
            {
                Console.WriteLine("{0} , {1} , {2}", item.description, item.dateTime , item.errorType);

            }
        }
        public static void ShowMeWarningLogs(List<LogData> data)
        { 
            int i = 0;
            List<LogData> warningList = new List<LogData>();
            foreach (var dato in data)
            {
                if (dato.errorType == "WARNING")
                {
                    i++;
                    warningList.Add(dato);
                }
            }

            Console.WriteLine("The {0} logs that have warnings are:", i);
            foreach (var item in warningList)
            {
                Console.WriteLine("{0} , {1} , {2}", item.description, item.dateTime , item.errorType);

            }
        }

        public static void ShowMeSucceededLogs(List<LogData> data)
        {
            int i = 0;
            List<LogData> successList = new List<LogData>();
            foreach (var dato in data)
            {
                if (dato.errorType == "INFO")
                {
                    i++;
                    successList.Add(dato);
                }
            }

            Console.WriteLine("The {0} logs that are succeeded are:", i);
            foreach (var item in successList)
            {
                Console.WriteLine("{0} , {1} , {2}", item.description, item.dateTime, item.errorType);

            }
        }

        public static void ShowMeUsersNames(List<Users> users)
        {
            foreach (var item in users)
            {
                Console.WriteLine(item.name);
            }
        }
    }
}
