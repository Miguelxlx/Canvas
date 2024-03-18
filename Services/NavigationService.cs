using Microsoft.Maui.Controls;
using CanvasRemake.Models;
using CanvasRemake.Views;

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

        public async Task NavigateToAddModule(string courseId)
        {
            var route = $"{nameof(AddModuleView)}?courseId={courseId}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task NavigateToAddAssignment(string courseId)
        {
            var route = $"{nameof(AddAssignmentView)}?courseId={courseId}";
            await Shell.Current.GoToAsync(route);
        }

    }
}
