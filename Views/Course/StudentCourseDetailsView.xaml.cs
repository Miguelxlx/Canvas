using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class StudentCourseDetailsView : ContentPage
    {
        public StudentCourseDetailsView(Course course)
        {
            InitializeComponent();
            BindingContext = course;
        }

        private async void OnAssignmentSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var assignment = (Assignment)e.SelectedItem;
                await Navigation.PushAsync(new SubmitAssignmentView(assignment));
            }
        }
    }
}