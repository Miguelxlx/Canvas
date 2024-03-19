using System;
using CanvasRemake.Models;
using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CanvasRemake.ViewModels
{
    public partial class SubmitAssignmentViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly Assignment _assignment;
        private readonly Student _student;

        public SubmitAssignmentViewModel(Assignment assignment, Student student, INavigationService navigationService)
        {
            _assignment = assignment;
            _student = student;
            _navigationService = navigationService;
        }

        public Assignment Assignment => _assignment;

        public string StudentName => _student.Name;

        [ObservableProperty]
        string submissionText;

        [RelayCommand]
        async Task Submit()
        {
            var submission = new AssignmentSubmission
            {
                AssignmentId = _assignment.Id,
                StudentId = _student.ID,
                SubmissionText = SubmissionText,
                SubmissionDate = DateTime.Now
            };

            App.AssignmentSubmissions.Add(submission);

            for (int i = 0; i < App.AssignmentSubmissions.Count; i++)
            {
                Console.WriteLine(App.AssignmentSubmissions[i].SubmissionText);
            }

            await _navigationService.GoBackAsync();
        }
    }
}