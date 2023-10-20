using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public interface IDataHandler
    {
        List<LogData> ConvertDataIntoList(string path);
        void GiveMeQuerriesOptions(List<LogData> logList);
    }
}
