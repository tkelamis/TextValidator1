using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public interface IFileHandler
    {
        string GiveMeThePath();
        string SelectFileToOpenAndGiveMeThePath(List<string> list);
        List<string> GetListOfFilesFromDirectory(string pathName);
    }
}
