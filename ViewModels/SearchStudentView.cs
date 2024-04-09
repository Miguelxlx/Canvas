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

        [ObservableProperty]
        private ObservableCollection<Student> searchResults;

        [ObservableProperty]
        private string searchText;

        public SearchStudentViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SearchResults = new ObservableCollection<Student>();
            SearchCommand = new RelayCommand(SearchStudents);
        }

        public IRelayCommand SearchCommand { get; }

        private void SearchStudents()
        {
            // Example search logic (replace with actual logic)
            var results = App.Students.Where(student => student.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
            SearchResults.Clear();
            foreach (var student in results)
            {
                SearchResults.Add(student);
            }
        }
    }
}
