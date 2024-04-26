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
        private readonly ApiService _apiService;

        [ObservableProperty]
        private ObservableCollection<Course> searchResults;

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private Course selectedCourse;

        public IAsyncRelayCommand<Course> CourseSelectedCommand { get; }

        public SearchCourseViewModel(INavigationService navigationService, ApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            SearchResults = new ObservableCollection<Course>();
            SearchCommand = new AsyncRelayCommand(SearchCoursesAsync);
            CourseSelectedCommand = new AsyncRelayCommand<Course>(OnCourseSelectedAsync);
        }

        public IAsyncRelayCommand SearchCommand { get; }

        private async Task SearchCoursesAsync()
        {
            var results = await _apiService.SearchCoursesAsync(SearchText);
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