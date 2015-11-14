using Codeholics.Api.Infrastructures.Mapping;
using Codeholics.Models;

namespace Codeholics.Api.Models
{
    public class UserByUsernameRequestModel :  IMapFrom<User>
    {
        public string UserName { get; set; }
    }
}