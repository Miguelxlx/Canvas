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
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseInfo>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseInfo>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<CourseInfo>> PostCourse(CourseInfo course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCourse), new { id = course.CourseId }, course);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseInfo course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Courses.Any(e => e.CourseId == id))
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

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{code}/students/{studentId}")]
        public async Task<IActionResult> LinkStudentToCourse(string code, string studentId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Code == code);
            var student = await _context.Students.FindAsync(studentId);

            if (course == null || student == null)
            {
                return NotFound();
            }

            if (!course.Roster.Contains(student))
            {
                course.Roster.Add(student);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpDelete("{code}/students/{studentId}")]
        public async Task<IActionResult> RemoveStudentFromCourse(string code, string studentId)
        {
            var course = await _context.Courses.Include(c => c.Roster).FirstOrDefaultAsync(c => c.Code == code);
            var student = await _context.Students.FindAsync(studentId);

            if (course == null || student == null)
            {
                return NotFound();
            }

            if (course.Roster.Contains(student))
            {
                course.Roster.Remove(student);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpGet("{courseCode}/details")]
        public async Task<ActionResult<CourseInfo>> GetCourseDetails(string courseCode)
        {
            var course = await _context.Courses
                .Include(c => c.Modules)
                    .ThenInclude(m => m.ContentItems)
                .Include(c => c.Assignments)
                .FirstOrDefaultAsync(c => c.Code == courseCode);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        [HttpPost("{courseCode}/modules")]
        public async Task<ActionResult<Module>> AddModuleToCourse(string courseCode, Module module)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Code == courseCode);

            if (course == null)
            {
                return NotFound();
            }

            course.Modules.Add(module);
            await _context.SaveChangesAsync();

            return module;
        }

        [HttpPost("{courseCode}/assignments")]
        public async Task<ActionResult<Assignment>> AddAssignmentToCourse(string courseCode, Assignment assignment)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Code == courseCode);

            if (course == null)
            {
                return NotFound();
            }

            course.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            return assignment;
        }
    }
}
