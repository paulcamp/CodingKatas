using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RemindersDemo.Models;

namespace RemindersDemo
{
    public interface IApplicationDbContext
    {
        DbSet<TaskItemWithUsers> Tasks { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        
        int SaveChanges();

        void Dispose();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}