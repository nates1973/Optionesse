using Moq;
using Optionesse.Configuration;
using Optionesse.DomainLogic;
using Optionesse.Testing.Utilities.Fixtures;
using Optionesse.WebServiceClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Optionesse.DataRetrieval.Specs.Contexts
{
    public class DataServiceCallContext
    {
        List<string> _symbolList = new List<string>();

        public Table Parameters { get; set; }
        public Mock<IDataRetrievalConfiguration> Configuration { get; set; }
        public Mock<IHttpService> Service { get; set; }
        public IWebServiceClient Client { get; set; }
        public List<DailyQuote> Results { get; set; }
        public List<string> Symbols
        {
            get
            {
                if (_symbolList.Count == 0)
                    BuildSymbolList();
                return _symbolList;
            }
        }

        private void BuildSymbolList()
        {
            if (Parameters == null || Parameters.RowCount == 0)
                return;
            foreach (var row in Parameters.Rows)
            {
                _symbolList.Add(row["Symbol"]);
            }
        }

        public async Task SetUpFakeClient()
        {
            Configuration = WebServiceClientFixtures.GetConfigurationMockObject(Symbols);
            var moqDailyEndpoint = new Uri("http://www.fakeWebService.com/getQuote.json");
            var moqHistoryEndpoint = new Uri("http://www.fakeWebService.com/getHistory.json");
            var moqConnection = WebServiceClientFixtures.GetConnectionMockObject(moqDailyEndpoint, moqHistoryEndpoint);
            Service = WebServiceClientFixtures.GetServiceMockObject(Configuration.Object, moqConnection.Object);
            var moqClient = new Mock<IWebServiceClient>();
            moqClient.Setup(x => x.Configuration).Returns(Configuration.Object);
            moqClient.Setup(x => x.Connection).Returns(moqConnection.Object);
            moqClient.Setup(x => x.Service).Returns(Service.Object);
            moqClient.Setup(x => x.GetResults()).Returns(Task.FromResult(new List<DailyQuote>()));

            Client = moqClient.Object;
        }

        public string GetExpectedQuery(string currentSymbol = null)
        {
            if (Configuration.Object.IsHistory && string.IsNullOrEmpty(currentSymbol))
                throw new Exception("Attempted to retrieve historical query with no current symbol specified.");

            if (Configuration.Object.IsHistory)
                return GetHistoryQuery(currentSymbol);

            var dateToRetrieve = Utilities.GetPreviousTradingDay();

            return GetDailyQuery(dateToRetrieve, string.Join(",", Symbols));
        }

        private string GetDailyQuery(DateTime dateToRetrieve, string symbolList)
        {
            return $"{Client.Connection.DailyEndpoint}?key={Client.Connection.Key}&symbols={symbolList}&type=daily&startDate={dateToRetrieve.ToString("yyyyMMdd")}";
        }

        private string GetHistoryQuery(string s)
        {
            return $"{Client.Connection.HistoryEndpoint}?key={Client.Connection.Key}&symbols={s}&type=daily&startDate={Configuration.Object.StartDate.ToString("yyyyMMdd")}&endDate={Configuration.Object.EndDate.ToString("yyyyMMdd")}";
        }



    }


}
