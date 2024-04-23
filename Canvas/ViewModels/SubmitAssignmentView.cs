using CanvasRemake.Models;
using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace CanvasRemake.ViewModels
{
    public partial class SubmitAssignmentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly ApiService _apiService;
        private readonly Assignment _assignment;
        private readonly Student _student;

        public SubmitAssignmentViewModel(Assignment assignment, Student student, INavigationService navigationService, ApiService apiService)
        {
            _assignment = assignment;
            _student = student;
            _navigationService = navigationService;
            _apiService = apiService;
            SubmitCommand = new AsyncRelayCommand(SubmitAsync);
        }

        public Assignment Assignment => _assignment;
        public string StudentName => _student.Name;

        [ObservableProperty]
        string submissionText;
        public IAsyncRelayCommand SubmitCommand { get; }
        private async Task SubmitAsync()
        {
            var submission = new AssignmentSubmission
            {
                AssignmentId = _assignment.Id,
                StudentId = _student.StudentId,
                SubmissionText = SubmissionText,
                SubmissionDate = DateTime.Now,
                SubmissionId = Guid.NewGuid().ToString(),
                Grade = 0.0,
                IsGraded = false
            };

            try
            {
                await _apiService.SubmitAssignmentAsync(submission);
                await _navigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                // Display an error message to the user
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to submit the assignment. Please try again.", "OK");
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}