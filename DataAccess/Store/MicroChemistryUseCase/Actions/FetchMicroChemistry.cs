using DataAccess.Common.Models;
using DataAccess.Enums;
using DataAccess.Store.FormulaUseCase;
using Fluxor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Store.MicroChemistryUseCase.Actions
{
    public class FetchMicroChemistry
    {
        public record Action(string? Url=null, bool IsReturnString= false)
        {
            [ReducerMethod]
            public static MicroChemistryState Reducer(MicroChemistryState state,Action action)
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
                if(string.IsNullOrEmpty(action.Url))
                {
                    dispatcher.Dispatch(new ResultAction() { MicroChemistries = null, Request = RequestStatus.Failed });
                    return;
                }
                HttpClient client = new HttpClient();
                string url = action.Url;
                HttpResponseMessage response = await client.GetAsync(url);

                if(response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if(!action.IsReturnString)
                    {
                        var result = JsonConvert.DeserializeObject<PaginatedList<MicroChemistryDto>>(responseBody);
                        dispatcher.Dispatch(new ResultAction() { MicroChemistries = result, Request = RequestStatus.Loaded });
                    }
                    else
                    {
                        var result = JsonConvert.DeserializeObject<IList<string>>(responseBody);
                        dispatcher.Dispatch(new ResultAction() { ChemistryTypes = result, Request = RequestStatus.Loaded });
                    }
                }
            }
        }
        public record ResultAction(PaginatedList<MicroChemistryDto>? MicroChemistries = null, IList<string>? ChemistryTypes = null, RequestStatus Request = RequestStatus.Ideal)
        {
            [ReducerMethod]
            public static MicroChemistryState Reducer(MicroChemistryState state, ResultAction action)
            {
                return state with
                {
                    MicroChemistry = action.MicroChemistries,
                    ChemistryType = action.ChemistryTypes!,
                    RequestStatus = action.Request
                };
            }
        }
    }
}
