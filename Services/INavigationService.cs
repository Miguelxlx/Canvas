using System.Threading.Tasks;
using CanvasRemake.Models;

namespace CanvasRemake.Services
{
    public interface INavigationService
    {
        Task GoBackAsync();
        Task NavigateToAddModule(string courseId);
        Task NavigateToAddAssignment(string courseId);
        Task NavigateToAddStudent();
        Task NavigateToAddCourse();
        Task NavigateToLinkStudents();
        Task NavigateToInstructorCourseDetails(Course course);


    }
}
