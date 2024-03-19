using System;

namespace CanvasRemake.Models
{
    public class Assignment
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsNotSubmitted => !IsSubmitted;
        public string Id { get; set; } = Guid.NewGuid().ToString();

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