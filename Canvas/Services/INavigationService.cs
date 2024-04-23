using System.Threading.Tasks;
using CanvasRemake.Models;

namespace CanvasRemake.Services
{
    public interface INavigationService
    {
        Task GoBackAsync();
        Task NavigateToAddModule(string courseCode);
        Task NavigateToAddAssignment(string courseCode);
        Task NavigateToAddStudent();
        Task NavigateToAddCourse();
        Task NavigateToLinkStudents();
        Task NavigateToInstructorCourseDetails(string course);
        Task NavigateToStudentCourseDetails(string course);
        Task NavigateToSubmitAssignment(string assignmentId, string studentId);
        Task NavigateToAssignmentSubmissions(Assignment assignment);
        Task NavigateToSearchStudent();
        Task NavigateToSearchCourse();
    }
}
