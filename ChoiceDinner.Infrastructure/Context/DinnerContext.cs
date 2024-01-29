using ChoiceDinner.Domain.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChoiceDinner.Infrastructure.Context;

public class DinnerContext : IdentityDbContext<AppUser>
{
    public DinnerContext(DbContextOptions<DinnerContext> options) : base(options)
    {
        
    }
        
}