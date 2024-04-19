using CanvasRemake.Models;
using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CanvasRemake.ViewModels
{
    public partial class AddStudentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string studentName;

        [ObservableProperty]
        private string studentID;

        [ObservableProperty]
        private string studentClassification;

        public AddStudentViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SaveCommand = new RelayCommand(OnSave);

        }
        public IRelayCommand SaveCommand { get; }
        public async void OnSave()
        {
            if (!IsStudentIDExists(StudentID))
            {
                var newStudent = new Student(StudentName, StudentID, StudentClassification);
                App.Students.Add(newStudent);
                await _navigationService.GoBackAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Student ID already exists", "OK");
            }
        }

        private bool IsStudentIDExists(string studentID)
        {
            return App.Students.Any(student => student.ID == studentID);
        }
    }
}