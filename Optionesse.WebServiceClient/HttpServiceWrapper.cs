using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Optionesse.WebServiceClient
{
    public class HttpServiceWrapper : IHttpService
    {
        private HttpClient _httpClientForservice;

        public Uri BaseAddress { get { return _httpClientForservice.BaseAddress; }  }

        public HttpServiceWrapper(HttpClient client)
        {
            _httpClientForservice = client;
        }

        public async Task<HttpResponseMessage> Get(string query)
        {
            var result = await _httpClientForservice.GetAsync(query);
            return result ?? new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.NotFound };
        }
    }

}
