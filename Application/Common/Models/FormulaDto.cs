using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class FormulaDto : IMapFrom<Formula>
    {
        public int FormulaId { get; set; }

        public string FormulaName { get; set; } = null!;

        public string SearchKey { get; set; } = null!;

        public string? FormulaDescription { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
