using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MicroChemistry.Commands.GetMicroChemistry
{
    public record GetMicroChemistryByTypeCommand:IRequest<PaginatedList<MicroChemistryDto>>
    {
        public string TestType { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetMicroChemistryByTypeCommandHandler : IRequestHandler<GetMicroChemistryByTypeCommand, PaginatedList<MicroChemistryDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetMicroChemistryByTypeCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<PaginatedList<MicroChemistryDto>> Handle(GetMicroChemistryByTypeCommand request, CancellationToken cancellationToken)
        {
            return _context.MicroChemistries.Where(x=>x.IsDeleted!=true && x.TestType == request.TestType)
                .ProjectTo<MicroChemistryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
