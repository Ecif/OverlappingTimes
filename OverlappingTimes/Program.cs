using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverlappingTimes.Business;
using OverlappingTimes.Helpers;

namespace OverlappingTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (!args.Any()) throw new Exception("Please enter \"overlappingtimes.exe C:\\full\\path\\to\\file.txt\" as input argument for program.");

                string inputPath = args[0];
                
                if (!String.IsNullOrWhiteSpace(inputPath))
                {
                    var timesList = FileHelpers.GetDataFromFile(inputPath);
                    if (timesList == null) throw new Exception();
                    var overlaps = OverlapLogic.FindMaxOverlaps(timesList);

                    foreach (var period in overlaps)
                    {
                        Console.WriteLine($"{period.EnterTime.TimeOfDay}-{period.LeaveTime.TimeOfDay};{period.Overlaps}");
                    }
                    Console.WriteLine("Finished.");

                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine("Press enter to terminate...");
            Console.ReadLine();
        }
    }
}
