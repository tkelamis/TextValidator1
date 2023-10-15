using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Excercise_One
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Find, choose and open a folder
            Console.WriteLine("Give me the path...");
            var path = Console.ReadLine();
            Console.WriteLine();
            var foldersInDirectory = FindFolders.GetFilesFromDirectory(path);

            
            var pathToLogs = SelectFolders.SelectFileToOpen(foldersInDirectory);
            
            //Αν παραπάνω επιλεγεί 4 ξεκινάω την διαχείρηση των logs
            if (pathToLogs!=null)
            {
                // Load log in list
                var list = LogDataToList.GiveMeTheListOfTheLog(pathToLogs);

                // Create and populate the Logs list
                LogSetter setter = new LogSetter();
                var logsList = setter.SetValues(list);

                // Create and populate the Logs list
                var usersList = UserExtractor.ExtractUsers(logsList);

                
                Queries.QuerriesOptions(usersList, logsList);



            }



            //LogsQueries.ShowMeErrorLogs(logsList);
            //LogsQueries.ShowMeWarningLogs(logsList);
            //LogsQueries.ShowMeSucceededLogs(logsList);
            //LogsQueries.ShowMeUsersNames(usersList);


        }
        }
}
