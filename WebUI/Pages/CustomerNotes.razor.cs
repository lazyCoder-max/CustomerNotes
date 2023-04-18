using DataAccess.Common.Models;
using DataAccess.Store.CustomerUseCase;
using DataAccess.Store.CustomerUseCase.Actions;
using DataAccess.Store.FormulaUseCase.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WebUI.Components.CustomerComponent;

namespace WebUI.Pages
{
    public partial class CustomerNotes
    {
        [Inject] private ISnackbar Snackbar { get; set; }
        [Inject] private IDispatcher _dispatcher { get; set; }
        [Inject] private IState<CustomerState> customerState { get; set; }
        [Inject] private IActionSubscriber _actionSubscriber { get; set; }
        [Inject] IDialogService _dialogService { get; set; }

        private bool _microChemistryCheck = false;
        private bool _flavourRequirmentCheck = false;
        private bool _kosher = false;
        private CustomerDto? _customerDto;


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _dispatcher.Dispatch(new FetchCustomers.Action("http://localhost:5167/api/customer/get-all?PageNumber=1&PageSize=9000"));
                _actionSubscriber.SubscribeToAction<FetchCustomers.ResultAction>(this, action =>
                {
                    if(action.Customer!=null)
                    {
                        StateHasChanged();
                    }
                });
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        private readonly IList<string> _filterTags = new List<string>()
        {
            "Customer Name","Customer No","Territory"
        };

        private async Task MicroChemistryAsync(bool isChecked)
        {
            if(_customerDto== null)
            {
                Snackbar.Add("Select a Customer First!", Severity.Warning);
                return;
            }
            if (isChecked)
            {
                _microChemistryCheck = isChecked;
                StateHasChanged();
                //var param = new DialogParameters() { ["CustomerNumber"] = _customerDto.CustomerNumber};
                //var dialog = _dialogService.Show<FormulaComponent>("Formula",parameters:param, options: new DialogOptions() { FullWidth = true, CloseButton = true, CloseOnEscapeKey = true, Position = DialogPosition.Center, DisableBackdropClick = true });
                //var result = await dialog.Result;
                //if (result.Data != null)
                //{
                //    var formulaDialog = result.Data as IEnumerable<FormulaDto>;
                //    if (formulaDialog!.Any())
                //    {
                //        // Data Included
                //        Snackbar.Add("Formula Data Addded", Severity.Success);
                //        _microChemistryCheck = true;
                //    }
                //}
                //else if (result.Cancelled)
                //    _microChemistryCheck = false;

            }
            else
            {
                _microChemistryCheck = isChecked;
            }
        }
        private bool FilterFunc1(CustomerDto customer) => FilterFunc(element: customer, _customerDto);
        private bool FilterFunc(CustomerDto element, CustomerDto searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString.CustomerName))
                return true;
            if (element.CustomerNumber.ToString().Contains(searchString.CustomerNumber.ToString(), StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.CustomerName.Contains(searchString.CustomerName, StringComparison.OrdinalIgnoreCase))
                return true;
            if (element.Region.Contains(searchString.Region, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private void OnSearchChanged(CustomerDto newValue)
        {
            _customerDto = newValue;
        }
        private void UpdateFilter(string newFilter)
        {

        }
    }
}
