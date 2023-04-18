using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;

namespace Application.CustomerFormulaTests.Commands.Get
{
    public record GetAllCustomerFormulaTestCommand:IRequest<PaginatedList<CustomerFormulaTestDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetAllCustomerFormulaTestCommandHandler : IRequestHandler<GetAllCustomerFormulaTestCommand, PaginatedList<CustomerFormulaTestDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetAllCustomerFormulaTestCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<CustomerFormulaTestDto>> Handle(GetAllCustomerFormulaTestCommand request, CancellationToken cancellationToken)
        {
            return await _context.CustomerFormulaTests
                        .ProjectTo<CustomerFormulaTestDto>(_mapper.ConfigurationProvider)
                        .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
