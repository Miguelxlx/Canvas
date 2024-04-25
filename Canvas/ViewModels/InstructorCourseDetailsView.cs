using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.ViewModels
{
    public partial class InstructorCourseDetailsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;
        private readonly Course _course;

        [ObservableProperty]
        Assignment selectedAssignment;

        public InstructorCourseDetailsViewModel(Course course, INavigationService navigationService, ApiService apiService)
        {
            _course = course;
            _navigationService = navigationService;
            _apiService = apiService;
            AddModuleCommand = new AsyncRelayCommand(OnAddModuleAsync);
            AddAssignmentCommand = new AsyncRelayCommand(OnAddAssignmentAsync);
            LoadCourseDetailsAsync();
        }

        public Course Course => _course;

        [ObservableProperty]
        ObservableCollection<Module> modules;

        [ObservableProperty]
        ObservableCollection<Assignment> assignments;

        public IAsyncRelayCommand AddModuleCommand { get; }
        public IAsyncRelayCommand AddAssignmentCommand { get; }

        private async Task LoadCourseDetailsAsync()
        {
            var course = await _apiService.GetCourseDetailsAsync(_course.Code);
            if (course != null)
            {
                Modules = new ObservableCollection<Module>(course.Modules);
                Assignments = new ObservableCollection<Assignment>(course.Assignments);
            }
        }

        private async Task OnAddModuleAsync()
        {
            await _navigationService.NavigateToAddModule(_course.Code);
        }

        private async Task OnAddAssignmentAsync()
        {
            await _navigationService.NavigateToAddAssignment(_course.Code);
        }

        public async Task OnAssignmentSelectedAsync(Assignment assignment)
        {
            if (assignment != null)
            {
                var parameters = new Dictionary<string, object>
        {
            { "assignmentId", assignment.Id }
        };
                await _navigationService.NavigateToAssignmentSubmissions(parameters);
            }
        }
    }
}