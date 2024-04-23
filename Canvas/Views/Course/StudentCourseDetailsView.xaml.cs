using CanvasRemake.ViewModels;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    [QueryProperty(nameof(courseCode), "courseCode")]
    public partial class StudentCourseDetailsView : ContentPage
    {
        private StudentCourseDetailsViewModel _viewModel;
        public string courseCode { get; set; }

        public StudentCourseDetailsView()
        {
            InitializeComponent();
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshViewModel();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);
            RefreshViewModel();
        }

        private async void RefreshViewModel()
        {
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            var apiService = App.ServiceProvider.GetService<ApiService>();
            var course = await apiService.GetCourseDetailsAsync(courseCode);
            _viewModel = new StudentCourseDetailsViewModel(course, App.LoggedInStudent, navigationService, apiService);
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