using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Optionesse.Testing.Utilities;

namespace Optionesse.DomainLogic.Tests
{
    [TestClass]
    public class SingleDayRecordTests
    {
        [TestMethod]
        public void Constructor_ShouldAcceptJTokenObject()
        {
            var jtoken = TestData.GetHistoryJToken();
            var sut = new DailyQuote(true, jtoken["results"].First);

            var mockResults = jtoken["results"].First;
            var mockSymbol = (string)mockResults["symbol"];
            var mockTradingDay = DateTime.Parse((string)mockResults["tradingDay"]);
            var mockOpen = double.Parse((string)mockResults["open"]);
            var mockHigh = double.Parse((string)mockResults["high"]);
            var mockLow = double.Parse((string)mockResults["low"]);
            var mockClose = double.Parse((string)mockResults["close"]);
            var mockVolume = int.Parse((string)mockResults["volume"]);

            Assert.AreEqual(mockSymbol, sut.Symbol, "Invalid Symbol");
            Assert.AreEqual(mockTradingDay, sut.TradingDay, "Invalid Trading Day");
            Assert.AreEqual(mockOpen, sut.Open, "Invalid Open");
            Assert.AreEqual(mockHigh, sut.High, "Invalid High");
            Assert.AreEqual(mockLow, sut.Low, "Invalid Low");
            Assert.AreEqual(mockClose, sut.Close, "Invalid Close");
            Assert.AreEqual(mockVolume, sut.Volume, "Invalid Volume");

        }
    }
}
