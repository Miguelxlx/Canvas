using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Assignment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }

        // Change from ObservableCollection to List for EF Core compatibility
        public List<AssignmentSubmission> Submissions { get; set; } = new List<AssignmentSubmission>();

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
