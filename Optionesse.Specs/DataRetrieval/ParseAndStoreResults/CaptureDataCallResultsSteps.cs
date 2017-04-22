using Optionesse.DataRetrieval.Specs.Contexts;
using Optionesse.Testing.Utilities.Fixtures;
using System;
using TechTalk.SpecFlow;
using Optionesse.DomainLogic;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optionesse.DataRetrieval.Specs.DataRetrieval.ParseAndStoreResults
{
    [Binding]
    public class CaptureDataCallResultsSteps
    {
        DataServiceCallContext _context;

        public CaptureDataCallResultsSteps(DataServiceCallContext context)
        {
            _context = context;
        }

        [Given(@"I have a properly formatted call to the web service")]
        public async Task GivenIHaveAProperlyFormattedCallToTheWebService()
        {
            await _context.SetUpFakeClient();
        }

        [When(@"I execute the call")]
        public async Task WhenIExecuteTheCall()
        {
            _context.Results = await _context.Client.GetResults();
        }

        [Then(@"I should get a properly-formatted result")]
        public void ThenIShouldGetAProperlyFormattedResult()
        {
            Assert.IsTrue(_context.Results.Count > 0, "No results found");
        }

        [Given(@"The web service is unavailable")]
        public void GivenTheWebServiceIsUnavailable()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should get an empty result")]
        public void ThenIShouldGetAnEmptyResult()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result status should indicate a service outage")]
        public void ThenTheResultStatusShouldIndicateAServiceOutage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
