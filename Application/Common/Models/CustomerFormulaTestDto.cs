using Application.Common.Interfaces;
using Domain.Entities.Models;

namespace Application.Common.Models
{
    public class CustomerFormulaTestDto:IMapFrom<CustomerFormulaTest>
    {
        public int CustomerNumber { get; set; }

        public string FormulaName { get; set; } = null!;

        public string TestNumber { get; set; } = null!;

        public virtual CustomerDto CustomerNumberNavigation { get; set; } = null!;

    }
}
