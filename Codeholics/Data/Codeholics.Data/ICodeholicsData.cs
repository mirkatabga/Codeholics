using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codeholics.Data
{
    using Repositories;
    using Models;

    public interface ICodeholicsData
    {
        IRepository<User> Users { get; }

        IRepository<Friendship> Friendships { get; }

        IRepository<Skill> Skills { get; }

        IRepository<Technology> Technologies { get; }

        IRepository<Message> Messages { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Project> Projects { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();
    }
}
