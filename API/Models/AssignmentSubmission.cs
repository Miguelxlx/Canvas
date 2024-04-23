using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class AssignmentSubmission
    {
        [Key]
        public string SubmissionId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public string AssignmentId { get; set; } = string.Empty;
        public string SubmissionText { get; set; } = string.Empty;
        public DateTime SubmissionDate { get; set; }
        public double Grade { get; set; } = 0;
        public bool IsGraded { get; set; }
    }
}
