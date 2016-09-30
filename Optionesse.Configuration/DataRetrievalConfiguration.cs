using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optionesse.Configuration
{
    public class DataRetrievalConfiguration : IDataRetrievalConfiguration
    {
        public List<string> Securities { get; set; } = new List<string>();
        public bool UseDateRange { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsHistory { get; set; } = false;


        public void AddRange(DateTime startDate, DateTime endDate)
        {
            if (startDate == null || endDate == null)
            {
                UseDateRange = false;
                return;
            }

            IsHistory = true;
            UseDateRange = true;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
