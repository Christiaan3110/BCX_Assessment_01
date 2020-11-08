using System;
using System.Collections.Generic;

namespace BCX_Assessment_01.EF
{
    public partial class CasualRoles
    {
        public CasualRoles()
        {
            CasualEmployees = new HashSet<CasualEmployees>();
        }

        public int CasualRoleId { get; set; }
        public string CasualRole { get; set; }
        public decimal HourlyRateInZar { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual ICollection<CasualEmployees> CasualEmployees { get; set; }
    }
}
