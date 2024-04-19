namespace CanvasRemake.Models
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public string ID { get; set; } = string.Empty;

        public string Classification { get; set; }

        public Student(string name, string id, string classification)
        {
            Name = name;
            ID = id;
            Classification = classification;
        }

    }
}