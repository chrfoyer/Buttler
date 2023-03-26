using Buttler.Domain.Model;
using Buttler.Logic.DaoInterfaces;
using Buttler.Logic.DTOs;
using Buttler.Logic.LogicInterfaces;

namespace Buttler.Logic.LogicImplementations;

public class TrashCanLogic : ITrashCanLogic
{
    private  readonly ITrashDao _trashDao;

    public TrashCanLogic(ITrashDao trashDao)
    {
        this._trashDao = trashDao;
    }


    public async Task<Trashcan> CreateReportAsync(TrashCanCreationDto dto)
    {
        Trashcan created = await _trashDao.CreateReportAsync(dto);
        return created;
    }

    public Task<IEnumerable<Trashcan>> GetAllReportsAsync()
    {
        return _trashDao.GetAllReportsAsync();
    }
}