using CanvasRemake.ViewModels;
using CanvasRemake.Services;
using CanvasRemake.Models;

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

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!string.IsNullOrEmpty(AssignmentId) && !string.IsNullOrEmpty(StudentId))
            {
                var navigationService = App.ServiceProvider.GetService<INavigationService>();
                var apiService = App.ServiceProvider.GetService<ApiService>();

                var assignment = await apiService.GetAssignmentByIdAsync(AssignmentId);
                var student = await apiService.GetStudentByIdAsync(StudentId);

                if (assignment != null && student != null)
                {
                    BindingContext = new SubmitAssignmentViewModel(assignment, student, navigationService, apiService);
                }
            }
        }
    }
}