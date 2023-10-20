using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public class TxtFilesHandler : IFileHandler
    {
        public string GiveMeThePath()
        {
            Console.WriteLine("Give me the path to the logs...");
            var path = Console.ReadLine();
            Console.WriteLine();
            return path;
        }

        public string SelectFileToOpenAndGiveMeThePath(List<string> list)
        {
            var flagProgrammRunning = true;

            while (flagProgrammRunning)
            {
                //Ζητάει ποιο θέλουμε να ανοίξουμε και το ανοίγω
                Console.WriteLine("\nWhich logs file you want to draw data from???\n");
                string input = Console.ReadLine();
                var numberOfFileToOpen = Convert.ToInt32(input);
                Console.WriteLine();
                string pathOfFile = Path.GetFullPath(list[numberOfFileToOpen-1]);
                if (File.Exists(pathOfFile) ) 
                {
                    flagProgrammRunning = false;
                    return pathOfFile;
                }
                else
                {
                    Console.WriteLine("The file doesn't exist!!");
                }
            }
            return null;
        }

        public List<string> GetListOfFilesFromDirectory(string pathName)
        {
            List<string> filesList = new List<string>();
            int count = 0;

            //'Ελεγχος εαν το given path υπάρχει
            while (!Directory.Exists(pathName))
            {
                Console.WriteLine($"Directory {pathName} does not exist! Give me a right path");
                pathName = Console.ReadLine();
            }

            //Λίστα με όλα τα αρχεία, ανεξαρτήτου είδους
            var names = Directory.GetFiles(pathName);

            //Ξεχωρίζω τα .txt και τα προσθέτω σε λίστα την οποία επιστρέφει η function
            //Το count είναι για να τυπώνω αριθμό μπροστά από το όνομα του αρχείου
            Console.WriteLine("The files contained in this path are:");
            foreach (var file in names)
            {
                if (Path.GetExtension(file) == ".txt")
                {
                    count++;
                    Console.WriteLine("{0}.{1}", count, Path.GetFileNameWithoutExtension(file));
                    filesList.Add(string.Join(@"\", pathName, Path.GetFileName(file)));
                }
            }
            return filesList;
        }
    }
}
