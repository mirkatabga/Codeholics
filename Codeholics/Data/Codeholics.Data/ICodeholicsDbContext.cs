using Codeholics.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Codeholics.Data
{
    public interface ICodeholicsDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Friendship> Friendships { get; set; }

        IDbSet<Skill> Skills { get; set; }

        IDbSet<Technology> Technologies { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
