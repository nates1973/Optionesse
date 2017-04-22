using System.Collections.Generic;
using System.Threading.Tasks;
using Optionesse.Configuration;
using Optionesse.DomainLogic;

namespace Optionesse.WebServiceClient
{
    public interface IWebServiceClient
    {
        IDataRetrievalConfiguration Configuration { get; }
        IWebServiceConnection Connection { get; }
        IHttpService Service { get; }
        string Query { get; set; }

        Task<List<DailyQuote>> GetResults();
    }
}