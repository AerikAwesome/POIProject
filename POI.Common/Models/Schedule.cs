using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POI.Common.Models
{
    public class Schedule
    {
        //See page https://docs.microsoft.com/en-us/sql/relational-databases/system-tables/dbo-sysschedules-transact-sql?redirectedfrom=MSDN&view=sql-server-ver15 for documentation

        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public int FrequencyInterval { get; set; }
        public FrequencySubDayType FrequencySubDayType { get; set; }
        public int FrequencySubDayInterval { get; set; }
        public FrequencyRelativeInterval FrequencyRelativeInterval { get; set; }
        public int FrequencyRecurrenceFactor { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public enum FrequencyType
    {
        Single = 1,
        Daily = 4,
        Weekly = 8,
        Monthly = 16,
        MonthlyRelative = 32
    }

    public enum FrequencySubDayType
    {
        Specified = 1,
        Seconds = 2,
        Minutes = 4,
        Hours = 8
    }

    public enum FrequencyRelativeInterval
    {
        Unused = 0,
        First = 1,
        Second = 2,
        Third = 4,
        Fourth = 8,
        Last = 16
    }
}
