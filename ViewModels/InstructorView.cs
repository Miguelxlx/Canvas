using System.Collections.ObjectModel;
using CanvasRemake.Models;
using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CanvasRemake.ViewModels
{
    public partial class InstructorViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public InstructorViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CourseSelectedCommand = new AsyncRelayCommand<Course>(OnCourseSelectedAsync);
            AddCourseCommand = new AsyncRelayCommand(OnAddCourseAsync);
            AddStudentCommand = new AsyncRelayCommand(OnAddStudentAsync);
            LinkStudentsCommand = new AsyncRelayCommand(onLinkStudentsAsync);
            SearchStudentCommand = new AsyncRelayCommand(OnSearchStudentAsync);
            SearchCourseCommand = new AsyncRelayCommand(OnSearchCourseAsync);

            Courses = App.Courses;
            Students = App.Students;
        }


        [ObservableProperty]
        ObservableCollection<Course> courses;

        [ObservableProperty]
        ObservableCollection<Student> students;

        [ObservableProperty]
        Course selectedCourse;

        public IAsyncRelayCommand<Course> CourseSelectedCommand { get; }
        public IAsyncRelayCommand AddCourseCommand { get; }
        public IAsyncRelayCommand AddStudentCommand { get; }
        public IAsyncRelayCommand LinkStudentsCommand { get; }
        public IAsyncRelayCommand SearchStudentCommand { get; }
        public IAsyncRelayCommand SearchCourseCommand { get; }

        private async Task OnCourseSelectedAsync(Course course)
        {
            await _navigationService.NavigateToInstructorCourseDetails(course);
        }

        private async Task OnAddCourseAsync()
        {
            await _navigationService.NavigateToAddCourse();
        }

        private async Task OnAddStudentAsync()
        {
            await _navigationService.NavigateToAddStudent();
        }

        private async Task onLinkStudentsAsync()
        {
            await _navigationService.NavigateToLinkStudents();
        }

        private async Task OnSearchStudentAsync()
        {
            await _navigationService.NavigateToSearchStudent();
        }

        private async Task OnSearchCourseAsync()
        {
            await _navigationService.NavigateToSearchCourse();
        }


    }
}