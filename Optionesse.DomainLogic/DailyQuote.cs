using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optionesse.DomainLogic
{
    public class DailyQuote
    {
        public string Symbol { get; set; }
        public DateTime TradingDay { get; set; }
        public Double Open { get; set; }
        public Double High { get; set; }
        public Double Low { get; set; }
        public Double Close { get; set; }
        public int Volume { get; set; }

        public DailyQuote(bool isHistory, JToken oneDayData)
        {
            Symbol = (string)oneDayData["symbol"];
            Open = double.Parse((string)oneDayData["open"]);
            High = double.Parse((string)oneDayData["high"]);
            Low = double.Parse((string)oneDayData["low"]);
            Close = double.Parse((string)oneDayData["close"]);
            Volume = int.Parse((string)oneDayData["volume"]);
            TradingDay = DateTime.Parse(isHistory ?
                (string)oneDayData["tradingDay"]
                : (string)oneDayData["tradeTimestamp"]);
        }
    }
}
