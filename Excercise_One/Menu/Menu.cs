using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public class Menu : IMenu
    {
        public string GiveMeThePath()
        {
            Console.WriteLine("Give me the path to the logs...");
            var path = Console.ReadLine();
            Console.WriteLine();
            return path;
        }

        public List<string> GetListOfFilesFromDirectory(string pathName)
        {
            List<string> filesList = new List<string>();
            int count = 0;

            while (!Directory.Exists(pathName))
            {
                Console.WriteLine($"Directory {pathName} does not exist! Give me a right path");
                pathName = Console.ReadLine();
            }

            var names = Directory.GetFiles(pathName);
            Console.WriteLine("The files contained in this path are:");
            foreach (var file in names)
            {
                    count++;
                    Console.WriteLine("{0}.{1}", count, Path.GetFileName(file) );
                    filesList.Add(string.Join(@"\", pathName, Path.GetFileName(file)));
                
            }
            return filesList;
        }
        public string SelectFileToOpenAndGiveMeItsPath(List<string> list)
        {
            var flagProgrammRunning = true;

            while (flagProgrammRunning)
            {
                Console.WriteLine("\nWhich logs file you want to draw data from???\n");
                string input = Console.ReadLine();
                var numberOfFileToOpen = Convert.ToInt32(input);
                Console.WriteLine();
                string pathOfFile = Path.GetFullPath(list[numberOfFileToOpen - 1]);
                if (File.Exists(pathOfFile))
                {
                    flagProgrammRunning = false;
                    return pathOfFile;
                }
                else
                {
                    Console.WriteLine("The file doesn't exist!!");
                }
            }
            return null;
        }

        enum LogType
        {
            ShowErrorLogs = 1,
            ShowWarningLogs,
            ShowInfoLogs,
            ShowUserNames
        }
        public void ChooseCategoryOfLogs(List<LogData> logList)
        {
            bool flagChoiceIsWrong = false;
            while (flagChoiceIsWrong == false)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Show me the logs with error");
                Console.WriteLine("2. Show me the logs with warnings");
                Console.WriteLine("3. Show me the logs with info");
                Console.WriteLine("4. Show me the users mentioned in the logs");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                if (Enum.TryParse<LogType>(Console.ReadLine(), out LogType choice))
                {
                    Console.WriteLine();
                    switch (choice)
                    {
                        case LogType.ShowErrorLogs:
                            ShowMeErrorLogs(logList);
                            break;
                        case LogType.ShowWarningLogs:
                            ShowMeWarningLogs(logList);
                            break;
                        case LogType.ShowInfoLogs:
                            ShowMeSucceededLogs(logList);
                            break;
                        case LogType.ShowUserNames:
                            ShowMeUsersNames(logList);
                            break;
                        default:
                            Console.WriteLine("Goodbye!!!");
                            flagChoiceIsWrong = true;
                            break;
                    }
                }
            }
        }
        private void ShowMeErrorLogs(List<LogData> data)
        {
            int i = 0;
            foreach (var dato in data)
            {
                if (dato.errorType == "ERROR")
                {
                    i++;
                    Console.WriteLine("{0} , {1} , {2}", dato.description, dato.dateTime, dato.errorType);
                }
            }
            Console.WriteLine("Total of {0} logs failed", i);
        }
        private void ShowMeWarningLogs(List<LogData> data)
        {
            int i = 0;
            foreach (var dato in data)
            {
                if (dato.errorType == "WARNING")
                {
                    i++;
                    Console.WriteLine("{0} , {1} , {2}", dato.description, dato.dateTime, dato.errorType);
                }
            }
            Console.WriteLine("Total of {0} logs have warnings", i);
        }
        private void ShowMeSucceededLogs(List<LogData> data)
        {
            int i = 0;
            foreach (var dato in data)
            {
                if (dato.errorType == "INFO")
                {
                    i++;
                    Console.WriteLine("{0} , {1} , {2}", dato.description, dato.dateTime, dato.errorType);
                }
            }
            Console.WriteLine("Total of {0} logs succeeded", i);
        }
        private void ShowMeUsersNames(List<LogData> list)
        {
            List<Users> listOfUsers = ExtractUsers(list);
            foreach (var item in listOfUsers)
            {
                Console.WriteLine(item.name);
            }
        }
        private List<Users> ExtractUsers(List<LogData> list)
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
    }
}
