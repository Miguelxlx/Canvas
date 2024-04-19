using CanvasRemake.ViewModels;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    [QueryProperty("Course", "course")]
    public partial class InstructorCourseDetailsView : ContentPage
    {
        private InstructorCourseDetailsViewModel _viewModel;

        public Course Course { get; set; }

        public InstructorCourseDetailsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            _viewModel = new InstructorCourseDetailsViewModel(Course, navigationService);
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