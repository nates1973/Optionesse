using Moq;
using Optionesse.Configuration;
using Optionesse.WebServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optionesse.Testing.Utilities.Fixtures
{
    public class WebServiceClientFixtures
    {
        public static WebServiceClient.WebServiceClient GetMockWebServiceClient()
        {
            var mockConnection = GetMockedConnection();
            var mockConfig = GetMockedConfiguration(new List<string> { "AAPL" });
            var mockService = GetMockService(true);

            return new WebServiceClient.WebServiceClient(mockConfig, mockConnection, mockService);
        }

        public static IWebServiceConnection GetMockedConnection()
        {
            Uri mockEndpoint = GetMockEndpoint();
            var mockConnection = new Mock<IWebServiceConnection>();
            mockConnection.Setup(x => x.DailyEndpoint).Returns(mockEndpoint);
            mockConnection.Setup(x => x.HistoryEndpoint).Returns(mockEndpoint);
            mockConnection.Setup(x => x.Key).Returns("abcdefg12345hijk678");
            return mockConnection.Object;
        }

        public static IWebServiceConnection GetMockedConnection(Uri mockDailyEndpoint, Uri mockHistoryEndpoint)
        {
            Mock<IWebServiceConnection> mockConnection = GetConnectionMockObject(mockDailyEndpoint, mockHistoryEndpoint);
            return mockConnection.Object;
        }

        public static Mock<IWebServiceConnection> GetConnectionMockObject(Uri mockDailyEndpoint, Uri mockHistoryEndpoint)
        {
            var mockConnection = new Mock<IWebServiceConnection>();
            mockConnection.Setup(x => x.DailyEndpoint).Returns(mockDailyEndpoint);
            mockConnection.Setup(x => x.HistoryEndpoint).Returns(mockHistoryEndpoint);
            mockConnection.Setup(x => x.Key).Returns("abcdefg12345hijk678");
            return mockConnection;
        }

        private static Uri GetMockEndpoint()
        {
            return new Uri("http://www.fake.com/getResults.json");
        }

        public static IHttpService GetMockService(bool isHistory)
        {
            var fakeResponse = isHistory ? TestData.GetFakeHistoricalResponse() : TestData.GetFakeDailyResponse();
            var mockService = new Mock<IHttpService>();
            mockService.Setup(x => x.BaseAddress).Returns(GetMockEndpoint());
            mockService.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(fakeResponse));
            return mockService.Object;
        }

        public static Mock<IHttpService> GetServiceMockObject(IDataRetrievalConfiguration config, IWebServiceConnection connection)
        {
            var mockService = new Mock<IHttpService>();
            mockService.Setup(x => x.BaseAddress)
                .Returns(config.IsHistory ? connection.HistoryEndpoint : connection.DailyEndpoint);
            mockService.Setup(x => x.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(TestData.GetFakeDailyResponse()));
            return mockService;
        }

        public static IDataRetrievalConfiguration GetMockedConfiguration(List<string> securities)
        {
            Mock<IDataRetrievalConfiguration> mockConfig = GetConfigurationMockObject(securities);
            return mockConfig.Object;
        }

        public static Mock<IDataRetrievalConfiguration> GetConfigurationMockObject(List<string> securities)
        {
            var mockConfig = new Mock<IDataRetrievalConfiguration>();
            mockConfig.Setup(x => x.UseDateRange).Returns(false);
            mockConfig.SetupProperty(c => c.IsHistory, false);
            mockConfig.SetupProperty(c => c.Securities, securities);
            mockConfig.SetupProperty(c => c.StartDate);
            return mockConfig;
        }

        public static WebServiceClient.WebServiceClient GetMockWebServiceClient(IDataRetrievalConfiguration config)
        {
            var mockConnection = GetMockedConnection();
            var mockService = GetMockService(true);

            return new WebServiceClient.WebServiceClient(config, mockConnection, mockService);
        }

        public static WebServiceClient.WebServiceClient GetLiveWebServiceClient()
        {
            var mockConfig = new Mock<IDataRetrievalConfiguration>();
            var testDate = DateTime.Parse("7/23/2016");
            var symbol = "AAPL";
            var date = DomainLogic.Utilities.GetPreviousTradingDay(testDate);

            mockConfig.SetupProperty(c => c.Securities, new List<string>());
            mockConfig.SetupProperty(c => c.StartDate);
            mockConfig.Object.Securities.Add(symbol);
            mockConfig.Object.StartDate = testDate;

            var connection = new BarchartOnDemandWebServiceConnection();
            var service = (new HttpServiceFactory(mockConfig.Object, connection)).GetService();

            return new WebServiceClient.WebServiceClient(mockConfig.Object, connection, service);
        }
    }
}
