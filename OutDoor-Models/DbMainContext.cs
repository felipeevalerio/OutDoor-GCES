using Microsoft.EntityFrameworkCore;
using OutDoor_Models.Models;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace OutDoor_Models
{
    public class DbMainContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }

        public DbMainContext(DbContextOptions<DbMainContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserModel>()
                .Property(u => u.UserType)
                .HasConversion(
                    e => e.ToString(),
                    e => (UserTypes)Enum.Parse(typeof(UserTypes), e));
        }


    }
}