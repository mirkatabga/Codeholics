namespace Codeholics.Services.Data.Contracts
{
    using System.Linq;
    using Models;
    using Common.Constants;

    public interface IUsersService
    {
        IQueryable<User> All(int page = 1, int pageSize = Defaults.DefaultPageSize);

        IQueryable<User> ById(string id);

        IQueryable<User> ByUserName(string userName);
    }
}
