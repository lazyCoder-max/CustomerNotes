using DataAccess.Common.Models;
using DataAccess.Enums;
using Fluxor;

namespace DataAccess.Store.CustomerUseCase
{
    [FeatureState]
    public record CustomerState
    {
        public PaginatedList<CustomerDto>? Customers { get; init; }
        public RequestStatus RequestStatus { get; set; }

    }

}
