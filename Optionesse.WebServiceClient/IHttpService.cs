using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Optionesse.WebServiceClient
{
    public interface IHttpService
    {
        Uri BaseAddress { get; }
        Task<HttpResponseMessage> Get(string uri);
    }
}