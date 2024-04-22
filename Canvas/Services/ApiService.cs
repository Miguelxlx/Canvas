using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CanvasRemake.Models;
using System.Collections.ObjectModel;

namespace CanvasRemake.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService(HttpClient client)
        {
            _client = client;
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
            return await response.Content.ReadFromJsonAsync<ObservableCollection<Student>>();
        }

        // Fetch all courses
        public async Task<Course[]> GetAllCoursesAsync()
        {
            return await _client.GetFromJsonAsync<Course[]>("api/courses");
        }

        // Add a new course
        public async Task<bool> AddCourseAsync(Course course)
        {
            var response = await _client.PostAsJsonAsync("api/courses", course);
            return response.IsSuccessStatusCode;
        }

        // Fetch all students
        public async Task<Student[]> GetAllStudentsAsync()
        {
            return await _client.GetFromJsonAsync<Student[]>("api/students");
        }

        // Add a new student
        public async Task<bool> AddStudentAsync(Student student)
        {
            var response = await _client.PostAsJsonAsync("api/students", student);
            return response.IsSuccessStatusCode;
        }
    }
}
