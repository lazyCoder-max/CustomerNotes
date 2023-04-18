

namespace DataAccess.Common.Models
{
    public class CustomerFormulaTestDto
    {
        public int CustomerNumber { get; set; }

        public string FormulaName { get; set; } = null!;

        public string TestNumber { get; set; } = null!;

        public virtual CustomerDto CustomerNumberNavigation { get; set; } = null!;

    }
}
