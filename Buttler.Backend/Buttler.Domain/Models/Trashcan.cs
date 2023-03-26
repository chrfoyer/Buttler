using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Buttler.Domain.Model.Enums;

namespace Buttler.Domain.Model;

public class Trashcan
{
    [Key]
    public int TrashCanID { get; set; }

    [ForeignKey("UserName")]
    public string UserName { get; set; }
    
    public DateTime TimeStamp { get; set; }

    [Required]
    public TrashCanType TrashCanType { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public int NumberOfTrashCans { get; set; }
}