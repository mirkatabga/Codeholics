﻿using AutoMapper;
using Codeholics.Api.Infrastructures.Mapping;
using Codeholics.Models;

namespace Codeholics.Api.Models
{
    public class UserResponseModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
