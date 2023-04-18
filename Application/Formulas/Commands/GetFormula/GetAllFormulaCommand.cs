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

namespace Application.Formulas.Commands.GetFormula
{
    public record GetAllFormulaCommand: IRequest<PaginatedList<FormulaDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetAllFormulaCommandHandler : IRequestHandler<GetAllFormulaCommand, PaginatedList<FormulaDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetAllFormulaCommandHandler(IMyContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<FormulaDto>> Handle(GetAllFormulaCommand request, CancellationToken cancellationToken)
        {
            return await _context.Formulas.Where(x=>x.IsDeleted !=true)
                        .ProjectTo<FormulaDto>(_mapper.ConfigurationProvider)
                        .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
