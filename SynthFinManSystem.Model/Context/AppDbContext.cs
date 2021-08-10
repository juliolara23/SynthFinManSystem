using Microsoft.EntityFrameworkCore;
using SynthFinManSystem.Model.Objects;

namespace SynthFinManSystem.Model.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSet Definition

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Foreing keys

            modelBuilder.Entity<User>()
                .HasOne(x => x.RoleUser)
                .WithMany()
                .HasForeignKey(y => y.IdRole);

            #endregion

        }
    }
}
