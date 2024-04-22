using CanvasRemake.Models;
using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CanvasRemake.ViewModels
{
    public partial class StudentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;  // Inject ApiService
        private readonly Student _student;

        public StudentViewModel(Student student, INavigationService navigationService, ApiService apiService)
        {
            _student = student;
            _navigationService = navigationService;
            _apiService = App.ServiceProvider.GetService<ApiService>();
            CourseSelectedCommand = new AsyncRelayCommand<Course>(OnCourseSelectedAsync);
            LoadEnrolledCourses();
        }

        [ObservableProperty]
        ObservableCollection<Course> enrolledCourses;

        [ObservableProperty]
        Course selectedCourse;

        public IAsyncRelayCommand<Course> CourseSelectedCommand { get; }

        private async Task OnCourseSelectedAsync(Course course)
        {
            await _navigationService.NavigateToStudentCourseDetails(course);
        }

        private async void LoadEnrolledCourses()
        {
            var allCourses = await _apiService.GetAllCoursesAsync();  // Fetch courses from API
            EnrolledCourses = new ObservableCollection<Course>(
                allCourses.Where(c => c.Roster.Any(s => s.StudentId == _student.StudentId))
            );
        }
    }
}
