using System.Collections.ObjectModel;
using CanvasRemake.Models;
using CanvasRemake.Views;

namespace CanvasRemake
{
	public partial class App : Application
	{
		public static IServiceProvider ServiceProvider { get; set; }
		public static ObservableCollection<Course> Courses { get; set; } = new ObservableCollection<Course>();
		public static ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
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

			Courses = new ObservableCollection<Course>
			{
				new Course("Math 101", "MATH101", "Introduction to Mathematics"),
				new Course("English 101", "ENG101", "English Composition"),
				new Course("History 101", "HIST101", "World History")
			};

			Students = new ObservableCollection<Student>
			{
				new Student("John Doe", "S001", "Freshman"),
				new Student("Jane Smith", "S002", "Sophomore"),
				new Student("Mike Johnson", "S003", "Junior")
			};

			App.Courses[0].Roster.Add(App.Students[0]);
			App.Courses[1].Roster.Add(App.Students[0]);
			App.Courses[0].Roster.Add(App.Students[1]);
			App.Courses[0].Assignments.Add(new Assignment("Assignment 1", "Assignment 1 description", 100, DateTime.Today));
			App.Courses[0].Modules.Add(new Module("Module 1", "Module 1 description"));

			App.LoggedInStudent = App.Students[0];
		}
	}
}