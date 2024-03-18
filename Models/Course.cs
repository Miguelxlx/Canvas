using System.Collections.ObjectModel;

namespace CanvasRemake.Models
{
    public class Course
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public List<Student> Roster { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Module> Modules { get; set; }

        public Course()
        {
            Roster = new List<Student>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }

        public Course(string? name, string? code, string? description)
        {
            Name = name;
            Code = code;
            Description = description;
            Roster = new List<Student>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }
    }
}