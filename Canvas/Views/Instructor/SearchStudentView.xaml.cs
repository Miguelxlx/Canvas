using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    public partial class SearchStudentView : ContentPage
    {
        public SearchStudentView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            var apiService = App.ServiceProvider.GetService<ApiService>();
            BindingContext = new SearchStudentViewModel(navigationService, apiService);
        }
    }
}