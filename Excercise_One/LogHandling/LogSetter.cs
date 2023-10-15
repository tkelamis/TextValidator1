using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public class LogSetter
    {
        int i = -1;
        DataExtraction extractor = new DataExtraction();

        //φτιάχνω μια λίστα LogData κενή. Με την foreach δημιουργώ log objects και τα προσθέτω στην λίστα
        //Από την λίστα με τα log(που έφτιαξα σε προηγούμενο βήμα) κάνω extract τα data και τα καταχωρώ στα αντίστοιχα properties του κάθε log
        //Και επιστρέφω την λίστα των log
        List<LogData> logsList = new List<LogData>();
        public List<LogData> SetValues(List<string> list)
        {
            foreach (var item in list)
            {
                i++;
                LogData log = new LogData();
                logsList.Add(log);
                log.dateTime = extractor.GetDateTime(i,list);
                log.errorType = extractor.GetErrorType(i, list);
                log.description = extractor.GetDescription(i, list);
            }
            /*foreach (var item in logsList)
            {
                Console.WriteLine(" {0} , {1} , {2} ",item.errorType , item.dateTime , item.description);
            }*/
            return logsList;
        }
	}
}
