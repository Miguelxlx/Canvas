using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    public partial class AddCourseView : ContentPage
    {
        public AddCourseView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            var apiService = App.ServiceProvider.GetService<ApiService>();
            BindingContext = new AddCourseViewModel(navigationService, apiService);
        }
    }
}