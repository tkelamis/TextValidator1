using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xml2CSharp;

namespace Excercise_One
{
    public class XmlLogReader : ILogReader
    {
        private IMenu _menu = new Menu();
        public string GetThePathLogs()
        {
            var path = _menu.GiveMeThePath();
            var listOfFiles = _menu.GetListOfFilesFromDirectory(path);
            var pathOfFile = _menu.SelectFileToOpenAndGiveMeItsPath(listOfFiles);
            return pathOfFile;
        }

        public List<LogData> SetValues(string pathOfXmlFiles)
        {
            List<Entry> list = new List<Entry>();
            XmlSerializer serializer = new XmlSerializer(typeof(Log));
            Log logs;
            using (FileStream reader = new FileStream(pathOfXmlFiles, FileMode.Open))
            {
                logs = (Log)serializer.Deserialize(reader);
                foreach (var item in logs.Entry)
                {
                    list.Add(item);
                }
            }

            List<LogData> logDataList = new List<LogData>();

            foreach (var item in list)
            {
                LogData logItem = new LogData();
                logItem.dateTime = DateTime.Parse(item.dateTime);
                logItem.errorType = item.errorType;
                logItem.description = item.description;
                logDataList.Add(logItem);
            }
            return logDataList;
        }

        public void ManipulateData(List<LogData> logList)
        {
            _menu.ChooseCategoryOfLogs(logList);
        }
    }
}
