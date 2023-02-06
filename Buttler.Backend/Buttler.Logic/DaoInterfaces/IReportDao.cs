using Buttler.Domain.Model;

namespace Buttler.Logic.DaoInterfaces;

public interface IReportDao
{
    Task<Report> CreateReportAsync(Report report);
    Task<IEnumerable<Report>> GetAllReportsAsync();
}