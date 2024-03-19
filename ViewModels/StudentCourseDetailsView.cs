using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CanvasRemake.Models;
using CanvasRemake.Services;

namespace CanvasRemake.ViewModels
{
    public partial class StudentCourseDetailsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly Course _course;

        public StudentCourseDetailsViewModel(Course course, INavigationService navigationService)
        {
            _course = course;
            _navigationService = navigationService;

            // Update assignment submission status
            foreach (var assignment in _course.Assignments)
            {
                var submission = App.AssignmentSubmissions.FirstOrDefault(s => s.AssignmentId == assignment.Id && s.StudentId == App.LoggedInStudent.ID);
                assignment.SubmissionStatus = submission != null ? "Submitted" : "Missing";
                assignment.SubmissionStatusColor = submission != null ? Colors.Green : Colors.Red;
            }
        }

        public Course Course => _course;

        [ObservableProperty]
        Assignment selectedAssignment;

        public async Task OnAssignmentSelectedAsync(Assignment assignment)
        {
            if (assignment != null)
            {
                // Navigate to the SubmitAssignmentView with the selected assignment and logged-in student
                await _navigationService.NavigateToSubmitAssignment(assignment.Id, App.LoggedInStudent.ID);
            }
        }
    }
}