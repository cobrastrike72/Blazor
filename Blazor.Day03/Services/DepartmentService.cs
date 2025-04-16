using Blazor.Day03.Models.DepartmentModels;
using System.Net.Http;
using System.Net.Http.Json;

namespace Blazor.Day03.Services
{
    public class DepartmentService : IService<DepartmentViewModel>
    {
        private readonly HttpClient _httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DepartmentViewModel>>("/api/departments");
        }

        public Task<DepartmentViewModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(DepartmentViewModel item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, DepartmentViewModel item)
        {
            throw new NotImplementedException();
        }

    }
}
