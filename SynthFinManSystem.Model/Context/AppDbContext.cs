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
        #endregion

    }
}
