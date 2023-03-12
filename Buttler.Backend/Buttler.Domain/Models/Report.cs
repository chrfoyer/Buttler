using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Buttler.Domain.Model.Enums;

namespace Buttler.Domain.Model;

public class Report
{
    [Key]
    public int ReportId { get; set; }
    
    [ForeignKey("UserName")]
    public string UserName { get; set; }
    
    public DateTime TimeStamp { get; set; }

    public int NumberOfWaste { get; set; }

    [Required]
    public WasteType WasteType { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
}