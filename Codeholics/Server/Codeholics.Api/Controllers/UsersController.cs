namespace Codeholics.Api.Controllers
{
    using System.Web.Http;
    using Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using Models;
    using Codeholics.Models;
    using Services.Data;
    using Data;

    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUsersService users;
        
        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public IHttpActionResult Get()
        {
            var result = this.users
                .All()
                .ProjectTo<UserResponseModel>()
                .ToList();

            return this.Ok(result);
        }
        
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.BadRequest("User id cannot be null or empty.");
            }

            var result = this.users
                .ById(id)
                .ProjectTo<UserResponseModel>()
                .FirstOrDefault();

            if (result == null)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }
    }
}
