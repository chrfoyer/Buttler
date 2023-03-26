using Buttler.Domain.Model;
using Buttler.Logic.DTOs;

namespace Buttler.Logic.DaoInterfaces;

public interface ITrashDao
{
    Task<Trashcan> CreateReportAsync(TrashCanCreationDto dto);
    Task<IEnumerable<Trashcan>> GetAllReportsAsync();
}