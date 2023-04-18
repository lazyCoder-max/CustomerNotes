using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.Entities;
using Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Commands.GetCustomer
{
    public record GetCustomerByIdCommand: IRequest<CustomerDto>
    {
        public int CustomerId { get; init; }

    }
    public class GetCustomerByIdCommandHandler : IRequestHandler<GetCustomerByIdCommand, CustomerDto>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetCustomerByIdCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer { CustomerId = request.CustomerId };
            var result =  await _context.Customers.Where(x=>x == entity).ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).FirstAsync(cancellationToken);
            return result;
        }
    }
}
