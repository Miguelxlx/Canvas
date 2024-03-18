using System;

namespace CanvasRemake.Models
{
    public class Assignment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsSubmitted { get; set; }
        public bool IsNotSubmitted => !IsSubmitted;

        public int Id { get; set; }


        public Assignment()
        {
        }
        public Assignment(string name, string description, double totalAvailablePoints, DateTime dueDate)
        {
            Name = name;
            Description = description;
            TotalAvailablePoints = totalAvailablePoints;
            DueDate = dueDate;
        }
    }
}