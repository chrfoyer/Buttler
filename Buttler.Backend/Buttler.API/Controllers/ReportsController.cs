using Buttler.Domain.Model;
using Buttler.Logic.DTOs;
using Buttler.Logic.LogicInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Buttler.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    
    private readonly IReportLogic  _reportLogic;

    public ReportsController(IReportLogic reportLogic)
    {
        this._reportLogic = reportLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Report>> CreateReport(ReportCreationDto dto)
    {
        try
        {
            Report created = await _reportLogic.CreateReportAsync(dto);
            return Created($"/reports/{created.ReportId}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }


    }
}