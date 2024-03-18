using CanvasRemake.ViewModels;
using CanvasRemake.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace CanvasRemake.Views
{
    public partial class AddCourseView : ContentPage
    {
        public AddCourseView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new AddCourseViewModel(navigationService);
        }
    }
}
