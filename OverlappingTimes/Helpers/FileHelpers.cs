using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverlappingTimes.Models;

namespace OverlappingTimes.Helpers
{
    static class FileHelpers
    {
        /// <summary>
        /// Read data from given file path.
        /// </summary>
        /// <param name="path">Path to data input file.</param>
        /// <returns>List of times in file.</returns>
        public static List<TimesModel> GetDataFromFile(string path)
        {
            var timesList = new List<TimesModel>();
            
            if (File.Exists(path) && Path.GetExtension(path) == ".txt")
            {
                // Add @ to path to treat string as is. No escape characters like \n
                string[] allRows = File.ReadAllLines(@path);
                foreach (string[] times in allRows.Select(row => row.Split(',')))
                {
                    try
                    {
                        var enterTime = DateTime.Parse(times[0], CultureInfo.InvariantCulture);
                        var leaveTime = DateTime.Parse(times[1], CultureInfo.InvariantCulture);
                        //When it's already next day
                        if (enterTime > leaveTime)
                        {
                            leaveTime = leaveTime.AddDays(1);
                        }

                        timesList.Add(new TimesModel {EnterTime = enterTime, LeaveTime = leaveTime});
                    }
                    catch (Exception exception)
                    {
                        throw new ArgumentException(exception.Message);
                    }
                }
                return timesList;
            }

            Console.WriteLine("Cannot find .txt file in specified path! Please make sure to specify filename and type(only .txt files allowed)");
            
            return null;
        }
    }
}
