using Buttler.Domain.Model;
using Buttler.Logic.DTOs;

namespace Buttler.Logic.DaoInterfaces;

public interface IReportDao
{
    Task<Report> CreateReportAsync(ReportCreationDto dto);
    Task<IEnumerable<Report>> GetAllReportsAsync();
}