using GymManager.API.Models;
using GymManager.API.Data;
using Microsoft.EntityFrameworkCore;

namespace GymManager.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GymContext _context;

    public UserRepository(GymContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}