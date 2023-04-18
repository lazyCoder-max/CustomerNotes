using DataAccess.Common.Models;
using DataAccess.Enums;
using Fluxor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Store.CustomerUseCase.Actions.FetchCustomers;

namespace DataAccess.Store.FormulaUseCase.Actions
{
    public class FetchFormulas
    {
        public record Action(string? Url = null)
        {
            [ReducerMethod]
            public static FormulaState Reducer(FormulaState state, Action action)
            {
                return state with
                {
                    RequestStatus = Enums.RequestStatus.Loading
                };
            }
        }
        private record Effects()
        {
            [EffectMethod]
            public async Task HandlerAsync(Action action, IDispatcher dispatcher)
            {
                await Task.Yield();
                if(action.Url== null)
                {
                    dispatcher.Dispatch(new ResultAction() { Formulas = null, Request = RequestStatus.Failed });
                    return;
                }
                HttpClient client = new HttpClient();
                string url = action.Url;
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<PaginatedList<FormulaDto>>(responseBody);
                    dispatcher.Dispatch(new ResultAction() { Formulas = result, Request = RequestStatus.Loaded });
                }
            }
        }
        public record ResultAction(PaginatedList<FormulaDto> Formulas = null, RequestStatus Request = RequestStatus.Ideal)
        {
            [ReducerMethod]
            public static FormulaState Reducer(FormulaState state, ResultAction action)
            {
                return state with
                {
                    Formulas = action.Formulas,
                    RequestStatus = action.Request
                };
            }
        }
    }
}
