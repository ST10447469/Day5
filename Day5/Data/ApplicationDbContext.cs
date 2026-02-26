using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Day5.Models;

namespace Day5.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Day5.Models.Events> Events { get; set; } = default!;
        public DbSet<Day5.Models.Registration> Registration { get; set; } = default!;
        public DbSet<Day5.Models.UserSearch> UserSearch { get; set; } = default!;
        public DbSet<Day5.Models.EventSearch> EventSearch { get; set; } = default!;
    }
}
