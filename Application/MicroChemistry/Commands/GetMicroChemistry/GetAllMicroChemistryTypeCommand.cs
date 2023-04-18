using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.MicroChemistry.Commands.GetMicroChemistry
{
    public record GetAllMicroChemistryTypeCommand:IRequest<IList<string>>
    {

    }
    public class GetAllMicroChemistryTypeCommandHandler : IRequestHandler<GetAllMicroChemistryTypeCommand, IList<string>>
    {
        private readonly IMyContext _context;
        public GetAllMicroChemistryTypeCommandHandler(IMyContext context)
        {
            _context = context;
        }
        public async Task<IList<string>> Handle(GetAllMicroChemistryTypeCommand request, CancellationToken cancellationToken)
        {
            return await _context.MicroChemistries.Where(x => x.IsDeleted != true).Select(y => y.TestType).Distinct().ToListAsync();
        }
    }
}
