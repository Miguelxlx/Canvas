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
            var existingSubmission = App.AssignmentSubmissions.FirstOrDefault(s => s.AssignmentId == _assignment.Id && s.StudentId == _student.ID);

            if (existingSubmission != null)
            {
                // Update existing submission
                existingSubmission.SubmissionText = SubmissionText;
                existingSubmission.SubmissionDate = DateTime.Now;
            }
            else
            {
                // Create new submission
                var submission = new AssignmentSubmission
                {
                    AssignmentId = _assignment.Id,
                    StudentId = _student.ID,
                    SubmissionText = SubmissionText,
                    SubmissionDate = DateTime.Now
                };

                App.AssignmentSubmissions.Add(submission);
                //print all assignment submissions
            }

            // Update assignment submission status
            _assignment.SubmissionStatus = "Submitted";
            _assignment.SubmissionStatusColor = Colors.Green;
            foreach (var sub in App.AssignmentSubmissions)
                {
                    Console.WriteLine(sub.SubmissionText);
                }

            await _navigationService.GoBackAsync();
        }
    }
}