using CanvasRemake.Models;
using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CanvasRemake.ViewModels
{
    public partial class AddStudentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;

        [ObservableProperty]
        private string studentName;

        [ObservableProperty]
        private string studentID;

        [ObservableProperty]
        private string studentClassification;

        public AddStudentViewModel(INavigationService navigationService, ApiService apiService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            SaveCommand = new RelayCommand(OnSave);
        }

        public IRelayCommand SaveCommand { get; }

        public async void OnSave()
        {
            var newStudent = new Student(StudentName, StudentID, StudentClassification);
            bool isAdded = await _apiService.AddStudentAsync(newStudent);
            if (isAdded)
            {
                MessagingCenter.Send<AddStudentViewModel>(this, "StudentAdded");
                await _navigationService.GoBackAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Failed to add student", "OK");
            }
        }
    }
}
