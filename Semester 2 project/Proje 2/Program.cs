using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proje_term.Controllers;
using ModelsFac;
using Proje_term.Validators;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AAADbContext>(c => c.UseSqlServer("Server=.;Database=ProjectTerm2;Trusted_Connection=True;Encrypt=False"));
builder.Services.AddMvc();
builder.Services.AddIdentity<CustomeIdentityUser, IdentityRole>(c =>
{
    c.User.AllowedUserNameCharacters = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890-_";
    c.User.RequireUniqueEmail = true;
    c.Password.RequireNonAlphanumeric = true;
    c.Password.RequireUppercase = true;
    c.Password.RequireDigit = true;
    c.Password.RequiredUniqueChars = 2;
    c.Password.RequiredLength = 6;

}).AddPasswordValidator<PasswordVaidator>().AddEntityFrameworkStores<AAADbContext>();
builder.Services.AddRazorPages();
var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();
app.MapRazorPages();
app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");



app.Run();
