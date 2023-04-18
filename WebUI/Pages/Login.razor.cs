using Microsoft.AspNetCore.Components;

namespace WebUI.Pages
{
    public partial class Login
    {
        private string _username;
        private string _password;
        [Inject] private NavigationManager _navigationManager { get; set; }

        private void LoginAsync()
        {
            _navigationManager.NavigateTo("/");
        }
    }
}
