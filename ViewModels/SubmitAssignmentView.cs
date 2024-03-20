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
            Console.WriteLine("SUBMISSIONS-PRE: ");
            for (int i = 0; i < _assignment.Submissions.Count; i++)
            {
                Console.WriteLine("Submission Text: " + _assignment.Submissions[i].SubmissionText);
                Console.WriteLine("Submission Date: " + _assignment.Submissions[i].SubmissionDate);
                Console.WriteLine("Student ID: " + _assignment.Submissions[i].StudentId);
                Console.WriteLine("Assignment ID: " + _assignment.Submissions[i].AssignmentId);
                Console.WriteLine("Submission ID: " + _assignment.Submissions[i].SubmissionId);
            }

            var existingSubmission = _assignment.Submissions.FirstOrDefault(s => s.StudentId == _student.ID);

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
                    SubmissionDate = DateTime.Now,
                    SubmissionId = Guid.NewGuid().ToString()
                };

                _assignment.Submissions.Add(submission);
            }

            Console.WriteLine("SUBMISSIONS: ");
            for (int i = 0; i < _assignment.Submissions.Count; i++)
            {
                Console.WriteLine("Submission Text: " + _assignment.Submissions[i].SubmissionText);
                Console.WriteLine("Submission Date: " + _assignment.Submissions[i].SubmissionDate);
                Console.WriteLine("Student ID: " + _assignment.Submissions[i].StudentId);
                Console.WriteLine("Assignment ID: " + _assignment.Submissions[i].AssignmentId);
                Console.WriteLine("Submission ID: " + _assignment.Submissions[i].SubmissionId);
            }

            await _navigationService.GoBackAsync();
        }
    }
}