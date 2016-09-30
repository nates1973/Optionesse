using System;
using System.Net.Http;

namespace Optionesse.WebServiceClient
{
    public interface IHttpService
    {
        Uri BaseAddress { get; }
        HttpResponseMessage Get(string uri);
    }
}