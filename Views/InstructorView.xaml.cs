using System;
using System.Collections.ObjectModel;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class InstructorView : ContentPage
    {
        public InstructorView()
        {
            InitializeComponent();
        }

        private async void OnAddStudentClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Add student clicked");
            await Navigation.PushAsync(new AddStudentView());
        }

        private async void OnAddCourseClicked(object sender, EventArgs e)
        {
            // Navigate to the add course view
            await Navigation.PushAsync(new AddCourseView());
        }
        private async void OnLinkStudentsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LinkStudentsView());
        }

        private async void OnCourseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new InstructorCourseDetailsView((Course)e.SelectedItem));
            }
        }
    }
}