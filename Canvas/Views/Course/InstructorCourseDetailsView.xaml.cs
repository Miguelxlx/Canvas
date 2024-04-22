using CanvasRemake.ViewModels;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    [QueryProperty(nameof(CourseCode), "courseCode")]
    public partial class InstructorCourseDetailsView : ContentPage
    {
        private InstructorCourseDetailsViewModel _viewModel;
        public string CourseCode { get; set; }

        public InstructorCourseDetailsView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await RefreshViewModel();
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            await RefreshViewModel();
        }

        private async Task RefreshViewModel()
        {
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            var apiService = App.ServiceProvider.GetService<ApiService>();
            var course = await apiService.GetCourseDetailsAsync(CourseCode);
            _viewModel = new InstructorCourseDetailsViewModel(course, navigationService, apiService);
            BindingContext = _viewModel;
        }

        private async void OnAssignmentSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Assignment selectedAssignment)
            {
                await _viewModel.OnAssignmentSelectedAsync(selectedAssignment);
            }
        }
    }
}