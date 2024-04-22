using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    public partial class AddStudentView : ContentPage
    {
        public AddStudentView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            var apiService = App.ServiceProvider.GetService<ApiService>(); // Get ApiService
            BindingContext = new AddStudentViewModel(navigationService, apiService);
        }
    }
}
