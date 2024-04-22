using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Student
    {
        [Key]
        public string StudentId { get; set; } = Guid.NewGuid().ToString();  // Primary key as string
        public string Name { get; set; } = string.Empty;
        public string Classification { get; set; }
    }

}
