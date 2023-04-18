using DataAccess.Common.Models;
using DataAccess.Enums;
using Fluxor;

namespace DataAccess.Store.MicroChemistryUseCase
{
    [FeatureState]
    public record MicroChemistryState
    {
        public PaginatedList<MicroChemistryDto>? MicroChemistry { get; set; }
        public IList<string> ChemistryType { get; set; }
        public RequestStatus RequestStatus { get; set; } = RequestStatus.Ideal;
    }
}
