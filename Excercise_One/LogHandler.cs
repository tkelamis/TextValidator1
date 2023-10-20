using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public class LogHandler: IDataHandler
    {
        public List<LogData> ConvertDataIntoList(string path)
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
            List<LogData> logsList = new List<LogData>();
            int i = -1;
            foreach (var item in list)
            {
                i++;
                LogData log = new LogData();
                logsList.Add(log);
                log.dateTime = GetDateTime(i, list);
                log.errorType = GetErrorType(i, list);
                log.description = GetDescription(i, list);
            }
            return logsList;
        }

        public DateTime GetDateTime(int i, List<string> list)
        {
            DateTime dateTime = Convert.ToDateTime(list[i].Substring(0, 19));
            return dateTime;
        }
        public string GetErrorType(int i, List<string> list)
        {
            string trimed_errorType = Convert.ToString(list[i].Remove(0, 22));
            string finalErrorType = trimed_errorType.Remove(trimed_errorType.LastIndexOf("-") - 1);
            return finalErrorType;
        }
        public string GetDescription(int i, List<string> list)
        {
            string description = Convert.ToString(list[i].Remove(0, list[i].LastIndexOf("-") + 2));
            return description;
        }

        public List<Users> ExtractUsers(List<LogData> list)
        {
            List<Users> usersList = new List<Users>();
            foreach (var item in list)
            {
                if (item.description.LastIndexOf("User") != -1)
                {
                    Users user = new Users();
                    //με αυτά κρατάω το όνομα του user
                    var name = Convert.ToString(item.description.Remove(0, 6));
                    var finalName = name.Remove(name.LastIndexOf("'"));
                    //
                    user.name = finalName;
                    usersList.Add(user);
                }
            }
            return usersList;
        }

        public void ShowMeErrorLogs(List<LogData> data)
        {
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
                Console.WriteLine("{0} , {1} , {2}", item.description, item.dateTime, item.errorType);
            }
        }
        public void ShowMeWarningLogs(List<LogData> data)
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
                Console.WriteLine("{0} , {1} , {2}", item.description, item.dateTime, item.errorType);
            }
        }
        public void ShowMeSucceededLogs(List<LogData> data)
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
        public void ShowMeUsersNames(List<LogData> list)
        {
            List<Users> listOfUsers =  ExtractUsers(list);
            foreach (var item in listOfUsers)
            {
                Console.WriteLine(item.name);
            }
        }
        public void GiveMeQuerriesOptions(List<LogData> logList)
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
                        ShowMeErrorLogs(logList);
                        break;
                    case "2":
                        ShowMeWarningLogs(logList);
                        break;
                    case "3":
                        ShowMeSucceededLogs(logList);
                        break;
                    case "4":
                        ShowMeUsersNames(logList);
                        break;

                    default:
                        flagChoiceIsWrong = true;
                        Console.WriteLine("Goodbye!!!");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
