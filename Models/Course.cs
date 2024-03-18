using System.Collections.ObjectModel;

namespace CanvasRemake.Models
{
    public class Course
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public ObservableCollection<Student> Roster { get; set; }
        public ObservableCollection<Assignment> Assignments { get; set; }
        public ObservableCollection<Module> Modules { get; set; }

        public Course()
        {
            Roster = new ObservableCollection<Student>();
            Assignments = new ObservableCollection<Assignment>();
            Modules = new ObservableCollection<Module>();
        }

        public Course(string? name, string? code, string? description) : this()
        {
            Name = name;
            Code = code;
            Description = description;
        }
    }
}
