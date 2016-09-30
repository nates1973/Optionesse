using Moq;
using Optionesse.Configuration;
using Optionesse.DomainLogic;
using Optionesse.WebServiceClient;
using Optionesse.Testing.Utilities.Fixtures;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Optionesse.DataRetrieval.Specs.RequestData
{
    public class DataServiceCallContext
    {
        public Table Parameters { get; set; }
        public IDataRetrievalConfiguration Configuration { get { return WebServiceClientFixtures.GetMockConfiguration(null); } }
        public Mock<IHttpService> Service { get; set; }
        public WebServiceClient.WebServiceClient Client { get; set; }
        public List<DailyQuote> Results { get; set; }
    }


    [Binding]
    public class GenerateDataServiceCallsSteps
    {
        DataServiceCallContext _context;

        public GenerateDataServiceCallsSteps(DataServiceCallContext context)
        {
            _context = context;
        }

        [Given(@"I have entered the following symbols into the configuration")]
        public async Task GivenIHaveEnteredTheFollowingSymbolsIntoTheConfiguration(Table table)
        {
            await SetUpFakeClient();
            _context.Parameters = table;
        }

        private async Task SetUpFakeClient()
        {
            throw new NotImplementedException();
        }

        [Given(@"I have entered security symbol '(.*)' into the configuration")]
        public async Task GivenIHaveEnteredSecuritySymbolIntoTheConfiguration(string symbol)
        {
            await SetUpFakeClient();
            var parameters = new Table(new string[] { "symbol" });
            parameters.AddRow(new string[] { symbol });
            _context.Parameters = parameters;
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
        }

        [Given(@"I have configured previous day data mode")]
        public void GivenIHaveConfiguredPreviousDayDataMode()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have configured historical data mode")]
        public void GivenIHaveConfiguredHistoricalDataMode()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
