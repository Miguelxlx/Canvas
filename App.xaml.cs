using System.Collections.ObjectModel;
using CanvasRemake.Models;

namespace CanvasRemake
{
	public partial class App : Application
	{
		public static IServiceProvider ServiceProvider { get; set; }
		public static ObservableCollection<Course> Courses { get; set; } = new ObservableCollection<Course>();
		public static ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

		public static Student LoggedInStudent { get; set; }

		public App(IServiceProvider serviceProvider)
		{
			InitializeComponent();
			ServiceProvider = serviceProvider;
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
			//due date today
			App.Courses[0].Assignments.Add(new Assignment("Assignment 1", "Assignment 1 description", 100, DateTime.Today));

			App.LoggedInStudent = App.Students[0];
		}
	}
}