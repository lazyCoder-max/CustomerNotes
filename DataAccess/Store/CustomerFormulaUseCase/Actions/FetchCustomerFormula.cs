using DataAccess.Common.Models;
using DataAccess.Enums;
using DataAccess.Store.CustomerUseCase;
using Fluxor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Store.CustomerFormulaUseCase.Actions
{
    public class FetchCustomerFormula
    {
        public record Action(string? Url = null)
        {
            [ReducerMethod]
            public static CustomerFormulaState Reducer(CustomerFormulaState state, Action action)
            {
                return state with
                {
                    RequestStatus = Enums.RequestStatus.Loading
                };
            }
        }
        private record Effects()
        {
            [EffectMethod()]
            public async Task HandlerAsync(Action action, IDispatcher dispatcher)
            {
                try
                {
                    await Task.Yield();
                    if (action.Url == null)
                    {
                        dispatcher.Dispatch(new ResultAction() { CustomerFormula = null, Request = RequestStatus.Failed });
                        return;
                    }
                    HttpClient client = new HttpClient();
                    string url = action.Url;
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<IList<CustomerFormulaDto>>(responseBody);
                        result.Where(x => x.IsIncludedMicro == true).ToList().ForEach(a =>a.IdentifierStatus = IdentifierStatus.Included);
                        dispatcher.Dispatch(new ResultAction() { CustomerFormula = result, Request = RequestStatus.Completed });
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public record ResultAction(IList<CustomerFormulaDto> CustomerFormula = null, RequestStatus Request = RequestStatus.Ideal)
        {
            [ReducerMethod]
            public static CustomerFormulaState Reducer(CustomerFormulaState state, ResultAction action)
            {
                return state with
                {
                    CustomerFormulas = action.CustomerFormula,
                    RequestStatus = action.Request
                };
            }
        }
    }
}
