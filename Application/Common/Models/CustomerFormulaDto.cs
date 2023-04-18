using Application.Common.Interfaces;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class CustomerFormulaDto:IMapFrom<Domain.Entities.Models.CustomerFormula>
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

        public virtual Customer CustomerNumberNavigation { get; set; } = null!;
    }
}
