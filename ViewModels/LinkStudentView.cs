using CanvasRemake.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CanvasRemake.ViewModels
{
    public partial class LinkStudentsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        [ObservableProperty]
        private string courseCode;

        [ObservableProperty]
        private string studentId;

        public LinkStudentsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            LinkStudentCommand = new RelayCommand(OnLinkStudent);
        }

        public IRelayCommand LinkStudentCommand { get; }
        private async void OnLinkStudent()
        {
            var course = App.Courses.FirstOrDefault(c => c.Code == CourseCode);
            var student = App.Students.FirstOrDefault(s => s.ID == StudentId);

            if (course != null && student != null)
            {
                if (!course.Roster.Contains(student))
                {
                    course.Roster.Add(student);
                    App.Current.MainPage.DisplayAlert("Success", "Student linked to the course successfully.", "OK");
                    Console.WriteLine($"Roster for course {course.Name}:");
                    foreach (var s in course.Roster)
                    {
                        Console.WriteLine($"- {s.Name} ({s.ID})");
                    }
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Error", "Student is already linked to the course.", "OK");
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Course code or student ID is invalid.", "OK");
            }

            CourseCode = string.Empty;
            StudentId = string.Empty;
        }
    }
}