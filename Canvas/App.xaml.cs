using System.Collections.ObjectModel;
using CanvasRemake.Models;
using CanvasRemake.Views;
using Microsoft.EntityFrameworkCore.Diagnostics;
using CanvasRemake.Services;

namespace CanvasRemake
{
	public partial class App : Application
	{
		public static IServiceProvider ServiceProvider { get; set; }
		public static ObservableCollection<Course> Courses { get; set; }
		public static ObservableCollection<Student> Students { get; set; }
		public static ObservableCollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new ObservableCollection<AssignmentSubmission>();
		public static Student LoggedInStudent { get; set; }

		public App(IServiceProvider serviceProvider)
		{
			InitializeComponent();
			ServiceProvider = serviceProvider;
			Routing.RegisterRoute(nameof(AssignmentSubmissionsView), typeof(AssignmentSubmissionsView));
			Routing.RegisterRoute(nameof(SubmitAssignmentView), typeof(SubmitAssignmentView));
			Routing.RegisterRoute(nameof(AddModuleView), typeof(AddModuleView));
			Routing.RegisterRoute(nameof(AddAssignmentView), typeof(AddAssignmentView));
			Routing.RegisterRoute(nameof(AddCourseView), typeof(AddCourseView));
			Routing.RegisterRoute(nameof(AddStudentView), typeof(AddStudentView));
			Routing.RegisterRoute(nameof(LinkStudentsView), typeof(LinkStudentsView));
			Routing.RegisterRoute(nameof(InstructorCourseDetailsView), typeof(InstructorCourseDetailsView));
			Routing.RegisterRoute(nameof(StudentCourseDetailsView), typeof(StudentCourseDetailsView));
			Routing.RegisterRoute(nameof(SearchStudentView), typeof(SearchStudentView));
			Routing.RegisterRoute(nameof(SearchCourseView), typeof(SearchCourseView));

			MainPage = new AppShell();
			LoadDataAsync();
		}

		private async void LoadDataAsync()
		{
			var apiService = ServiceProvider.GetService<ApiService>();
			Courses = await apiService.GetCoursesAsync();
			Students = await apiService.GetStudentsAsync();
			// Assume a method to configure LoggedInStudent or handle it appropriately
			SetupLoggedInStudent();
		}

		private void SetupLoggedInStudent()
		{
			// This would be dynamic based on actual app logic
			LoggedInStudent = Students.FirstOrDefault();
		}
	}
}
