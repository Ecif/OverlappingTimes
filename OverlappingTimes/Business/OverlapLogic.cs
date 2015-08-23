using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OverlappingTimes.Models;

namespace OverlappingTimes.Business
{
    static class OverlapLogic
    {
        /// <summary>
        /// Find overlapped times.
        /// </summary>
        /// <param name="timesList">List of entry and leave times.</param>
        /// <returns>The most overlapped times in list.</returns>
        public static IEnumerable<TimesModel> FindMaxOverlaps(IList<TimesModel> timesList)
        {
            int maxOverlaps = 1;
            IList<TimesModel> overlapPeriodsFound = new List<TimesModel>();

            var orderedList = timesList.OrderBy(x => x.EnterTime).ToList();

            foreach (var currentTime in orderedList)
            {
                var numberOfOverlaps = 1;
                var timePeriodModel = new TimesModel();
  
                foreach (var comparedTime in orderedList.Where(x => x != currentTime))
                {
                    //Check whether times overlap.
                    if (currentTime.Intersects(comparedTime))
                    {
                        numberOfOverlaps++;

                        timePeriodModel.EnterTime = currentTime.EnterTime;
                        timePeriodModel.LeaveTime = currentTime.LeaveTime;

                        // Change Enter Time to ComparedTime model Enter Time for accurate beginning.
                        if (currentTime.EnterTime < comparedTime.EnterTime)
                        {
                            timePeriodModel.EnterTime = comparedTime.EnterTime;
                        }

                        // ComparedTime model Leave Time is less than CurrentTime model Leave Time therefore, we need to
                        // change Leave Time to Compared Time model Leave Time and decrement overlapping for further checking.
                        if (currentTime.LeaveTime > comparedTime.LeaveTime)
                        {
                            timePeriodModel.LeaveTime = comparedTime.LeaveTime;
                            numberOfOverlaps--;
                        }
                    }                                        
                }
                //Continue foreach when there is nothing to add.
                if (numberOfOverlaps < maxOverlaps) continue;

                //Change maximum number of overlaps and add TimeModel to found periods
                maxOverlaps = numberOfOverlaps;
                timePeriodModel.Overlaps = maxOverlaps;
                overlapPeriodsFound.Add(timePeriodModel);
            }

            return overlapPeriodsFound.OrderBy(x => x.EnterTime).Where(x => x.Overlaps.Equals(maxOverlaps));
        }
    }
}
