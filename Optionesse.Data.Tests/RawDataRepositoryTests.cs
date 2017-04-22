using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Raven.Client;
using Optionesse.DomainLogic;
using Raven.Client.Linq;

namespace Optionesse.Data.Tests
{
    [TestClass]
    public class RawDataRepositoryTests
    {
        Mock<IDocumentStore> _docStoreMock;
        Mock<IDocumentSession> _docSessionMock;

        [TestInitialize]
        public void Setup()
        {
            _docStoreMock = new Mock<IDocumentStore>();
            _docSessionMock = new Mock<IDocumentSession>();
            _docStoreMock.Setup(x => x.OpenSession()).Returns(_docSessionMock.Object);
        }

        [TestMethod]
        public void GetDailyDataForSymbol_ShouldReturnListOfDailyQuoteObjects()
        {
            //setup mock database functions
            var mockQuery = new Mock<IRavenQueryable<DailyQuote>>();
            _docSessionMock.Setup(s => s.Query<DailyQuote>()).Returns(mockQuery.Object);

            //bind repository to mock database
            var sut = new RawDataRepository(_docStoreMock.Object);

            var results = sut.GetDailyDataForSymbol("AAPL");

            Assert.AreEqual();

        }
    }
}
