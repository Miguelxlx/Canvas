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

        public async Task NavigateToAddModule(string courseCode)
        {
            var route = $"{nameof(AddModuleView)}?courseCode={courseCode}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task NavigateToAddAssignment(string courseCode)
        {
            var route = $"{nameof(AddAssignmentView)}?courseCode={courseCode}";
            await Shell.Current.GoToAsync(route);
        }

        public async Task NavigateToAddStudent()
        {
            await Shell.Current.GoToAsync(nameof(AddStudentView));
        }

        public async Task NavigateToSearchStudent()
        {
            await Shell.Current.GoToAsync(nameof(SearchStudentView));
        }

        public async Task NavigateToSearchCourse()
        {
            await Shell.Current.GoToAsync(nameof(SearchCourseView));
        }

        public async Task NavigateToAddCourse()
        {
            await Shell.Current.GoToAsync(nameof(AddCourseView));
        }

        public async Task NavigateToLinkStudents()
        {
            await Shell.Current.GoToAsync(nameof(LinkStudentsView));
        }

        public async Task NavigateToInstructorCourseDetails(string courseCode)
        {
            var parameters = new Dictionary<string, object> { { "courseCode", courseCode } };
            await Shell.Current.GoToAsync($"{nameof(InstructorCourseDetailsView)}", parameters);
        }

        public async Task NavigateToStudentCourseDetails(Course course)
        {
            var parameters = new Dictionary<string, object>
            {
                { "course", course }
            };
            await Shell.Current.GoToAsync($"{nameof(StudentCourseDetailsView)}", parameters);
        }

        public async Task NavigateToSubmitAssignment(string assignmentId, string studentId)
        {
            var parameters = new Dictionary<string, object>
            {
                { "assignmentId", assignmentId },
                { "studentId", studentId }
            };
            await Shell.Current.GoToAsync($"{nameof(SubmitAssignmentView)}", parameters);
        }

        public async Task NavigateToAssignmentSubmissions(Assignment assignment)
        {
            var parameters = new Dictionary<string, object>
            {
                { "assignment", assignment }
            };
            await Shell.Current.GoToAsync($"{nameof(AssignmentSubmissionsView)}", parameters);
        }
    }
}
