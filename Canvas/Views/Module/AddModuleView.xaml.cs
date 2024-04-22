using CanvasRemake.Models;
using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    [QueryProperty(nameof(CourseCode), "courseCode")]
    public partial class AddModuleView : ContentPage
    {
        public string CourseCode { get; set; }

        public AddModuleView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            var apiService = App.ServiceProvider.GetService<ApiService>();
            BindingContext = new AddModuleViewModel(navigationService, apiService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is AddModuleViewModel vm)
            {
                vm.Initialize(CourseCode);
            }
        }
    }
}