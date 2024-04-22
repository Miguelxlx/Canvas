using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace CanvasRemake.ViewModels
{
    public partial class LinkStudentsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;

        [ObservableProperty]
        private string courseCode;

        [ObservableProperty]
        private string studentId;

        public LinkStudentsViewModel(INavigationService navigationService, ApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            LinkStudentCommand = new AsyncRelayCommand(OnLinkStudentAsync);
            RemoveStudentCommand = new AsyncRelayCommand(OnRemoveStudentAsync);
        }

        public IAsyncRelayCommand LinkStudentCommand { get; }
        public IAsyncRelayCommand RemoveStudentCommand { get; }

        private async Task OnLinkStudentAsync()
        {
            bool isLinked = await _apiService.LinkStudentToCourseAsync(CourseCode, StudentId);

            if (isLinked)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Student linked to the course successfully.", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Failed to link student to the course.", "OK");
            }

            CourseCode = string.Empty;
            StudentId = string.Empty;
        }

        private async Task OnRemoveStudentAsync()
        {
            bool isRemoved = await _apiService.RemoveStudentFromCourseAsync(CourseCode, StudentId);

            if (isRemoved)
            {
                await App.Current.MainPage.DisplayAlert("Success", "Student removed from the course successfully.", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Failed to remove student from the course.", "OK");
            }

            CourseCode = string.Empty;
            StudentId = string.Empty;
        }
    }
}