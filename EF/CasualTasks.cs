using System;
using System.Collections.Generic;

namespace BCX_Assessment_01.EF
{
    public partial class CasualTasks
    {
        public CasualTasks()
        {
            CasualEmployeesInCasualTasks = new HashSet<CasualEmployeesInCasualTasks>();
        }

        public int CasualTaskId { get; set; }
        public string CasualTask { get; set; }
        public decimal TimeEstiamteInHours { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual ICollection<CasualEmployeesInCasualTasks> CasualEmployeesInCasualTasks { get; set; }
    }
}
