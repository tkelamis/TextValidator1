using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_One
{
    public static class SelectFolders
    {
        public static string SelectFileToOpen(List<string> list)
        {
            //flag για επανάληψη σε περίπτωση που δωθεί λάθος επιλογή
            var flagProgrammRunning = true;


            while (flagProgrammRunning)
            {
                //Ζητάει ποιο θέλουμε να ανοίξουμε και το ανοίγω
                string pathOfLogs;
                var choice = true;
                Console.WriteLine();
                Console.WriteLine("Which file you wish to open???");
                Console.WriteLine();
                string input = Console.ReadLine();
                Console.WriteLine();
                switch (input)
                {
                    case "1":
                        System.Diagnostics.Process.Start(list[0]);
                        break;
                    case "2":
                        System.Diagnostics.Process.Start(list[1]);
                        break;
                    case "3":
                        System.Diagnostics.Process.Start(list[2]);
                        break;
                    case "4":
                        //Αν επιλεγεί 4 τότε γυρνάω τo path για να γίνουν οι άλλες διαδικασίες
                        System.Diagnostics.Process.Start(list[3]);
                        pathOfLogs = "C:\\Users\\Y9GGKH726\\Desktop\\Programming\\C#\\Elanis-Course\\filePath\\log.txt";
                        return pathOfLogs;
                }
                while (choice)
                {
                    Console.WriteLine();
                    Console.WriteLine("Want to choose another file to open?");
                    Console.WriteLine();
                    input = Console.ReadLine();
                    Console.WriteLine();
                    switch (input)
                    {
                        case "yes":
                            choice = false;
                            break;
                        case "no":
                            choice = false;
                            flagProgrammRunning = false;
                            break;
                        default:
                            Console.WriteLine("Enter yes or no");
                            Console.WriteLine();
                            break;
                    }
                }
            }
            return null;
        }
    }
}
