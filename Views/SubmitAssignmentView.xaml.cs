using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class SubmitAssignmentView : ContentPage
    {
        private Assignment _assignment;

        public SubmitAssignmentView(Assignment assignment)
        {
            InitializeComponent();
            _assignment = assignment;
            BindingContext = _assignment;
        }

        private async void OnSubmitAssignmentClicked(object sender, EventArgs e)
        {
            var submission = new Submission
            {
                AssignmentId = _assignment.Id,
                StudentId = App.LoggedInStudent.ID,
                SubmissionDate = DateTime.Now
            };

            _assignment.IsSubmitted = true;

            await DisplayAlert("Success", "Assignment submitted successfully.", "OK");
            await Navigation.PopAsync();
        }
    }
}