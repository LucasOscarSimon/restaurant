using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Data;
using Restaurant.Domain;

namespace Restaurant.Infra.Data
{
    public class DishContext : DbContext, IUnitOfWork
    {
        public DishContext(DbContextOptions<DishContext> options)
            : base(options) { }

        public DbSet<Dish> Dish { get; set; }
        public DbSet<TimeOfDay> TimeOfDay { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<bool> CommitAsync()
        {
            return await base.SaveChangesAsync().ConfigureAwait(true) > 0;
        }
    }
}