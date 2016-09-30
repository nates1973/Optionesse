using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Optionesse.Testing.Utilities
{
    public class TestData
    {
        public static HttpResponseMessage GetFakeData(bool historical)
        {
            var json = historical ? GetHistoryJToken() : GetDailyJToken();
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(json.ToString(),
                    System.Text.Encoding.Default,
                    "application/json")
            };
        }

        public static JToken GetHistoryJToken()
        {
            return JObject.Parse(@"{
                        ""status"": {
                            ""code"": 200,
                            ""message"": ""Success.""
                        },
                        ""results"": [
                            {
                              ""symbol"": ""AAPL"",
                              ""timestamp"": ""2016-07-21T23:00:00-05:00"",
                              ""tradingDay"": ""2016-07-22"",
                              ""open"": 99.26,
                              ""high"": 99.3,
                              ""low"": 98.31,
                              ""close"": 98.66,
                              ""volume"": 28313600,
                              ""openInterest"": null
                            }
                          ]
                       }");
        }

        public static JToken GetDailyJToken()
        {
            return JObject.Parse(@"{
                        ""status"": {
                            ""code"": 200,
                            ""message"": ""Success.""
                        },
                        ""results"": [
                            {
                              ""symbol"": ""AAPL"",
                              ""tradeTimestamp"": ""2016-07-21T23:00:00-05:00"",
                              ""open"": 99.26,
                              ""high"": 99.3,
                              ""low"": 98.31,
                              ""close"": 98.66,
                              ""volume"": 28313600,
                              ""openInterest"": null
                            }
                          ]
                       }");
        }


    }
}
