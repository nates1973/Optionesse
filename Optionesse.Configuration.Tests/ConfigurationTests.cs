using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optionesse.Configuration;
using System;

namespace Optionesse.Configuration.Tests
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void ShouldBeAbleToAddSecuritiesToConfiguration()
        {
            var sut = new DataRetrievalConfiguration();

            sut.Securities.Add("AAPL");

            Assert.IsTrue(sut.Securities.Contains("AAPL"), "Could not add security to configuration.");
        }

        [TestMethod]
        public void ShouldBeAbleToAddSingleDateToConfiguration()
        {
            var sut = new DataRetrievalConfiguration();
            var testDate = DateTime.Today.AddDays(-1);

            sut.StartDate = testDate;

            Assert.IsFalse(sut.UseDateRange);
            Assert.AreEqual(testDate, sut.StartDate);
        }

        [TestMethod]
        public void ShouldBeAbleToAddDateRangesToConfiguration()
        {
            var sut = new DataRetrievalConfiguration();
            var startDate = DateTime.Today.AddDays(-30);
            var endDate = DateTime.Today.AddDays(-1);
            var midDate = DateTime.Today.AddDays(-15);

            sut.AddRange(startDate, endDate);

            Assert.IsTrue(sut.IsHistory);
            Assert.IsTrue(sut.UseDateRange);
            Assert.AreEqual(startDate, sut.StartDate);
            Assert.AreEqual(endDate, sut.EndDate);
        }
    }
}
