using CanvasRemake.Models;
using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    [QueryProperty(nameof(CourseCode), "courseCode")]
    public partial class AddAssignmentView : ContentPage
    {
        public string CourseCode { get; set; }

        public AddAssignmentView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            var apiService = App.ServiceProvider.GetService<ApiService>();
            BindingContext = new AddAssignmentViewModel(navigationService, apiService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is AddAssignmentViewModel vm)
            {
                vm.Initialize(CourseCode);
            }
        }
    }
}