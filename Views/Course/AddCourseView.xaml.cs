using System;
using System.Collections.ObjectModel;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class AddCourseView : ContentPage
    {
        public AddCourseView()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            string courseName = CourseNameEntry.Text;
            string courseCode = CourseCodeEntry.Text;
            string courseDescription = CourseDescriptionEntry.Text;

            // Create a new course object
            Course newCourse = new Course(courseName, courseCode, courseDescription);

            // Add the new course to the App.Courses collection
            App.Courses.Add(newCourse);

            // Navigate back to the previous page after adding the course
            await Navigation.PopAsync();
        }
    }
}