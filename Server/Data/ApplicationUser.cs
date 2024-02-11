using Microsoft.AspNetCore.Identity;

namespace Server.Data;

public class ApplicationUser : IdentityUser
{
    public DateTime Born {get; set;}
    public bool ConfirmPolicy { get; set; }
}