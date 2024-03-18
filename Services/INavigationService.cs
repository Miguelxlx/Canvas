using System.Threading.Tasks;

namespace CanvasRemake.Services
{
    public interface INavigationService
    {
        Task GoBackAsync();
        Task NavigateToAddModule(string courseId);
        Task NavigateToAddAssignment(string courseId);
    }
}
