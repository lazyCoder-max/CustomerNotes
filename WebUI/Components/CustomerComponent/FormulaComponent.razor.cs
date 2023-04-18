using DataAccess.Common.Models;
using DataAccess.Enums;
using DataAccess.Store.CustomerFormulaUseCase;
using DataAccess.Store.CustomerFormulaUseCase.Actions;
using DataAccess.Store.FormulaUseCase;
using DataAccess.Store.FormulaUseCase.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WebUI.Components.CustomerComponent
{
    public partial class FormulaComponent
    {
        [Parameter]
        public int CustomerNumber { get; set; }
        [Inject] private IState<CustomerFormulaState> _CustomerFormulaState { get; set; }
        [Inject] private IDispatcher _Dispatcher { get; set; }
        [Inject] private IActionSubscriber _ActionSubscriber { get; set; }
        [Inject] IDialogService _dialogService { get; set; }
        private bool _isProceedDisabled = true;
        private bool _isDropZoneDisabled = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();   
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
               if(CustomerNumber>0)
                {
                    _Dispatcher.Dispatch(new FetchCustomerFormula.Action($"http://localhost:5167/api/customer-formula/get-ByCustomerNumber?CustomerNumber={CustomerNumber}"));
                    _ActionSubscriber.SubscribeToAction<FetchCustomerFormula.ResultAction>(this, async action =>
                    {
                        if (action.CustomerFormula != null)
                            StateHasChanged();
                    });
                }
            }
            await base.OnAfterRenderAsync(firstRender);
        }
        private void UpdateDraggedItems(MudItemDropInfo<CustomerFormulaDto> dropItem)
        {
            switch (dropItem.DropzoneIdentifier)
            {
                case "Included":
                    dropItem.Item.IdentifierStatus = IdentifierStatus.Included;
                    break;
                case "Excluded":
                    dropItem.Item.IdentifierStatus = IdentifierStatus.Excluded;
                    break;
            }
            _isProceedDisabled = _CustomerFormulaState.Value.CustomerFormulas.Count(x => x.IdentifierStatus == IdentifierStatus.Included) >= 1 ? false : true;
        }
        private void AllCheckedChanged(bool isChecked)
        {
            _isDropZoneDisabled = isChecked;
            _isProceedDisabled = _isDropZoneDisabled == true ? false : true;
        }
        private async Task ShowCustomerFormulaTestsAsync(string formulaName)
        {
            var param = new DialogParameters() { ["FormulaName"] = formulaName, ["CustomerNumber"] = CustomerNumber  };
            var dialog = _dialogService.Show<CustomerFormulaTestComponent>($"{formulaName}: Tests", parameters: param, options: new DialogOptions() { FullWidth = true, CloseButton = true, CloseOnEscapeKey = true, Position = DialogPosition.Center, DisableBackdropClick = true, MaxWidth = MaxWidth.Medium });
            var result = await dialog.Result;
            if (result.Data != null)
            {
                var formulaDialog = result.Data as IEnumerable<CustomerFormulaTestDto>;
                if (formulaDialog!.Any())
                {
                    // Data Included;
                }
            }
        }

        private void CloseDialog()
        {
            //MudDialog?.Close(DialogResult.Cancel());
        }
        private void Submit()
        {
            //if(!_isDropZoneDisabled)
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
