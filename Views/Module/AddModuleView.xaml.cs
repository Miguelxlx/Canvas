using CanvasRemake.Models;
using CanvasRemake.ViewModels;
using CanvasRemake.Services;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace CanvasRemake.Views
{
    [QueryProperty(nameof(CourseId), "courseId")]
    public partial class AddModuleView : ContentPage
    {
        private string _courseId;
        public string CourseId
        {
            set
            {
                _courseId = value;
                LoadCourse(_courseId);
            }
            get
            {
                return _courseId;
            }
        }

        public AddModuleView()
        {
            InitializeComponent();
            BindingContext = new AddModuleViewModel(null, App.ServiceProvider.GetService<INavigationService>());
        }

        private async void LoadCourse(string courseId)
        {
            var course = await FetchCourseById(courseId);
            if (course != null && BindingContext is AddModuleViewModel vm)
            {
                vm.Initialize(course);
            }
        }

        private async Task<Course> FetchCourseById(string courseId)
        {
            var course = App.Courses.FirstOrDefault(c => c.Code == courseId);
            return course;
        }
    }
}