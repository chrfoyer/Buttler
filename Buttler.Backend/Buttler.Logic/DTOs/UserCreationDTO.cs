using System.ComponentModel.DataAnnotations;

namespace Buttler.Logic.DTOs;

public class UserCreationDTO
{
    [Required]
    public string userName { get; set; }
    
    [Required]
    public string passWord { get; set; }
    
    public DateTime dateCreated { get; set; }
}