namespace DL.DalApi;

public interface ICrud<T>
{
    public Task<bool> CreateAsync(T item);
    public Task<bool> UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update);
    public Task<bool> DeleteAsync(FilterDefinition<T> filter);  
    public Task<T> GetAsync(FilterDefinition<T> filter);
    public Task<List<T>> GetAllAsync();
}
