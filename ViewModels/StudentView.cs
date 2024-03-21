using System.Collections.ObjectModel;
using CanvasRemake.Models;
using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CanvasRemake.ViewModels
{
    public partial class StudentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly Student _student;

        public StudentViewModel(Student student, INavigationService navigationService)
        {
            _student = student;
            _navigationService = navigationService;
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

        private void LoadEnrolledCourses()
        {
            EnrolledCourses = new ObservableCollection<Course>(
                App.Courses.Where(c => c.Roster.Contains(_student))
            );
        }
    }
}