using System;

namespace CanvasRemake.Models
{
    public class AssignmentSubmission
    {
        public string SubmissionId { get; set; } = Guid.NewGuid().ToString();
        public string AssignmentId { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string SubmissionText { get; set; } = string.Empty;
        public DateTime SubmissionDate { get; set; }
        public double Grade { get; set; } = 0;
        public bool IsGraded { get; set; }
    }
}