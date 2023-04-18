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

namespace Application.CustomerFormulaTests.Commands.Get
{
    public record GetCustomerFormulaTestByFormulaNameCommand:IRequest<IList<CustomerFormulaTestDto>>
    {
        public string FormulaName { get; set; }
    }
    public class GetCustomerFormulaTestByFormulaNameCommandHandler : IRequestHandler<GetCustomerFormulaTestByFormulaNameCommand, IList<CustomerFormulaTestDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetCustomerFormulaTestByFormulaNameCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<CustomerFormulaTestDto>> Handle(GetCustomerFormulaTestByFormulaNameCommand request, CancellationToken cancellationToken)
        {
            return await _context.CustomerFormulaTests.Where(x=> x.FormulaName == request.FormulaName)
                         .ProjectTo<CustomerFormulaTestDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
