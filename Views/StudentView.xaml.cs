using System;
using System.Collections.ObjectModel;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class StudentView : ContentPage
    {
        public ObservableCollection<Course> EnrolledCourses { get; set; }

        public StudentView(Student student)
        {
            InitializeComponent();

            EnrolledCourses = new ObservableCollection<Course>(
                App.Courses.Where(c => c.Roster.Contains(student))
            );

            CourseListView.ItemsSource = EnrolledCourses;
        }


        private async void OnCourseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //debug statement
            Console.WriteLine("Course selected");
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new StudentCourseDetailsView((Course)e.SelectedItem));
            }
        }
    }
}