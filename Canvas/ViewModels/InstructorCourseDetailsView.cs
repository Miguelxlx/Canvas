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
        private readonly Course _course;

        [ObservableProperty]
        Assignment selectedAssignment;

        public InstructorCourseDetailsViewModel(Course course, INavigationService navigationService)
        {
            _course = course;
            _navigationService = navigationService;
            AddModuleCommand = new RelayCommand(OnAddModule);
            AddAssignmentCommand = new RelayCommand(OnAddAssignment);
        }

        public Course Course => _course;

        [ObservableProperty]
        ObservableCollection<Module> modules;

        [ObservableProperty]
        ObservableCollection<Assignment> assignments;

        public IRelayCommand AddModuleCommand { get; }
        public IRelayCommand AddAssignmentCommand { get; }

        private void OnAddModule()
        {

            _navigationService.NavigateToAddModule(_course.Code.ToString());
        }

        private void OnAddAssignment()
        {

            _navigationService.NavigateToAddAssignment(_course.Code.ToString());
        }

        public async Task OnAssignmentSelectedAsync(Assignment assignment)
        {
            if (assignment != null)
            {
                await _navigationService.NavigateToAssignmentSubmissions(assignment);
            }
        }
    }
}
