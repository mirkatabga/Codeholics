namespace Codeholics.Data
{
    using System;
    using System.Collections.Generic;
    using Repositories;
    using Codeholics.Models;

    public class CodeholicsData : ICodeholicsData
    {
        private ICodeholicsDbContext context;
        private IDictionary<Type, object> repositories;

        public CodeholicsData(ICodeholicsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }



        public IRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IRepository<Friendship> Friendships
        {
            get
            {
                return this.GetRepository<Friendship>();
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                return this.GetRepository<Project>();
            }
        }

        public IRepository<Skill> Skills
        {
            get
            {
                return this.GetRepository<Skill>();
            }
        }

        public IRepository<Technology> Technologies
        {
            get
            {
                return this.GetRepository<Technology>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(User)))
                {
                    type = typeof(Repository<T>);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
