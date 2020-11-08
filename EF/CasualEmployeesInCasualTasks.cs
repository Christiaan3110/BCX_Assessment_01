using System;
using System.Collections.Generic;

namespace BCX_Assessment_01.EF
{
    public partial class CasualEmployeesInCasualTasks
    {
        public int CasualEmployeesInCasualTasksId { get; set; }
        public int? CasualEmployeeId { get; set; }
        public int? CasualTaskId { get; set; }
        public DateTime DateLinked { get; set; }
        public DateTime? DateUnlinked { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual CasualEmployees CasualEmployee { get; set; }
        public virtual CasualTasks CasualTask { get; set; }
    }
}
