﻿using System;
using System.Collections.Generic;

namespace Optionesse.Configuration
{
    public interface IDataRetrievalConfiguration
    {
        bool IsHistory { get; set; }
        List<string> Securities { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool UseDateRange { get; set; }

        void AddRange(DateTime startDate, DateTime endDate);
    }
}