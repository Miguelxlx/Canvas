using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CanvasRemake.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;

namespace CanvasRemake.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public ApiService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // Adjust case sensitivity
            };
        }

        public async Task<ObservableCollection<Course>> GetCoursesAsync()
        {
            var response = await _client.GetAsync("api/courses");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ObservableCollection<Course>>();
        }

        public async Task<ObservableCollection<Student>> GetStudentsAsync()
        {
            var response = await _client.GetAsync("api/students");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ObservableCollection<Student>>(_options);
        }

        // Add a new course
        public async Task<bool> AddCourseAsync(Course course)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("api/courses", course);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        // Add a new student
        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("api/students", student);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                // Log or handle exceptions
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> LinkStudentToCourseAsync(string courseCode, string studentId)
        {
            try
            {
                var response = await _client.PostAsync($"api/courses/{courseCode}/students/{studentId}", null);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> RemoveStudentFromCourseAsync(string courseCode, string studentId)
        {
            try
            {
                var response = await _client.DeleteAsync($"api/courses/{courseCode}/students/{studentId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<Course>> GetEnrolledCoursesForStudentAsync(string studentId)
        {
            try
            {
                var response = await _client.GetAsync($"api/students/{studentId}/courses");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<Course>>();
            }
            catch (Exception ex)
            {
                // Handle exception
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return Enumerable.Empty<Course>();
            }
        }

        public async Task<Course> GetCourseDetailsAsync(string courseCode)
        {
            try
            {
                var response = await _client.GetAsync($"api/courses/{courseCode}/details");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Course>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task AddModuleToCourseAsync(string courseCode, Module module)
        {
            try
            {
                var response = await _client.PostAsJsonAsync($"api/courses/{courseCode}/modules", module);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task AddAssignmentToCourseAsync(string courseCode, Assignment assignment)
        {
            try
            {
                var response = await _client.PostAsJsonAsync($"api/courses/{courseCode}/assignments", assignment);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task SubmitAssignmentAsync(AssignmentSubmission submission)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("api/assignmentsubmissions", submission);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Assignment> GetAssignmentByIdAsync(string assignmentId)
        {
            try
            {
                var response = await _client.GetAsync($"api/assignmentcontrollers/{assignmentId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Assignment>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<Student> GetStudentByIdAsync(string studentId)
        {
            try
            {
                var response = await _client.GetAsync($"api/students/{studentId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Student>();
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<ObservableCollection<AssignmentSubmission>> GetSubmissionsForAssignmentAsync(string assignmentId)
        {
            try
            {
                var response = await _client.GetAsync($"api/assignmentsubmissions/assignment/{assignmentId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ObservableCollection<AssignmentSubmission>>();
                }
                return new ObservableCollection<AssignmentSubmission>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
                return new ObservableCollection<AssignmentSubmission>();
            }
        }

        public async Task GradeSubmissionAsync(AssignmentSubmission submission)
        {
            try
            {
                var response = await _client.PutAsJsonAsync($"api/assignmentsubmissions/{submission.SubmissionId}", submission);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
