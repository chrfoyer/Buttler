using System.ComponentModel.DataAnnotations;
using Buttler.Domain.Model.Enums;

namespace Buttler.Logic.DTOs;

public class ReportCreationDto
{
   // public DateTime TimeStamp { get; set; }
   
   public string UserName { get; set; }

    public int NumberOfWaste { get; set; }

    [Required]
    public WasteType WasteType { get; set; }

    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
}