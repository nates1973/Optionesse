using Moq;
using Optionesse.Configuration;
using Optionesse.DomainLogic;
using Optionesse.WebServiceClient;
using Optionesse.Testing.Utilities.Fixtures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Text;
using Optionesse.Testing.Utilities;
using Optionesse.DataRetrieval.Specs.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optionesse.DataRetrieval.Specs.RequestData
{
    [Binding]
    public class GenerateDataServiceCallsSteps
    {
        DataServiceCallContext _context;
        string _expectedQuery = string.Empty;

        public GenerateDataServiceCallsSteps(DataServiceCallContext context)
        {
            _context = context;
        }

        [Given(@"I have entered the following symbols into the configuration")]
        public async Task GivenIHaveEnteredTheFollowingSymbolsIntoTheConfiguration(Table table)
        {
            await _context.SetUpFakeClient();
            _context.Parameters = table;
            _expectedQuery = _context.GetExpectedQuery();
        }

        [Given(@"I have entered security symbol '(.*)' into the configuration")]
        public async Task GivenIHaveEnteredSecuritySymbolIntoTheConfiguration(string symbol)
        {
            await _context.SetUpFakeClient();
            var parameters = new Table(new string[] { "symbol" });
            parameters.AddRow(new string[] { symbol });
            _context.Parameters = parameters;
            _expectedQuery = _context.GetExpectedQuery(symbol);
        }

        [When(@"I run the data retrieval process")]
        public async Task WhenIRunTheDataRetrievalProcess()
        {
            await _context.Client.GetResults();
        }

        [Then(@"a properly formatted data call is generated for those parameters")]
        public void ThenAProperlyFormattedDataCallIsGeneratedForThoseParameters()
        {
            _context.Service.Verify();
            _context.Configuration.Verify();
           // Assert.AreEqual(_expectedQuery, _context.Client.Query);
        }

        [Given(@"I have configured previous day data mode")]
        public void GivenIHaveConfiguredPreviousDayDataMode()
        {
            _context.Configuration.Object.IsHistory = false;
        }

        [Given(@"I have configured historical data mode")]
        public void GivenIHaveConfiguredHistoricalDataMode()
        {
            _context.Configuration.Object.IsHistory = true;
        }

    }
}
