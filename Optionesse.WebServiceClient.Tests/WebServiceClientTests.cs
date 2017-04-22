using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Optionesse.DomainLogic;
using Optionesse.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;
using Optionesse.Testing.Utilities;
using Optionesse.Testing.Utilities.Fixtures;
using System.Threading.Tasks;

namespace Optionesse.WebServiceClient.Tests
{
    [TestClass]
    public class WebServiceClientTests
    {
        [TestMethod]
        public void WebServiceClient_ShouldHaveLoginInformation()
        {
            var expectedEndpoint = new Uri("http://marketdata.websol.barchart.com/getHistory.json");
            var expectedKey = "ba0f640f03a015b07cfaf65b12b618ac";
            var mockConnection = new Mock<IWebServiceConnection>();
            var mockConfig = new Mock<IDataRetrievalConfiguration>();
            var mockClient = new Mock<IHttpService>();

            mockConnection.Setup(x => x.DailyEndpoint).Returns(expectedEndpoint);
            mockConnection.Setup(x => x.Key).Returns(expectedKey);

            var connectionObject = mockConnection.Object;
            var sut = new WebServiceClient(mockConfig.Object, mockConnection.Object, mockClient.Object);

            Assert.IsNotNull(sut.Connection);
            Assert.AreEqual(expectedEndpoint, sut.Connection.DailyEndpoint);
            Assert.AreEqual(expectedKey, sut.Connection.Key);
        }

        [TestMethod]
        public void WebServiceClient_ShouldBeAbleToMakeALiveConnection()
        {
            var testDate = DateTime.Parse("7/16/2016");
            var symbol = "AAPL";
            var date = Utilities.GetPreviousTradingDay(testDate);

            var config = WebServiceClientFixtures.GetMockedConfiguration(new List<string> { symbol });
            config.StartDate = testDate;
            var connection = new BarchartOnDemandWebServiceConnection();
            var client = (new HttpServiceFactory(config, connection)).GetService();

            var sut = new WebServiceClient(config, connection, client);

            var data = sut.GetResults();
            Assert.IsNotNull(data);
            Assert.IsTrue(data.Status != TaskStatus.Faulted, "Error in the service call.");
            //TODO: Write More for this test?
        }

        [TestMethod]
        public async Task GetResults_SingleDay_ForSingleSecurity_ShouldReturnCollectionWithOneRecord()
        {
            var mockConfig = WebServiceClientFixtures.GetMockedConfiguration(new List<string> { "AAPL" });
            var mockConnection = WebServiceClientFixtures.GetMockedConnection();
            var mockService = WebServiceClientFixtures.GetMockService(false);
            mockConfig.IsHistory = false;

            var sut = new WebServiceClient(mockConfig, mockConnection, mockService);
            var results = await sut.GetResults();

            Assert.IsNotNull(results, "Results collection is null");
            Assert.AreEqual(1, results.Count(), "No results found");
            var firstRecord = results.First();
            Assert.AreEqual("AAPL", firstRecord.Symbol, "Results found for unexpected security");
            var expectedTradingDate = Utilities.GetPreviousTradingDay(DateTime.Parse("7/23/2016"));
            Assert.AreEqual(expectedTradingDate.Date, firstRecord.TradingDay.Date, "Results found for unexpected trading day");
        }

        [TestMethod]
        public void GetResults_SingleDay_ForMultipleSecurities_ShouldReturnCollectionOfRecords()
        {

        }

        [TestMethod]
        public void GetResults_History_ForSingleSecurity_ShouldReturnCollectionWithOneRecord()
        {

        }

    }
}
