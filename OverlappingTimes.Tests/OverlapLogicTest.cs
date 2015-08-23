using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OverlappingTimes.Business;
using OverlappingTimes.Models;

namespace OverlappingTimes.Tests
{

    [TestFixture]
    public class OverlapLogicTest
    {
        public IList<TimesModel> TestList1;

        [SetUp]
        void Setup()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            TestList1 = new List<TimesModel>
            {
                new TimesModel {EnterTime = new DateTime(year, month, day, 11,00,00), LeaveTime = new DateTime(year, month, day,16,00,00)},
                new TimesModel {EnterTime = new DateTime(year, month, day,13,00,00), LeaveTime = new DateTime(year, month, day,15,00,00)},
                new TimesModel {EnterTime = new DateTime(year, month, day,02,00,00), LeaveTime = new DateTime(year, month, day,04,00,00)},
                new TimesModel {EnterTime = new DateTime(year, month, day,01,00,00), LeaveTime = new DateTime(year, month, day,02,00,00)},
                new TimesModel {EnterTime = new DateTime(year, month, day,09,00,00), LeaveTime = new DateTime(year, month, day,10,00,00)},
                new TimesModel {EnterTime = new DateTime(year, month, day,08,00,00), LeaveTime = new DateTime(year, month, day,09,00,00)},
                new TimesModel {EnterTime = new DateTime(year, month, day,10,00,00), LeaveTime = new DateTime(year, month, day,12,00,00)},
                new TimesModel {EnterTime = new DateTime(year, month, day,06,00,00), LeaveTime = new DateTime(year, month, day,14,00,00)}
            };
        }
        
        
        [Test]
        public void TestFindMaxOverlaps()
        {
            var returnedList = OverlapLogic.FindMaxOverlaps(TestList1).ToList();
            Assert.IsNotNull(returnedList);
            Assert.IsNotNull(returnedList.FirstOrDefault());
            Assert.That(returnedList.Count, Is.EqualTo(4));
            Assert.That(returnedList.FirstOrDefault().Overlaps, Is.EqualTo(3));

            var thirdTimeSpan = returnedList[2];
            Assert.That(thirdTimeSpan.EnterTime, Is.EqualTo(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 00,00)));
            Assert.That(thirdTimeSpan.LeaveTime, Is.EqualTo(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12,00,00)));
        }

    }
}
