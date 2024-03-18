namespace CanvasRemake.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string StudentId { get; set; }
        public DateTime SubmissionDate { get; set; }
        // Add any other properties related to the submission
    }
}