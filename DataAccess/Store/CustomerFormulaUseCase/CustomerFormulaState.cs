using DataAccess.Common.Models;
using DataAccess.Enums;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Store.CustomerFormulaUseCase
{
    [FeatureState]
    public record CustomerFormulaState
    {
        public IList<CustomerFormulaDto>? CustomerFormulas { get; init; }
        public RequestStatus RequestStatus { get; set; }
    }
}
