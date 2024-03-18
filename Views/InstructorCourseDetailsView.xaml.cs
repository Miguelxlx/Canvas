using System;
using CanvasRemake.Models;

namespace CanvasRemake.Views
{
    public partial class InstructorCourseDetailsView : ContentPage
    {
        public InstructorCourseDetailsView(Course course)
        {
            InitializeComponent();
            BindingContext = course;

            MessagingCenter.Subscribe<AddModuleView>(this, "ModuleAdded", _ =>
            {
                OnPropertyChanged(nameof(BindingContext));
            });
        }

        private async void OnAddModuleClicked(object sender, EventArgs e)
        {
            var module = new Module
            {
                Name = "New Module",
                Description = "Module description"
            };

            var course = (Course)BindingContext;
            course.Modules.Add(module);

            await Navigation.PushAsync(new AddModuleView(module));
        }
        private async void OnAddAssignmentClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            await Navigation.PushAsync(new AddAssignmentView(course));
        }
    }
}