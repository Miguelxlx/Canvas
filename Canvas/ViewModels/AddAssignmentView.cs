using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.ViewModels
{
    public partial class AddAssignmentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;
        private string _courseCode;

        [ObservableProperty]
        private string assignmentName = string.Empty;

        [ObservableProperty]
        private string assignmentDescription = string.Empty;

        [ObservableProperty]
        private double assignmentPoints;

        [ObservableProperty]
        private DateTime assignmentDueDate = DateTime.Now;

        public AddAssignmentViewModel(INavigationService navigationService, ApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            SaveCommand = new AsyncRelayCommand(OnSaveAsync);
        }

        public void Initialize(string courseCode)
        {
            _courseCode = courseCode;
        }

        public IAsyncRelayCommand SaveCommand { get; }

        private async Task OnSaveAsync()
        {
            var assignment = new Assignment
            {
                Name = AssignmentName,
                Description = AssignmentDescription,
                TotalAvailablePoints = AssignmentPoints,
                DueDate = AssignmentDueDate
            };

            await _apiService.AddAssignmentToCourseAsync(_courseCode, assignment);
            await _navigationService.GoBackAsync();
        }
    }
}