using CanvasRemake.ViewModels;
using CanvasRemake.Models;
using CanvasRemake.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace CanvasRemake.Views
{
    [QueryProperty("Course", "course")]
    public partial class InstructorCourseDetailsView : ContentPage
    {
        public Course Course { get; set; }

        public InstructorCourseDetailsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new InstructorCourseDetailsViewModel(Course, navigationService);
        }
    }
}