using CanvasRemake.ViewModels;
using CanvasRemake.Services;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class InstructorView : ContentPage
    {
        private INavigationService _navigationService;

        public InstructorView()
        {
            InitializeComponent();
            _navigationService = App.ServiceProvider.GetService<INavigationService>();
            BindingContext = new InstructorViewModel(_navigationService);
        }

        private async void OnCourseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var course = (Course)e.SelectedItem;
                await _navigationService.NavigateToInstructorCourseDetails(course);
            }
        }
    }
}