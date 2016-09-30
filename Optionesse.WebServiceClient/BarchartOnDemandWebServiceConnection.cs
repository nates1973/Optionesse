using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optionesse.WebServiceClient
{
    public class BarchartOnDemandWebServiceConnection : IWebServiceConnection
    {
        public Uri DailyEndpoint { get; } = new Uri("http://marketdata.websol.barchart.com/getQuote.json");

        public Uri HistoryEndpoint { get; } = new Uri("http://marketdata.websol.barchart.com/getHistory.json");

        public string Key { get; } = "ba0f640f03a015b07cfaf65b12b618ac";
    }
}
