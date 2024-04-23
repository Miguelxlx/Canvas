using CanvasRemake.ViewModels;
using CanvasRemake.Services;
using CanvasRemake.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CanvasRemake.Views
{
    public partial class StudentView : ContentPage
    {
        private INavigationService _navigationService;
        private ApiService _apiService;

        public StudentView(Student student)
        {
            InitializeComponent();
            _navigationService = App.ServiceProvider.GetService<INavigationService>();
            _apiService = App.ServiceProvider.GetService<ApiService>();
            BindingContext = new StudentViewModel(student, _navigationService, _apiService);
        }

        private async void OnCourseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var course = (Course)e.SelectedItem;
                await _navigationService.NavigateToStudentCourseDetails(course.Code);
            }
        }
    }
}