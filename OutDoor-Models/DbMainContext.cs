using Microsoft.EntityFrameworkCore;
using OutDoor_Models.Models;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace OutDoor_Models
{
    public class DbMainContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<PostModel> Post { get; set; }
        public DbSet<CategoryModel> Category { get; set; }

        public DbMainContext(DbContextOptions<DbMainContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}