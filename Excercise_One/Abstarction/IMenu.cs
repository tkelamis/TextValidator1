using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public interface IMenu
    {
        string GiveMeThePath();
        string SelectFileToOpenAndGiveMeItsPath(List<string> list);
        List<string> GetListOfFilesFromDirectory(string pathName);
        void ChooseCategoryOfLogs(List<LogData> logList);
    }
}
