using System.ComponentModel.DataAnnotations;
using Buttler.Domain.Model.Enums;

namespace Buttler.Domain.Model;

public class Report
{
    [Key]
    public int ReportId { get; set; }
    
    public DateTime TimeStamp { get; set; }

    public int NumberOfWaste { get; set; }

    [Required]
    public WasteType WasteType { get; set; }
}