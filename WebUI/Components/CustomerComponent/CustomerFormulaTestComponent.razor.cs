using DataAccess.Common.Models;
using DataAccess.Store.CustomerFormulaTestUseCase;
using DataAccess.Store.CustomerFormulaTestUseCase.Actions;
using DataAccess.Store.MicroChemistryUseCase;
using DataAccess.Store.MicroChemistryUseCase.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq;

namespace WebUI.Components.CustomerComponent
{
    public partial class CustomerFormulaTestComponent
    {
        [Parameter]
        public string FormulaName { get; set; }
        [Parameter]
        public int CustomerNumber { get; set; }
        private IList<IGrouping<string,CustomerFormulaTestDto>> Tests { get; set; } = new List<IGrouping<string, CustomerFormulaTestDto>>();
        [Inject] private IState<MicroChemistryState> _microchemistryState { get; set; }
        [Inject] private IState<CustomerFormulaTestState> _state { get; set; }
        [Inject] private IDispatcher _dispatcher { get; set; }
        [Inject] private IActionSubscriber _actionSubscriber { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _dispatcher.Dispatch(new FetchCustomerFormulaTests.Action($@"http://localhost:5167/api/customer-formula-test/get-ByFormulaName?FormulaName={FormulaName}"));
                _actionSubscriber.SubscribeToAction<FetchCustomerFormulaTests.ResultAction>(this, async action =>
                {
                    if (action.CustomerFormulaTest != null)
                    {
                        Tests = action.CustomerFormulaTest.Where(x=>x.CustomerNumber== CustomerNumber).GroupBy(x=>x.TestNumber).ToList();
                        StateHasChanged();
                    }
                });
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        private void FetchDataAsync(string testNumber)
        {
            _dispatcher.Dispatch(new FetchMicroChemistry.Action($"http://localhost:5167/api/microchemistry/get-ByTestNumber?TestNumber={testNumber}"));
            _actionSubscriber.SubscribeToAction<FetchMicroChemistry.ResultAction>(this, async action =>
            {
                StateHasChanged();
            });
        }

        private void CloseDialog()
        {
            MudDialog?.Close(DialogResult.Cancel());
        }
        private void Submit()
        {
            
        }
    }
}
