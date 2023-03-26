using System.ComponentModel.DataAnnotations;

namespace Buttler.Domain.Model;

public class User
{
    [Key]
    public int UserID { get; set; }

    [Required]
    public string UserName { get; set; }
    
    [Required]
    public string PassWord { get; set; }
    
    public DateTime DateCreated { get; set; }
}