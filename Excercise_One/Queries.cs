using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public static class Queries
    {
        public static void QuerriesOptions(List<Users> users, List<LogData> logList)
        {
            bool flagChoiceIsWrong = false;
            Console.WriteLine();
            Console.WriteLine("Choose an option ");
            while (flagChoiceIsWrong == false)
            {
                Console.WriteLine("1. Show me the logs with error\n2. Show me the logs with warnings\n3. Show me the logs with info\n4. Show me the users mentioned in the logs");
                Console.WriteLine();
                var choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        LogsQueries.ShowMeErrorLogs(logList);
                        break;
                    case "2":
                        LogsQueries.ShowMeWarningLogs(logList);
                        break;
                    case "3":
                        LogsQueries.ShowMeSucceededLogs(logList);
                        break;
                    case "4":
                        LogsQueries.ShowMeUsersNames(users);
                        break;

                    default:
                        flagChoiceIsWrong= true;
                        Console.WriteLine("Goodbye!!!");
                        break;
                }
                Console.WriteLine();
            }
            
        }
        


    }
}
