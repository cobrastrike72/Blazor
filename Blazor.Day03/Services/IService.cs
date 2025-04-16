namespace Blazor.Day03.Services
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task DeleteAsync(int id);   
        Task UpdateAsync(int id,  T entity);
    }
}
