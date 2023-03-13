using Buttler.Domain.Model;
using Buttler.Logic.DaoInterfaces;
using Buttler.Logic.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Buttler.Data.DAOs;

public class UserDao : IUserDao


{
    private ApplicationDbContext context;

    public UserDao(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    public async Task<User> CreateReportAsync(UserCreationDTO dto)
    {
        User newUser = new User();
        newUser.DateCreated = DateTime.Now.ToUniversalTime();
        newUser.UserName = dto.userName;
        newUser.PassWord = dto.passWord;
        
        
        
        EntityEntry<User> added = await context.Users.AddAsync(newUser);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        List<User> users = await context.Users.ToListAsync();
        return users;
    }
}