using CanvasRemake.ViewModels;
using CanvasRemake.Models;
using CanvasRemake.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace CanvasRemake.Views
{
    [QueryProperty("Course", "course")]
    public partial class StudentCourseDetailsView : ContentPage
    {
        private StudentCourseDetailsViewModel _viewModel;

        public Course Course { get; set; }

        public StudentCourseDetailsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            _viewModel = new StudentCourseDetailsViewModel(Course, navigationService);
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