using CanvasRemake.ViewModels;
using CanvasRemake.Models;
using CanvasRemake.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;

namespace CanvasRemake.Views
{
    public partial class InstructorCourseDetailsView : ContentPage
    {
        public InstructorCourseDetailsView(Course course)
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new InstructorCourseDetailsViewModel(course, navigationService);
        }
    }
}
