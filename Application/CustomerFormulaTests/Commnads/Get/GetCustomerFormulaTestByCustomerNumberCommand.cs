using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CustomerFormulaTests.Commands.Get
{
    public record GetCustomerFormulaTestByCustomerNumberCommand:IRequest<IList<CustomerFormulaTestDto>>
    {
        public int CustomerNumber { get; set; }
    }
    public class GetCustomerFormulaTestByCustomerNumberCommandHandler : IRequestHandler<GetCustomerFormulaTestByCustomerNumberCommand, IList<CustomerFormulaTestDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetCustomerFormulaTestByCustomerNumberCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<CustomerFormulaTestDto>> Handle(GetCustomerFormulaTestByCustomerNumberCommand request, CancellationToken cancellationToken)
        {
            return await _context.CustomerFormulaTests.Where(x=> x.CustomerNumber == request.CustomerNumber)
                         .ProjectTo<CustomerFormulaTestDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
