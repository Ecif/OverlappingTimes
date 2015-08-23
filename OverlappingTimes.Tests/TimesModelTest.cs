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
            // Arrange
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var timesModel1 = new TimesModel {EnterTime = new DateTime(year, month, day, 11, 00, 00), LeaveTime = new DateTime(year, month, day, 12, 00, 00)};
            var timesModel2 = new TimesModel {EnterTime = new DateTime(year, month, day, 11, 30, 00), LeaveTime = new DateTime(year, month, day, 13, 00, 00)};
            var timesModel3 = new TimesModel {EnterTime = new DateTime(year, month, day, 10, 30, 00), LeaveTime = new DateTime(year, month, day, 10, 50, 00)};
            var timesModel4 = new TimesModel {EnterTime = new DateTime(year, month, day, 09, 30, 00), LeaveTime = new DateTime(year, month, day, 15, 00, 00)};

            // Act
            var isOverlapping1 = timesModel1.Intersects(timesModel2);
            var isOverlapping2 = timesModel1.Intersects(timesModel3);
            var isOverlapping3 = timesModel4.Intersects(timesModel2);

            // Assert
            Assert.IsTrue(isOverlapping1);
            Assert.IsFalse(isOverlapping2);
            Assert.IsTrue(isOverlapping3);

        }
    }
}
