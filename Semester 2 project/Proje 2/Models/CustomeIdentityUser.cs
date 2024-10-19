using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ModelsFac;


public class AAADbContext : IdentityDbContext<CustomeIdentityUser>
{
    public AAADbContext(DbContextOptions options) : base(options)
    {
    }
}
public class CustomeIdentityUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

}
