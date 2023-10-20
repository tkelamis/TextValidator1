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
            IFileHandler fileHandle = new TxtFilesHandler();
            //IDataHandler dataHandle = new LogHandler();

            try
            {
                var pathOfFile = fileHandle.GiveMeThePath();
                var list = fileHandle.GetListOfFilesFromDirectory(pathOfFile);
                string pathOfLogs = fileHandle.SelectFileToOpenAndGiveMeThePath(list);

                //var logsList = dataHandle.ConvertDataIntoList(pathOfLogs);
                //dataHandle.GiveMeQuerriesOptions(logsList);

            }
            catch
            {

                Console.WriteLine("Could not read file");
            }

            /*FilesHandler filehandler = new FilesHandler();
            var pathOfFile = filehandler.GiveMeThePath();
            var list = filehandler.GetListOfFilesFromDirectory(pathOfFile);
            string pathOfLogs = filehandler.SelectFileToOpenAndGiveMeThePath(list);

            LogHandler logHandler= new LogHandler();
            var logsList = logHandler.ConvertDataIntoList(pathOfLogs);
            logHandler.GiveMeQuerriesOptions(logsList);*/
        }
    }
}
