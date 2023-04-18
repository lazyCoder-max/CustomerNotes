

using DataAccess.Enums;
using DataAccess.Store.CustomerFormulaUseCase;
using DataAccess.Store.MicroChemistryUseCase;
using DataAccess.Store.MicroChemistryUseCase.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WebUI.Components.CustomerComponent
{
    public partial class MicroChemistryDialog
    {
        private bool _isExpanded = false;
        private IList<string> ChemistryTypes { get; set; } = new List<string>();
        [Inject] private IState<MicroChemistryState> _state { get; set; }
        [Inject] private IDispatcher _dispatcher { get; set; }
        [Inject] private IActionSubscriber _actionSubscriber { get; set; }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                _dispatcher.Dispatch(new FetchMicroChemistry.Action("http://localhost:5167/api/microchemistry/get-allType",true));
                _actionSubscriber.SubscribeToAction<FetchMicroChemistry.ResultAction>(this, async action =>
                {
                    if(action.ChemistryTypes!=null)
                    {
                        ChemistryTypes = action.ChemistryTypes;
                        StateHasChanged();
                    }
                });
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private void FetchDataAsync(string type)
        {
            _dispatcher.Dispatch(new FetchMicroChemistry.Action($"http://localhost:5167/api/microchemistry/get-ByType?TestType={type}&PageNumber=1&PageSize=100"));
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
            //if (!_isDropZoneDisabled)
            //{
            //    var includedFormula = _CustomerFormulaState.Value?.CustomerFormulas?.Where(x => x.IdentifierStatus == IdentifierStatus.Included);
            //    MudDialog?.Close(DialogResult.Ok<IEnumerable<CustomerFormulaDto>>(includedFormula));
            //}
            //else
            //{
            //    MudDialog?.Close(DialogResult.Ok<IEnumerable<CustomerFormulaDto>>(_CustomerFormulaState.Value.CustomerFormulas));
            //}
        }
    }
}
