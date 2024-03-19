using System;

namespace CanvasRemake.Models
{
    public class AssignmentSubmission
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string AssignmentId { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string SubmissionText { get; set; } = string.Empty;
        public DateTime SubmissionDate { get; set; }
        public double Grade { get; set; }
        public bool IsGraded { get; set; }
    }
}