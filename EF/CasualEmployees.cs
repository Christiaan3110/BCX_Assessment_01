using System;
using System.Collections.Generic;

namespace BCX_Assessment_01.EF
{
    public partial class CasualEmployees
    {
        public CasualEmployees()
        {
            CasualEmployeesInCasualTasks = new HashSet<CasualEmployeesInCasualTasks>();
        }

        public int CasualEmployeeId { get; set; }
        public int? CasualRoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePicture { get; set; }
        public decimal CurrentHourlyRateInZar { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual CasualRoles CasualRole { get; set; }
        public virtual ICollection<CasualEmployeesInCasualTasks> CasualEmployeesInCasualTasks { get; set; }
    }
}
