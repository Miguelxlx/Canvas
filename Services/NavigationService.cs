using Microsoft.Maui.Controls;
using CanvasRemake.Models;
using CanvasRemake.Views;

namespace CanvasRemake.Services
{
    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public async Task GoBackAsync()
        {
            if (Application.Current.MainPage is Shell shell)
            {
                await shell.Navigation.PopAsync();
            }
        }

        public async Task NavigateToAddModule(string courseId)
        {
            var route = $"{nameof(AddModuleView)}?courseId={courseId}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task NavigateToAddAssignment(string courseId)
        {
            var route = $"{nameof(AddAssignmentView)}?courseId={courseId}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task NavigateToAddStudent()
        {
            await Shell.Current.GoToAsync(nameof(AddStudentView));
        }

        public async Task NavigateToAddCourse()
        {
            await Shell.Current.GoToAsync(nameof(AddCourseView));
        }

        public async Task NavigateToLinkStudents()
        {
            await Shell.Current.GoToAsync(nameof(LinkStudentsView));
        }

        public async Task NavigateToInstructorCourseDetails(Course course)
        {
            var parameters = new Dictionary<string, object>
            {
                { "course", course }
            };
            await Shell.Current.GoToAsync($"{nameof(InstructorCourseDetailsView)}", parameters);
        }
    }
}
