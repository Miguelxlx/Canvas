using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;
using System.Collections.ObjectModel;

namespace CanvasRemake.ViewModels
{
    public partial class SearchCourseViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private ObservableCollection<Course> searchResults;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private Course selectedCourse;

        public IAsyncRelayCommand<Course> CourseSelectedCommand { get; }

        public SearchCourseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SearchResults = new ObservableCollection<Course>();
            SearchCommand = new RelayCommand(SearchCourses);
            CourseSelectedCommand = new AsyncRelayCommand<Course>(OnCourseSelectedAsync);
        }

        public IRelayCommand SearchCommand { get; }

        private void SearchCourses()
        {
            var results = App.Courses.Where(course =>
                course.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                course.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
            SearchResults.Clear();
            foreach (var course in results)
            {
                SearchResults.Add(course);
            }
        }

        private async Task OnCourseSelectedAsync(Course course)
        {
            if (course != null)
            {
                await _navigationService.NavigateToInstructorCourseDetails(course.Code);
            }
        }
    }
}
