using Buttler.Domain.Model;
using Buttler.Logic.DaoInterfaces;
using Buttler.Logic.DTOs;
using Buttler.Logic.LogicInterfaces;

namespace Buttler.Logic.LogicImplementations;

public class UserLogic : IUserLogic
{
    private  readonly IUserDao _userDao;
    
    public UserLogic(IUserDao userDao)
    {
        _userDao = userDao;
    }
    
    
    public async Task<User> CreateUserAsync(UserCreationDTO dto)
    {
        User created = await _userDao.CreateReportAsync(dto);
        return created;
    }

    public Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return _userDao.GetAllUsersAsync();
    }
}