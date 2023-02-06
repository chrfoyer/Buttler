using Buttler.Domain.Model;
using Buttler.Logic.DaoInterfaces;
using Buttler.Logic.DTOs;
using Buttler.Logic.LogicInterfaces;

namespace Buttler.Logic.LogicImplementations;

public class ReportLogic : IReportLogic
{
    
    private  readonly IReportDao _reportDao;

    public ReportLogic(IReportDao reportDao)
    {
        this._reportDao = reportDao;
    }


    public async Task<Report> CreateReportAsync(ReportCreationDto dto)
    {
        Report created = await _reportDao.CreateReportAsync(dto);
        return created;
    }

    public Task<IEnumerable<Report>> GetAllReportsAsync()
    {
        return _reportDao.GetAllReportsAsync();
    }
}