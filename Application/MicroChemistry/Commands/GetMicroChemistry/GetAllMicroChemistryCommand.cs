using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.MicroChemistry.Commands.GetMicroChemistry
{
    public record GetAllMicroChemistryCommand : IRequest<PaginatedList<MicroChemistryDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetAllMicroChemistryCommandHandler : IRequestHandler<GetAllMicroChemistryCommand, PaginatedList<MicroChemistryDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetAllMicroChemistryCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<MicroChemistryDto>> Handle(GetAllMicroChemistryCommand request, CancellationToken cancellationToken)
        {
            return await _context.MicroChemistries.Where(x=>x.IsDeleted != true)
                .ProjectTo<MicroChemistryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
