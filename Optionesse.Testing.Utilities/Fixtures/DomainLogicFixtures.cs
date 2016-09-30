using Newtonsoft.Json.Linq;
using Optionesse.DomainLogic;

namespace Optionesse.Testing.Utilities.Fixtures
{
    public class DomainLogicFixtures
    {
        public static DailyQuote GetSingleDayRecordFixture() {
            var historicalData = true;
            return new DailyQuote(historicalData, TestData.GetHistoryJToken());
        }
    }
}
