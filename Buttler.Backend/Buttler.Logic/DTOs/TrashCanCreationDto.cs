using System.ComponentModel.DataAnnotations;
using Buttler.Domain.Model.Enums;

namespace Buttler.Logic.DTOs;

public class TrashCanCreationDto
{
    
    public string UserName { get; set; }
    
    public DateTime TimeStamp { get; set; }

    [Required]
    public TrashCanType TrashCanType { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public int NumberOfTrashCans { get; set; }
}