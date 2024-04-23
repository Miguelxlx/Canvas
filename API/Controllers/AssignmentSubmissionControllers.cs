using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;  // Ensure this is added if using LINQ for any method like .Any()

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentSubmissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentSubmissionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AssignmentSubmissions
        [HttpPost]
        public async Task<ActionResult<AssignmentSubmission>> PostAssignmentSubmission(AssignmentSubmission submission)
        {
            var existingSubmission = await _context.AssignmentSubmissions
                .FirstOrDefaultAsync(s => s.StudentId == submission.StudentId && s.AssignmentId == submission.AssignmentId);

            if (existingSubmission != null)
            {
                existingSubmission.SubmissionText = submission.SubmissionText;
                existingSubmission.SubmissionDate = submission.SubmissionDate;
                existingSubmission.Grade = submission.Grade;
            }
            else
            {
                _context.AssignmentSubmissions.Add(submission);
            }

            await _context.SaveChangesAsync();
            return submission;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentSubmission>> GetAssignmentSubmission(string id)
        {
            var submission = await _context.AssignmentSubmissions.FindAsync(id);

            if (submission == null)
            {
                return NotFound();
            }

            return submission;
        }
    }

}