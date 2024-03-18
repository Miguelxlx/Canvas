using System;
using CanvasRemake.Views;

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
			var student = App.Students.FirstOrDefault(s => s.ID == "S001"); // Replace with your student selection logic
			await Navigation.PushAsync(new StudentView(student));
		}

		private async void OnInstructorViewClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new InstructorView());
		}
	}
}