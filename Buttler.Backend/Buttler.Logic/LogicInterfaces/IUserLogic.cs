using Buttler.Domain.Model;
using Buttler.Logic.DTOs;

namespace Buttler.Logic.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateUserAsync(UserCreationDTO dto);
    Task<IEnumerable<User>> GetAllUsersAsync();
}