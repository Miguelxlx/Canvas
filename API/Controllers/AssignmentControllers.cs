using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;  // Ensure this is added if using LINQ for any method like .Any()
using System.Diagnostics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentControllers : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentControllers(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignments()
        {
            return await _context.Assignments.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignment(string id)
        {
            try
            {
                var assignment = await _context.Assignments
                    .Include(a => a.Submissions)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (assignment == null)
                {
                    return NotFound();
                }

                return assignment;
            }
            catch (Exception ex)
            {
                // Log the exception
                Debug.WriteLine($"An error occurred while fetching the assignment: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching the assignment.");
            }
        }
    }
}