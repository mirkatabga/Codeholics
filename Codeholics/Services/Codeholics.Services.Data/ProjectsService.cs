
namespace Codeholics.Services.Data
{
    using System;
    using System.Linq;

    using Models;
    using Contracts;
    using Codeholics.Data;
    using Common.Constants;

    public class ProjectsService : IProjectsService
    {
        private ICodeholicsData data;

        public ProjectsService(ICodeholicsData data)
        {
            this.data = data;
        }

        public int Add(string title, string description, DateTime start, DateTime? deadline, string creator)
        {
            var currentUser = this.data.Users
              .All()
              .FirstOrDefault(u => u.UserName == creator);

            if (currentUser == null)
            {
                throw new ArgumentException("Current user cannot be found!");
            }

            var project = new Project
            {
                Title = title,
                Description = description,
                StartDate = start,
                Deadline = deadline,
                Creator = creator
            };

            project.Users.Add(currentUser);
            this.data.Projects.Add(project);
            this.data.Projects.SaveChanges();

            return project.Id;
        }

        public IQueryable<Project> All(int page = 1, int pageSize = Defaults.DefaultPageSize)
        {
            return this.data.Projects
                .All()
                .OrderByDescending(pr => pr.StartDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public IQueryable<Project> ById(int id)
        {
            return this.data.Projects
                .All()
                .Where(pr =>
                    pr.Id == id
                        && !pr.Deleted);
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
