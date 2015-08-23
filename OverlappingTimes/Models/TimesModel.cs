using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlappingTimes.Models
{
    /// <summary>
    /// Model for visitors entry and leave times.
    /// </summary>
    public class TimesModel
    {
        public DateTime EnterTime { get; set; }
        public DateTime LeaveTime { get; set; }

        public int Overlaps { get; set; } = 0;

        /// <summary>
        /// Check if current time model overlaps with compared time model.
        /// </summary>
        /// <param name="otherModel">The time model current one is compared with.</param>
        /// <returns>Boolean value for overlapping.</returns>
        public bool Intersects(TimesModel otherModel)
        {
            if (EnterTime <= otherModel.LeaveTime && otherModel.EnterTime <= LeaveTime)
                return true;
            
            return false;
        }
    }
}
