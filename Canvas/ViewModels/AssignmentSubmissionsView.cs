using CommunityToolkit.Mvvm.ComponentModel;
using CanvasRemake.Models;
using CanvasRemake.Services;
using System.Collections.ObjectModel;

namespace CanvasRemake.ViewModels
{
    public partial class AssignmentSubmissionsViewModel : ObservableObject
    {
        private readonly ApiService _apiService;
        private readonly string _assignmentId;

        [ObservableProperty]
        ObservableCollection<AssignmentSubmissionViewModel> submissions;

        [ObservableProperty]
        Assignment assignment;

        public AssignmentSubmissionsViewModel(string assignmentId, ApiService apiService)
        {
            _assignmentId = assignmentId;
            _apiService = apiService;
            LoadAssignmentAsync();
            LoadSubmissionsAsync();
        }

        private async Task LoadAssignmentAsync()
        {
            Assignment = await _apiService.GetAssignmentByIdAsync(_assignmentId);
        }

        private async Task LoadSubmissionsAsync()
        {
            var submissionModels = await _apiService.GetSubmissionsForAssignmentAsync(_assignmentId);
            Submissions = new ObservableCollection<AssignmentSubmissionViewModel>(
                submissionModels.Select(s => new AssignmentSubmissionViewModel(s, _apiService)));
        }
    }

    public partial class AssignmentSubmissionViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        public AssignmentSubmission Submission { get; }

        public string StudentId => Submission.StudentId;
        public string SubmissionText => Submission.SubmissionText;

        [ObservableProperty]
        double grade;

        public AssignmentSubmissionViewModel(AssignmentSubmission submission, ApiService apiService)
        {
            Submission = submission;
            _apiService = apiService;
            Grade = submission.Grade;
        }

        partial void OnGradeChanged(double value)
        {
            Submission.Grade = value;
            Submission.IsGraded = true;
            SaveGradeAsync();
        }

        private async Task SaveGradeAsync()
        {
            await _apiService.GradeSubmissionAsync(Submission);
        }
    }
}