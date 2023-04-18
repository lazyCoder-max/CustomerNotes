using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext:IMyContext
    {

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
