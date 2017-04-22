using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optionesse.DomainLogic
{
    public class Utilities
    {
        public static DateTime GetPreviousTradingDay(DateTime? referenceDate = null)
        {
            var today = DateTime.Today;
            if (referenceDate.HasValue)
                today = referenceDate.Value;
            if (today.DayOfWeek == DayOfWeek.Sunday)
                return today.AddDays(-2);
            if (today.DayOfWeek == DayOfWeek.Monday)
                return today.AddDays(-3);

            return today.AddDays(-1);
        }

    }
}
