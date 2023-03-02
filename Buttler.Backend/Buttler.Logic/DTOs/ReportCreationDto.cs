using System.ComponentModel.DataAnnotations;
using Buttler.Domain.Model.Enums;

namespace Buttler.Logic.DTOs;

public class ReportCreationDto
{
   // public DateTime TimeStamp { get; set; }
   
   public string userName { get; set; }

    public int NumberOfWaste { get; set; }

    [Required]
    public WasteType WasteType { get; set; }

    public double latitude { get; set; }
    
    public double longitude { get; set; }
}