using api.Context;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class UserService : IUserService
{
    
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<User>> GetAll()
    {
        try
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Enumerable.Empty<User>();
        }
    }

    public async Task<User> GetById(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user != null)
        {
            return user;
        }
        throw new Exception("User not found");
    }

    public async Task<User> FindByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (user != null)
        {
            return user;
        }
        throw new Exception("User not found");
    }

    public async Task<User> FindByEmailAndPassword(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        if (user != null)
        {
            return user;
        }
        throw new Exception("User not found");
    }

    public async  Task Insert(User user)
    {
        try
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public async Task Update(User user, int id)
    {
        var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }
        existingUser.EditUser(user);
        _context.Users.Update(existingUser);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}