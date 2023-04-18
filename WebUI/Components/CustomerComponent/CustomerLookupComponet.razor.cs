//using Domain.Entities.Models;
using DataAccess.Common.Models;
using Microsoft.AspNetCore.Components;

namespace WebUI.Components.CustomerComponent
{
    public partial class CustomerLookupComponet
    {
        private string SearchTag { get; set; }
        [Parameter]
        public EventCallback<CustomerDto> SelectionChanged { get; set; }
        [Parameter]
        public IList<string> FilterTags { get; set; }
        private readonly bool _resetValueOnEmptyText = false;
        private readonly bool _coerceText = false;
        private readonly bool _coerceValue = false;
        private bool _selectionChanged = false;
        private string selectedFilter;
        [Parameter]
        public IReadOnlyCollection<CustomerDto> CustomersList { get; set; }
        [Parameter]
        public EventCallback<string> OnFilterChanged { get; set; }

        private async Task<IEnumerable<CustomerDto>> SearchAsync(string name)
        {
            await Task.Delay(500);
            switch (selectedFilter)
            {
                case "Customer Name":
                    return string.IsNullOrEmpty(name) ? CustomersList.Distinct() : CustomersList.Where(x => x.CustomerName.Contains(name, StringComparison.InvariantCultureIgnoreCase)).Distinct();
                case "Customer Number":
                    return string.IsNullOrEmpty(name) ? CustomersList.Distinct() : CustomersList.Where(x => x.CustomerNumber.ToString().Contains(name, StringComparison.InvariantCultureIgnoreCase)).Distinct();
                case "Region":
                    return string.IsNullOrEmpty(name) ? CustomersList.Distinct() : CustomersList.Where(x => x.Region.ToString().Contains(name, StringComparison.InvariantCultureIgnoreCase)).Distinct();
                default:
                    return string.IsNullOrEmpty(name) ? CustomersList.Distinct() : CustomersList.Where(x => x.CustomerName.Contains(name, StringComparison.InvariantCultureIgnoreCase)).Distinct();

            }
            return null;
            
        }
        private async Task SearchChangedHandler(int value)
        {
            SearchTag = value.ToString();
            var result  = CustomersList.FirstOrDefault(x => x.CustomerId == value);
            await SelectionChanged.InvokeAsync(result);
            _selectionChanged = false;
        }
        private async Task HandleSelectedFilterAsync(string filter)
        {
            selectedFilter = filter;
            await OnFilterChanged.InvokeAsync(filter);
        }
    }
}
