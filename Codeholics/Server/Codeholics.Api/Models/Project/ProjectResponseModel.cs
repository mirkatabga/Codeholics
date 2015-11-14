namespace Codeholics.Api.Models.Project
{
    using Infrastructures.Mapping;
    using Codeholics.Models;
    using AutoMapper;
    using System;

    public class ProjectResponseModel : IMapFrom<Project>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? Deadline { get; set; }

        public string Creator { get; set; }

        public int TotalUsers { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Project, ProjectResponseModel>()
                .ForMember(p => p.TotalUsers, opts => opts.MapFrom(p => p.Users.Count));
        }
    }
}
