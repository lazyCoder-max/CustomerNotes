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

namespace Application.Customers.Commands.GetCustomer
{
    public record GetCustomerByRegionCommand: IRequest<PaginatedList<CustomerDto>>
    {
        public string Region { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetCustomerByRegionCommandHandler : IRequestHandler<GetCustomerByRegionCommand, PaginatedList<CustomerDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetCustomerByRegionCommandHandler(IMyContext myContext, IMapper mapper)
        {
            _context = myContext;
            _mapper = mapper;
        }

        public async Task<PaginatedList<CustomerDto>> Handle(GetCustomerByRegionCommand request, CancellationToken cancellationToken)
        {
            return await _context.Customers.Where(x=>x.Region ==  request.Region)
                .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
