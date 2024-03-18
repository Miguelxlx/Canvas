using System;
using System.Windows.Input;
using CanvasRemake.Models;
using Microsoft.Maui.Controls;

namespace CanvasRemake.ViewModels
{
    public class AddAssignmentViewModel : BindableObject
    {
        private Course _course;

        public ICommand SaveCommand { get; }

        // Properties for data binding
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public double AssignmentPoints { get; set; }
        public DateTime AssignmentDueDate { get; set; } = DateTime.Now;

        public AddAssignmentViewModel(Course course)
        {
            _course = course;
            SaveCommand = new Command(OnSave);
        }

        private void OnSave()
        {
            var assignment = new Assignment
            {
                Name = AssignmentName,
                Description = AssignmentDescription,
                TotalAvailablePoints = AssignmentPoints,
                DueDate = AssignmentDueDate
            };

            _course.Assignments.Add(assignment);

            // Publish a message indicating save is complete
            MessagingCenter.Send(this, "SaveCompleted");
        }

    }
}
