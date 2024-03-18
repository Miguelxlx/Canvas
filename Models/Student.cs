namespace CanvasRemake.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public string Classification { get; set; }

        public Student(string name, string id, string classification)
        {
            Name = name;
            ID = id;
            Classification = classification;
        }

    }
}