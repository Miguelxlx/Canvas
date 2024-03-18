using Microsoft.Maui.Controls;

namespace CanvasRemake.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public async Task GoBackAsync()
        {
            if (Application.Current.MainPage is Shell shell)
            {
                await shell.Navigation.PopAsync();
            }
        }
    }
}
