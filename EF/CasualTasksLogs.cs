using System;
using System.Collections.Generic;

namespace BCX_Assessment_01.EF
{
    public partial class CasualTasksLogs
    {
        public int CasualTasksLogId { get; set; }
        public int? CasualTaskId { get; set; }
        public int? CasualEmployeeId { get; set; }
        public decimal? HoursWorkedForDay { get; set; }
        public DateTime? DayOfWork { get; set; }
        public DateTime? LogEntryDate { get; set; }
    }
}
