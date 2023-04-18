

using DataAccess.Common.Models;
using DataAccess.Enums;
using Fluxor;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace DataAccess.Store.CustomerUseCase.Actions
{
    public  class FetchCustomers
    {
        public record Action(string? Url =null)
        {
            [ReducerMethod]
            public static CustomerState Reducer(CustomerState state, Action action)
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
                    if(action.Url == null)
                    {
                        dispatcher.Dispatch(new ResultAction() { Customer = null, Request = RequestStatus.Failed });
                        return;
                    }
                    HttpClient client = new HttpClient();
                    string url = action.Url;
                    HttpResponseMessage response = await client.GetAsync(url);
                    if(response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<PaginatedList<CustomerDto>>(responseBody);
                        dispatcher.Dispatch(new ResultAction() { Customer = result, Request = RequestStatus.Completed });
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public record ResultAction(PaginatedList<CustomerDto> Customer  = null, RequestStatus Request = RequestStatus.Ideal)
        {
            [ReducerMethod]
            public static CustomerState Reducer(CustomerState state, ResultAction action)
            {
                return state with
                {
                    Customers = action.Customer,
                    RequestStatus = action.Request
                };
            }
        }
    }
}
