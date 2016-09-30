using Newtonsoft.Json.Linq;
using Optionesse.Configuration;
using Optionesse.DomainLogic;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optionesse.WebServiceClient
{
    public class WebServiceClient
    {
        public IDataRetrievalConfiguration Configuration { get; private set; }
        public IWebServiceConnection Connection { get; private set; }
        public IHttpService Service { get; private set; }

        public WebServiceClient(IDataRetrievalConfiguration config, IWebServiceConnection connection, IHttpService service)
        {
            Configuration = config;
            Connection = connection;
            Service = service;
        }

        public async Task<List<DailyQuote>> GetResults()
        {
            if (Configuration.IsHistory)
                return await GetHistoryResults();
            else
                return await GetPreviousTradingDayResults();
        }

        private async Task<List<DailyQuote>> GetHistoryResults()
        {
            var results = new List<DailyQuote>();
            Configuration.Securities.ForEach(async s =>
            {
                var query = $"{Connection.HistoryEndpoint}?key={Connection.Key}&symbols={s}&type=daily&startDate={Configuration.StartDate.ToString("yyyyMMdd")}&endDate={Configuration.EndDate.ToString("yyyyMMdd")}";
                var response = Service.Get(query);
                await ParseServiceResults(results, response, true);
            });
            return results;
        }

        private async static Task ParseServiceResults(List<DailyQuote> results, HttpResponseMessage response, bool historicalData = false)
        {
            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsAsync<JToken>();
                foreach (var result in jsonResult["results"].Children())
                {
                    results.Add(new DailyQuote(historicalData, result));
                }
            }
        }

        private async Task<List<DailyQuote>> GetPreviousTradingDayResults()
        {
            var results = new List<DailyQuote>();
            var dateToRetrieve = Utilities.GetPreviousTradingDay();
            var symbolList = string.Join(",", Configuration.Securities);
            var query = $"{Connection.DailyEndpoint}?key={Connection.Key}&symbols={symbolList}&type=daily&startDate={dateToRetrieve.ToString("yyyyMMdd")}";

            var response = Service.Get(query);
            await ParseServiceResults(results, response, false);

            return results;
        }

    }
}
