using System;
using System.Linq;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class LinkStudentsView : ContentPage
    {
        public LinkStudentsView()
        {
            InitializeComponent();
        }

        private async void OnLinkStudentClicked(object sender, EventArgs e)
        {
            string courseCode = CourseCodeEntry.Text;
            string studentId = StudentIdEntry.Text;

            var course = App.Courses.FirstOrDefault(c => c.Code == courseCode);
            var student = App.Students.FirstOrDefault(s => s.ID == studentId);

            if (course != null && student != null)
            {
                if (!course.Roster.Contains(student))
                {
                    course.Roster.Add(student);
                    await DisplayAlert("Success", "Student linked to the course successfully.", "OK");

                    // Print the entire roster
                    Console.WriteLine($"Roster for course {course.Name}:");
                    foreach (var s in course.Roster)
                    {
                        Console.WriteLine($"- {s.Name} ({s.ID})");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Student is already linked to the course.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Course code or student ID is invalid.", "OK");
            }

            CourseCodeEntry.Text = string.Empty;
            StudentIdEntry.Text = string.Empty;
        }
    }
}