using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SteroidMerchApp.Models;

namespace SteroidMerchApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Steroid> Steroid { get; set; }
        public DbSet<Shirt> Shirts { get; set; }
    }
}
