using System;

namespace Optionesse.WebServiceClient
{
    public interface IWebServiceConnection
    {
        Uri HistoryEndpoint { get;  }
        Uri DailyEndpoint { get; }
        string Key { get; }
    }
}