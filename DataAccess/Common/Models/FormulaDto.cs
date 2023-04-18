using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common.Models
{
    public class FormulaDto
    {
        public int FormulaId { get; set; }

        public string FormulaName { get; set; } = null!;

        public string SearchKey { get; set; } = null!;

        public string? FormulaDescription { get; set; }

        public bool? IsDeleted { get; set; }

        public IdentifierStatus IdentifierStatus { get; set; } = IdentifierStatus.Excluded;
    }
}
