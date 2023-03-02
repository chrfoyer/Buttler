using System.ComponentModel.DataAnnotations;

namespace Buttler.Domain.Model;

public class User
{
    [Key]
    public int userID { get; set; }

    [Required]
    public string userName { get; set; }
    
    [Required]
    public string passWord { get; set; }
    
    public DateTime dateCreated { get; set; }
}