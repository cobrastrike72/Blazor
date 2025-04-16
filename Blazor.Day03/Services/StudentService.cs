
using Microsoft.VisualBasic;
using System.Net.Http.Json;

namespace Blazor.Day03.Services
{
    public class StudentService : IService<StudentViewModel>
    {
        HttpClient _httpClient;
        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient; // in services you can inject using consturctor but in components you can inject only using properties
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync < List<StudentViewModel>>("/api/students");
        }

        public async Task<StudentViewModel> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<StudentViewModel>($"/api/students/{id}");
        }

        public async Task UpdateAsync(int id, StudentViewModel entity)
        {
            var std = ConvertFromStudentViewModelToOtherModelsAndViceVersa.ConvertFromStudentViewModelToStudentEditViewModel(entity);
            await _httpClient.PutAsJsonAsync<StudentEditModel>($"/api/students/{id}", std);
        }
    }
}
