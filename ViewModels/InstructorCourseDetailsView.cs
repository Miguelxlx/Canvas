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

        public InstructorCourseDetailsViewModel(Course course, INavigationService navigationService)
        {
            _course = course;
            _navigationService = navigationService;
            AddModuleCommand = new RelayCommand(OnAddModule); // Corrected method reference
            AddAssignmentCommand = new RelayCommand(OnAddAssignment); // Corrected method reference
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


    }
}
