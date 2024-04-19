using System;
using System.Collections.ObjectModel;

namespace CanvasRemake.Models
{
    public class Assignment
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ObservableCollection<AssignmentSubmission> Submissions { get; set; } = new ObservableCollection<AssignmentSubmission>();

        public Assignment() { }

        public Assignment(string name, string description, double totalAvailablePoints, DateTime dueDate)
        {
            Name = name;
            Description = description;
            TotalAvailablePoints = totalAvailablePoints;
            DueDate = dueDate;
        }
    }
}