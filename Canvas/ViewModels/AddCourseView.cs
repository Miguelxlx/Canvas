using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.ViewModels
{
    public partial class AddCourseViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;

        [ObservableProperty]
        private string courseName;

        [ObservableProperty]
        private string courseCode;

        [ObservableProperty]
        private string courseDescription;

        public AddCourseViewModel(INavigationService navigationService, ApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            SaveCommand = new AsyncRelayCommand(OnSaveAsync);
        }

        public IAsyncRelayCommand SaveCommand { get; }

        private async Task OnSaveAsync()
        {
            var newCourse = new Course
            {
                Name = CourseName,
                Code = CourseCode,
                Description = CourseDescription
            };

            bool isAdded = await _apiService.AddCourseAsync(newCourse);

            if (isAdded)
            {
                MessagingCenter.Send<AddCourseViewModel>(this, "CourseAdded");
                await _navigationService.GoBackAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Failed to add course", "OK");
            }
        }
    }
}