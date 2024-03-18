using System;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class AddStudentView : ContentPage
    {
        public AddStudentView()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            string studentName = StudentNameEntry.Text;
            string studentID = StudentIDEntry.Text;
            string studentClassification = StudentClassificationEntry.Text;

            // Create a new Student object
            Student newStudent = new Student(studentName, studentID, studentClassification);

            // Add the new student to the global list of students
            App.Students.Add(newStudent);

            //print all students
            foreach (var student in App.Students)
            {
                Console.WriteLine(student.Name);
            }

            // Navigate back to the previous page
            await Navigation.PopAsync();
        }
    }
}