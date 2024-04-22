using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CourseInfo
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Student> Roster { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Module> Modules { get; set; }

        public CourseInfo()
        {
            Roster = new List<Student>();
            Assignments = new List<Assignment>();
            Modules = new List<Module>();
        }
    }
}
