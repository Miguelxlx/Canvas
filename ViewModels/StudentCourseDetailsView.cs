using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.ViewModels
{
    public partial class StudentCourseDetailsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly Course _course;

        public StudentCourseDetailsViewModel(Course course, INavigationService navigationService)
        {
            _course = course;
            _navigationService = navigationService;
        }
        public Course Course => _course;
    }
}
