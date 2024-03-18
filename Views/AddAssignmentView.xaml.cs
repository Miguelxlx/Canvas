// AddAssignmentView.xaml.cs
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class AddAssignmentView : ContentPage
    {
        private Course _course;

        public AddAssignmentView(Course course)
        {
            InitializeComponent();
            _course = course;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var assignment = new Assignment
            {
                Name = AssignmentNameEntry.Text,
                Description = AssignmentDescriptionEditor.Text,
                TotalAvailablePoints = double.Parse(AssignmentPointsEntry.Text),
                DueDate = AssignmentDueDatePicker.Date
            };

            _course.Assignments.Add(assignment);

            await Navigation.PopAsync(true);
        }
    }
}