using Optionesse.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Optionesse.WebServiceClient
{
    public class HttpServiceFactory
    {
        private IWebServiceConnection _connection;
        private bool _isHistoryConnection = false;

        public HttpServiceFactory(IDataRetrievalConfiguration config, IWebServiceConnection connection)
        {
            _connection = connection;
            _isHistoryConnection = config.IsHistory;
        }

        public IHttpService GetService()
        {
            if (_connection == null || _connection.DailyEndpoint == null 
                || _connection.HistoryEndpoint == null || _connection.Key == null)
                throw new Exception("Invalid connection object");

            var client = new HttpClient();
            client.BaseAddress = _isHistoryConnection ? _connection.HistoryEndpoint : _connection.DailyEndpoint;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return new HttpServiceWrapper(client);
        }

    }
}