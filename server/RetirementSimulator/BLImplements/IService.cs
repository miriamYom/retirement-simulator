using BL.DTO;

namespace BL.BLImplements;

public interface IService<T>
{
    public Task<T> GetAsync(T item);
    public Task<List<T>> GetAllAsync();
    public Task<bool> CreateAsync(T item);
    public Task<bool> DeleteAsync(T item);
    public Task<bool> UpdateAsync(UserDTO user, UserDTO update);
    public UserDTO Login(string email, string pas);
}
