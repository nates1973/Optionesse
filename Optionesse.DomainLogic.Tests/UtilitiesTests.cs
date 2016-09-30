using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optionesse.DomainLogic.Tests
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void GetPreviousTradingDay_ShouldGetCorrectTradingDayForAnyDay()
        {
            //Everything should resolve to the previous Friday
            var expectedPreviousDay = DateTime.Parse("7/15/2016");
            var regularTestDay = DateTime.Parse("7/16/2016"); //Saturday
            var sunday = DateTime.Parse("7/17/2016");
            var monday = DateTime.Parse("7/18/2016");
            Assert.AreEqual(expectedPreviousDay, Utilities.GetPreviousTradingDay(regularTestDay));
            Assert.AreEqual(expectedPreviousDay, Utilities.GetPreviousTradingDay(sunday));
            Assert.AreEqual(expectedPreviousDay, Utilities.GetPreviousTradingDay(monday));
        }
    }
}
