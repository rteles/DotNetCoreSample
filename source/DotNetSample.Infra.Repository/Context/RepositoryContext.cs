using DotNetSample.Domain.Entities;
using DotNetSample.Infra.Repository.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace DotNetSample.Infra.Repository.Context
{
    public class RepositoryContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}