using System;
using TechTalk.SpecFlow;

namespace Optionesse.DataRetrieval.Specs.DataRetrieval.LoadConfiguration
{
    [Binding]
    public class LoadConfigurationSteps
    {
        [Given(@"I have configured daily trades")]
        public void GivenIHaveConfiguredDailyTrades()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have configured to not use date ranges")]
        public void GivenIHaveConfiguredToNotUseDateRanges()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have configured historical trades")]
        public void GivenIHaveConfiguredHistoricalTrades()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have configured to use date ranges")]
        public void GivenIHaveConfiguredToUseDateRanges()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered start date (.*)/(.*)")]
        public void GivenIHaveEnteredStartDate(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have entered an end date (.*)/(.*)")]
        public void GivenIHaveEnteredAnEndDate(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I execute the call to the data source")]
        public void WhenIExecuteTheCallToTheDataSource()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the engine should prepare a daily request with the symbols included")]
        public void ThenTheEngineShouldPrepareADailyRequestWithTheSymbolsIncluded()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the engine should prepare a historical request for each of the symbols")]
        public void ThenTheEngineShouldPrepareAHistoricalRequestForEachOfTheSymbols()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the request should include the specified date ranges")]
        public void ThenTheRequestShouldIncludeTheSpecifiedDateRanges()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
