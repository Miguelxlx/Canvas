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

        public SearchCourseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SearchResults = new ObservableCollection<Course>();
            SearchCommand = new RelayCommand(SearchCourses);
        }

        public IRelayCommand SearchCommand { get; }

        private void SearchCourses()
        {
            // Replace with your actual search logic for courses by name or description
            var results = App.Courses.Where(course =>
                course.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                course.Description.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
            SearchResults.Clear();
            foreach (var course in results)
            {
                SearchResults.Add(course);
            }
        }
    }
}
