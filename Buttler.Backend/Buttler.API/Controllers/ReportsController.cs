using Microsoft.AspNetCore.Mvc;

namespace Buttler.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    

    public ReportsController()
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Reports>> CreateReport(Reports report)
    {
        
        
        _context.Reports.Add(report);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetReport", new { id = report.ReportId }, report);
    }
}