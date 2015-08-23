using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OverlappingTimes.Business;
using OverlappingTimes.Models;

namespace OverlappingTimes.Tests
{
    [TestFixture]
    public class TimesModelTest
    {
        
        [Test]
        public void TestIntersect()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var timesModel1 = new TimesModel {EnterTime = new DateTime(year, month, day, 11, 00, 00), LeaveTime = new DateTime(year, month, day, 12, 00, 00)};
            var timesModel2 = new TimesModel {EnterTime = new DateTime(year, month, day, 11, 30, 00), LeaveTime = new DateTime(year, month, day, 13, 00, 00)};
            var timesModel3 = new TimesModel {EnterTime = new DateTime(year, month, day, 10, 30, 00), LeaveTime = new DateTime(year, month, day, 10, 50, 00)};
            var timesModel4 = new TimesModel {EnterTime = new DateTime(year, month, day, 09, 30, 00), LeaveTime = new DateTime(year, month, day, 15, 00, 00)};

            var isOverlapping = timesModel1.Intersects(timesModel2);
            Assert.IsTrue(isOverlapping);
            isOverlapping = timesModel1.Intersects(timesModel3);
            Assert.IsFalse(isOverlapping);
            isOverlapping = timesModel4.Intersects(timesModel2);
            Assert.IsTrue(isOverlapping);

        }
    }
}
