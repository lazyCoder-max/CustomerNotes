using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace WebUI.Shared
{
    public partial class MainLayout
    {
        [Inject] private NavigationManager _navigationManager { get; set; }
        bool _drawerOpen = true;
        private bool _isDarkMode;
        private string themeToolTipText = "Dark Mode";
        private string currentThemeIcon = Icons.Material.Filled.DarkMode;

        void ChangeTheme()
        {
            if (_isDarkMode)
            {
                _isDarkMode = false;
                currentThemeIcon = Icons.Material.Filled.DarkMode;
                themeToolTipText = "Dark Mode";
            }
            else
            {
                _isDarkMode = true;
                currentThemeIcon = Icons.Material.Filled.LightMode;
                themeToolTipText = "Light Mode";
            }
        }
        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
        void LogOut()
        {
            _navigationManager.NavigateTo("/login");
        }
    }
}
