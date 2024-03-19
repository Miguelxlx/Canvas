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
        public Course Course { get; set; }
        public StudentCourseDetailsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new StudentCourseDetailsViewModel(Course, navigationService);
        }
    }
}
