using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public interface ILogReader
    {
        string GetThePathLogs();
        List<LogData> SetValues(string path);
        void ManipulateData(List<LogData> logList);
    }
}
