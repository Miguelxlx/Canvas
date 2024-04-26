using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;
using System.Collections.ObjectModel;

namespace CanvasRemake.ViewModels
{
    public partial class SearchStudentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;

        [ObservableProperty]
        private ObservableCollection<Student> searchResults;

        [ObservableProperty]
        private string searchText;

        public SearchStudentViewModel(INavigationService navigationService, ApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            SearchResults = new ObservableCollection<Student>();
            SearchCommand = new AsyncRelayCommand(SearchStudentsAsync);
        }

        public IAsyncRelayCommand SearchCommand { get; }

        private async Task SearchStudentsAsync()
        {
            var results = await _apiService.SearchStudentsAsync(SearchText);
            SearchResults.Clear();
            foreach (var student in results)
            {
                SearchResults.Add(student);
            }
        }
    }
}