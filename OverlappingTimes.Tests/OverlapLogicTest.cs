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
        private IList<TimesModel> _testList;
        private DateTime _timeSpanEntryTime;
        private DateTime _timeSpanLeaveTime;
        private int _maxNumberOfVisitors = 0;

        [SetUp]
        public void Setup()
        {
            //Arrange
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            _testList = new List<TimesModel>
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

            _timeSpanEntryTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 00, 00);
            _timeSpanLeaveTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 00, 00);
        }
        
        
        [Test]
        public void TestFindMaxOverlaps()
        {
            //Act
            var returnedList = OverlapLogic.FindMaxOverlaps(_testList).ToList();
            var firstTimeSpan = returnedList.FirstOrDefault();
            if (firstTimeSpan != null)
                _maxNumberOfVisitors = firstTimeSpan.Overlaps;
            var thirdTimeSpan = returnedList[2];


            //Assert
            Assert.IsNotNull(returnedList);
            Assert.IsNotNull(firstTimeSpan);
            Assert.That(returnedList.Count, Is.EqualTo(4));
            Assert.That(_maxNumberOfVisitors, Is.EqualTo(3));

            Assert.That(thirdTimeSpan.EnterTime, Is.EqualTo(_timeSpanEntryTime));
            Assert.That(thirdTimeSpan.LeaveTime, Is.EqualTo(_timeSpanLeaveTime));
        }

    }
}
