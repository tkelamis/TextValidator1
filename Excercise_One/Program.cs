using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Xml2CSharp;

namespace Excercise_One
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILogReader logReader = new TxtLogReader();
            try
            {
                var path = logReader.GetThePathLogs();
                var logList = logReader.SetValues(path);
                logReader.ManipulateData(logList);
            }
            catch
            {
                Console.WriteLine("The file could not open!!");
            }
        }
    }
}
