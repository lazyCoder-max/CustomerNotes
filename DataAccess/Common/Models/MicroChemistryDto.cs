﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common.Models
{
    public class MicroChemistryDto
    {
        public int MicroChemistryId { get; set; }

        public string TestNumber { get; set; } = null!;

        public string? TestName { get; set; }

        public int TestCode { get; set; }

        public string TestType { get; set; } = null!;

        public string AnalysisName { get; set; } = null!;

        public string? MethodReference { get; set; }

        public int? Turnaround { get; set; }

        public string DayType { get; set; } = null!;

        public decimal? Price { get; set; }

        public string? ItemNumber { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
