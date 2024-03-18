using CanvasRemake.ViewModels;
using CanvasRemake.Models;
using CanvasRemake.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace CanvasRemake.Views
{
    public partial class StudentCourseDetailsView : ContentPage
    {
        public StudentCourseDetailsView(Course course)
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new StudentCourseDetailsViewModel(course, navigationService);
        }
    }
}
