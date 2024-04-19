using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.ViewModels
{
    public partial class AddAssignmentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private Course _course;

        [ObservableProperty] private string assignmentName = string.Empty;
        [ObservableProperty] private string assignmentDescription = string.Empty;
        [ObservableProperty] private double assignmentPoints;
        [ObservableProperty] private DateTime assignmentDueDate = DateTime.Now;

        public AddAssignmentViewModel(Course course, INavigationService navigationService)
        {
            _course = course;
            _navigationService = navigationService;
            SaveCommand = new RelayCommand(OnSave);
        }

        public void Initialize(Course course) => _course = course;
        public IRelayCommand SaveCommand { get; }

        private async void OnSave()
        {
            var assignment = new Assignment
            {
                Name = AssignmentName,
                Description = AssignmentDescription,
                TotalAvailablePoints = AssignmentPoints,
                DueDate = AssignmentDueDate
            };
            _course.Assignments.Add(assignment);
            await _navigationService.GoBackAsync();
        }
    }
}