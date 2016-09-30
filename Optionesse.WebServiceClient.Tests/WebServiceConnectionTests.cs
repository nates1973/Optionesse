using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Optionesse.WebServiceClient;

namespace Optionesse.WebServiceClient.Tests
{
    [TestClass]
    public class WebServiceConnectionTests
    {
        [TestMethod]
        public void WebServiceConnection_ShouldHaveAllConnectionData()
        {
            var expectedEndpoint = "http://marketdata.websol.barchart.com/getQuote.json";
            var expectedKey = "ba0f640f03a015b07cfaf65b12b618ac";
            var connection = new BarchartOnDemandWebServiceConnection();

            Assert.AreEqual(expectedEndpoint, connection.DailyEndpoint.AbsoluteUri, "Unexpected endpoint found.");
            Assert.AreEqual(expectedKey, connection.Key, "Unexpected key found.");
        }
    }
}
