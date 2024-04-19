using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.ViewModels
{
    public partial class AddCourseViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        [ObservableProperty]
        private string courseName;

        [ObservableProperty]
        private string courseCode;

        [ObservableProperty]
        private string courseDescription;

        public AddCourseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SaveCommand = new RelayCommand(OnSave);
        }



        public IRelayCommand SaveCommand { get; }

        private async void OnSave()
        {
            if (!IsCourseCodeExists(CourseCode))
            {
                var newCourse = new Course(CourseName, CourseCode, CourseDescription);
                App.Courses.Add(newCourse);
                await _navigationService.GoBackAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Course Code already exists", "OK");
            }
        }

        private bool IsCourseCodeExists(string courseCode)
        {
            return App.Courses.Any(course => course.Code == courseCode);
        }
    }
}
