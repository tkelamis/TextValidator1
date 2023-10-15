using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public class DataExtraction
    {

        //Κάνω extract από την κάθε γραμμή αυτό που χρειάζομαι στο αντίστοιχο type
        public DateTime GetDateTime(int i, List<string> list)
        {
            DateTime dateTime = Convert.ToDateTime(list[i].Substring(0, 19));
            return dateTime;
        }
        public string GetErrorType(int i, List<string> list)
        {
            string trimed_errorType = Convert.ToString(list[i].Remove(0,22));
            string finalErrorType = trimed_errorType.Remove(trimed_errorType.LastIndexOf("-")-1);
            return finalErrorType;
        }
        public string GetDescription(int i, List<string> list)
        {
            string description = Convert.ToString(list[i].Remove(0, list[i].LastIndexOf("-") + 2));
            return description;
        }

    }
}
