using Buttler.Domain.Model;
using Buttler.Logic.DTOs;

namespace Buttler.Logic.LogicInterfaces;

public interface ITrashCanLogic
{
    
    /// <summary>
    /// Creates a new report asynchronously.
    /// </summary>
    /// <param name="dto">The report creation data transfer object.</param>
    /// <returns>A task that represents the asynchronous create operation. The task result contains the created report.</returns>
    Task<Trashcan> CreateReportAsync(TrashCanCreationDto dto);
    
    /// <summary>
    /// Retrieves all reports asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous retrieve operation. The task result contains a collection of reports.</returns>
    Task<IEnumerable<Trashcan>> GetAllReportsAsync();
}