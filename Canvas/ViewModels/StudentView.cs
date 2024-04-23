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
        private readonly ApiService _apiService;
        private readonly Student _student;

        public StudentViewModel(Student student, INavigationService navigationService, ApiService apiService)
        {
            _student = student;
            _navigationService = navigationService;
            _apiService = apiService;
            CourseSelectedCommand = new AsyncRelayCommand<Course>(OnCourseSelectedAsync);
            LoadEnrolledCoursesAsync();
        }

        [ObservableProperty]
        ObservableCollection<Course> enrolledCourses;

        [ObservableProperty]
        Course selectedCourse;

        public IAsyncRelayCommand<Course> CourseSelectedCommand { get; }

        private async Task OnCourseSelectedAsync(Course course)
        {
            await _navigationService.NavigateToStudentCourseDetails(course.Code);
        }

        private async Task LoadEnrolledCoursesAsync()
        {
            var enrolledCourses = await _apiService.GetEnrolledCoursesForStudentAsync(_student.StudentId);
            EnrolledCourses = new ObservableCollection<Course>(enrolledCourses);
        }
    }
}