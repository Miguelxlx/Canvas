using CanvasRemake.ViewModels;
using CanvasRemake.Models;
using CanvasRemake.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CanvasRemake.Views
{
    [QueryProperty(nameof(AssignmentId), "assignmentId")]
    [QueryProperty(nameof(StudentId), "studentId")]
    public partial class SubmitAssignmentView : ContentPage
    {
        public string AssignmentId { get; set; }
        public string StudentId { get; set; }

        public SubmitAssignmentView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!string.IsNullOrEmpty(AssignmentId) && !string.IsNullOrEmpty(StudentId))
            {
                var assignment = App.Courses.SelectMany(c => c.Assignments).FirstOrDefault(a => a.Id == AssignmentId);
                var student = App.Students.FirstOrDefault(s => s.ID == StudentId);

                if (assignment != null && student != null)
                {
                    var navigationService = App.ServiceProvider.GetService<INavigationService>();
                    BindingContext = new SubmitAssignmentViewModel(assignment, student, navigationService);
                }
            }
        }
    }
}