using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Commands.GetCustomer
{
    public record GetAllCustomersCommnd: IRequest<PaginatedList<CustomerDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetAllCustomersCommndHandler : IRequestHandler<GetAllCustomersCommnd, PaginatedList<CustomerDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetAllCustomersCommndHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PaginatedList<CustomerDto>> Handle(GetAllCustomersCommnd request, CancellationToken cancellationToken)
        {
            return await _context.Customers.Where(x => x.IsDeleted != true)
                        .ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                        .PaginatedListAsync(request.PageNumber,request.PageSize);
        }
    }
}
