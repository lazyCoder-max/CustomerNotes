using DataAccess.Common.Models;
using DataAccess.Enums;
using Fluxor;

namespace DataAccess.Store.FormulaUseCase
{
    [FeatureState]
    public record class FormulaState
    {
        public PaginatedList<FormulaDto>? Formulas { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
