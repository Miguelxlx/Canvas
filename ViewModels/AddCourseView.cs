using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.ViewModels
{
    public partial class AddCourseViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService; // Add this line
        [ObservableProperty]
        private string courseName;

        [ObservableProperty]
        private string courseCode;

        [ObservableProperty]
        private string courseDescription;

        public AddCourseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService; // Initialize the field
            SaveCommand = new RelayCommand(OnSave);
        }



        public IRelayCommand SaveCommand { get; }

        private async void OnSave()
        {
            // Create a new course object
            var newCourse = new Course(CourseName, CourseCode, CourseDescription);

            // Assuming App.Courses is an ObservableCollection<Course>
            App.Courses.Add(newCourse);

            await _navigationService.GoBackAsync();
        }
    }
}
