using CanvasRemake.ViewModels;
using CanvasRemake.Services;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class StudentView : ContentPage
    {
        private INavigationService _navigationService;

        public StudentView(Student student)
        {
            InitializeComponent();
            _navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new StudentViewModel(student, _navigationService);
        }

        private async void OnCourseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var course = (Course)e.SelectedItem;
                await _navigationService.NavigateToStudentCourseDetails(course);
            }
        }
    }
}