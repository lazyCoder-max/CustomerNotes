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

namespace DataAccess.Store.CustomerFormulaTestUseCase.Actions
{
    public class FetchCustomerFormulaTests
    {
        public record Action(string? Url = null)
        {
            [ReducerMethod]
            public static CustomerFormulaTestState Reducer(CustomerFormulaTestState state, Action action)
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
                        dispatcher.Dispatch(new ResultAction() { CustomerFormulaTest = null, Request = RequestStatus.Failed });
                        return;
                    }
                    HttpClient client = new HttpClient();
                    string url = action.Url;
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<IList<CustomerFormulaTestDto>>(responseBody);
                        dispatcher.Dispatch(new ResultAction() { CustomerFormulaTest = result, Request = RequestStatus.Completed });
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public record ResultAction(IList<CustomerFormulaTestDto> CustomerFormulaTest = null, RequestStatus Request = RequestStatus.Ideal)
        {
            [ReducerMethod]
            public static CustomerFormulaTestState Reducer(CustomerFormulaTestState state, ResultAction action)
            {
                return state with
                {
                    CustomerFormulaTests = action.CustomerFormulaTest,
                    RequestStatus = action.Request
                };
            }
        }
    }
}
