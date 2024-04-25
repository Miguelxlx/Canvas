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


        [HttpGet("assignment/{assignmentId}")]
        public async Task<ActionResult<IEnumerable<AssignmentSubmission>>> GetSubmissionsForAssignment(string assignmentId)
        {
            var submissions = await _context.AssignmentSubmissions
                .Where(s => s.AssignmentId == assignmentId)
                .ToListAsync();

            return submissions;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> GradeSubmission(string id, AssignmentSubmission submission)
        {
            if (id != submission.SubmissionId)
            {
                return BadRequest();
            }

            _context.Entry(submission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool SubmissionExists(string id)
        {
            return _context.AssignmentSubmissions.Any(s => s.SubmissionId == id);
        }
    }

}