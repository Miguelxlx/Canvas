using CanvasRemake.Views;
using CanvasRemake.Services;

namespace CanvasRemake
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStudentViewClicked(object sender, EventArgs e)
        {
            string studentId = StudentIdEntry.Text;
            //pull from database
            App.Students = await App.ServiceProvider.GetService<ApiService>().GetStudentsAsync();
            var student = App.Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student != null)
            {
                App.LoggedInStudent = student;
                await Navigation.PushAsync(new StudentView(student));
            }
            else
            {
                await DisplayAlert("Error", "Invalid student ID.", "OK");
            }
        }

        private async void OnInstructorViewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InstructorView());
        }
    }
}