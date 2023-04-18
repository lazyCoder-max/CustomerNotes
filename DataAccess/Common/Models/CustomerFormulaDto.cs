using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common.Models
{
    public class CustomerFormulaDto
    {
        public int CustomerNumber { get; set; }

        public string FormulaName { get; set; } = null!;

        public DateTime? DateLastSold { get; set; }

        public bool? AddToOrder { get; set; }

        public bool? IsIncludedMicro { get; set; }

        public bool? IsIncludedKosher { get; set; }

        public bool? IsIncludedHalal { get; set; }

        public bool? IsOrganicComp { get; set; }

        public bool? IsOrganicCert { get; set; }

        public bool? IsAllergen { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual CustomerDto CustomerNumberNavigation { get; set; } = null!;
        public IdentifierStatus IdentifierStatus { get; set; } = IdentifierStatus.Excluded;

    }
}
