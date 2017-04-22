using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using Optionesse.Testing.Utilities.Fixtures;
using System.Collections.Generic;
using Optionesse.Configuration;

namespace Optionesse.WebServiceClient.Tests
{
    [TestClass]
    public class HttpClientFactoryTests
    {
        [TestMethod]
        public void CreateClient_FromInjectedDependencies_ShouldCreateHttpClientObject()
        {
            var expectedUri = new Uri("http://www.fake.com/getResults.json");
            var mockConfig = WebServiceClientFixtures.GetMockedConfiguration(new List<string> { "AAPL" });
            var mockConnection = WebServiceClientFixtures.GetMockedConnection();
            var sut = new HttpServiceFactory(mockConfig, mockConnection);

            var client = sut.GetService();
            Assert.IsNotNull(client);
            Assert.IsInstanceOfType(client, typeof(IHttpService));
            Assert.AreEqual(expectedUri, client.BaseAddress);
        }

        [TestMethod]
        public void CreateClient_WithLiveDependencies_ShouldCreateLiveClient()
        {
            var configuration = new DataRetrievalConfiguration();
            var connection = new BarchartOnDemandWebServiceConnection();
            var sut = new HttpServiceFactory(configuration, connection);

            var client = sut.GetService();

            Assert.IsNotNull(client);
            Assert.IsInstanceOfType(client, typeof(IHttpService));
            Assert.AreEqual(connection.DailyEndpoint, client.BaseAddress);
        }
    }
}
