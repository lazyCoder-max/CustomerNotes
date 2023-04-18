using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MicroChemistry.Commands.GetMicroChemistry
{
    public record GetMicroChemistryByTestNumberCommand : IRequest<PaginatedList<MicroChemistryDto>>
    {
        public string TestNumber { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetMicroChemistryByTestNumberCommandHandler : IRequestHandler<GetMicroChemistryByTestNumberCommand, PaginatedList<MicroChemistryDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetMicroChemistryByTestNumberCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<MicroChemistryDto>> Handle(GetMicroChemistryByTestNumberCommand request, CancellationToken cancellationToken)
        {
            return await _context.MicroChemistries.Where(x=>x.IsDeleted!=true && x.TestNumber == request.TestNumber)
                .ProjectTo<MicroChemistryDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
