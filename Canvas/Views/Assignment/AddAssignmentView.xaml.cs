using CanvasRemake.Models;
using CanvasRemake.ViewModels;
using CanvasRemake.Services;

namespace CanvasRemake.Views
{
    [QueryProperty(nameof(CourseId), "courseId")]
    public partial class AddAssignmentView : ContentPage
    {
        public string CourseId
        {
            set
            {
                LoadCourse(value);
            }
        }

        public AddAssignmentView()
        {
            InitializeComponent();
            var navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new AddAssignmentViewModel(null, navigationService);
        }

        private async void LoadCourse(string courseId)
        {
            var course = await FetchCourseById(courseId);
            if (course != null && BindingContext is AddAssignmentViewModel vm)
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
