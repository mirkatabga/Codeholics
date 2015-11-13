namespace Codeholics.Services.Data.Contracts
{
    using System;
    using System.Linq;

    using Models;
    using Common.Constants;

    public interface IProjectsService
    {
        IQueryable<Project> All(int page = 1, int pageSize = Defaults.DefaultPageSize);

        int Add(string title, string description, DateTime start, DateTime? deadline, string creator);

        int Update(int id);

        int Delete(int id);

        IQueryable<Project> ById(int id);
    }
}
