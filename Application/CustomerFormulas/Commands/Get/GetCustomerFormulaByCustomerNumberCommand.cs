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

namespace Application.CustomerFormulas.Commands.Get
{
    public record GetCustomerFormulaByCustomerNumberCommand:IRequest<IList<CustomerFormulaDto>>
    {
        public int CustomerNumber { get; set; }
    }
    public class GetCustomerFormulaByCustomerNumberCommandHandler : IRequestHandler<GetCustomerFormulaByCustomerNumberCommand, IList<CustomerFormulaDto>>
    {
        private readonly IMyContext _context;
        private readonly IMapper _mapper;
        public GetCustomerFormulaByCustomerNumberCommandHandler(IMyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<CustomerFormulaDto>> Handle(GetCustomerFormulaByCustomerNumberCommand request, CancellationToken cancellationToken)
        {
            //var sa = await _context.CustomerFormulas.Where(x => x.IsDeleted != true && x.CustomerNumber == request.CustomerNumber)
                         //.ProjectTo<CustomerFormulaDto>(_mapper.ConfigurationProvider).ToListAsync();
            return await _context.CustomerFormulas.Where(x => x.IsDeleted != true && x.CustomerNumber == request.CustomerNumber)
                         .ProjectTo<CustomerFormulaDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
