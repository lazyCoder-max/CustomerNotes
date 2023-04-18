using Application.Common.Mappings;
using Application.Common.Models;
using Application.Formulas.Commands.GetFormula;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFormulas.Commands.Get
{
    public record GetAllCustomerFormulaCommand:IRequest<PaginatedList<CustomerFormulaDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetAllCustomerFormulaCommandHandler : IRequestHandler<GetAllCustomerFormulaCommand, PaginatedList<CustomerFormulaDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetAllCustomerFormulaCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<CustomerFormulaDto>> Handle(GetAllCustomerFormulaCommand request, CancellationToken cancellationToken)
        {
            return await _context.CustomerFormulas.Where(x => x.IsDeleted != true)
                        .ProjectTo<CustomerFormulaDto>(_mapper.ConfigurationProvider)
                        .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
