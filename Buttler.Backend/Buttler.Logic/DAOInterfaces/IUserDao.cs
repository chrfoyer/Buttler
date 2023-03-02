using Buttler.Domain.Model;
using Buttler.Logic.DTOs;

namespace Buttler.Logic.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateReportAsync(UserCreationDTO dto);
    Task<IEnumerable<User>> GetAllReportsAsync();
}