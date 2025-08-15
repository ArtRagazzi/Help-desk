using api.Entities;

namespace api.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(int id);
    Task<User> FindByEmail(string email);
    Task<User> FindByEmailAndPassword(string email, string password);
    Task Insert(User user);
    Task Update(User user, int id);
    Task Delete(int id);
    
}