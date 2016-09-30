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

        public HttpResponseMessage Get(string query)
        {
            return _httpClientForservice.GetAsync(query).Result ?? new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.NotFound };
        }
    }

}
