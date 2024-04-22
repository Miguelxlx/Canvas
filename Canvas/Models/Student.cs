using System;
using System.Text.Json.Serialization; // Make sure to have this using directive

namespace CanvasRemake.Models
{
    public class Student
    {
        [JsonPropertyName("studentId")]
        public string StudentId { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("classification")]
        public string Classification { get; set; }

        public Student() { }

        public Student(string name, string studentId, string classification)
        {
            Name = name;
            StudentId = studentId;
            Classification = classification;
        }
    }
}
